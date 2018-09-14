using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Triangle> triangles = new List<Triangle>();
            Random rnd = new Random();

            for (int i = 1; i <= 3; i++)
            {
                Point a = new Point(i * rnd.Next(-10,10),i * rnd.Next(-10, 10));
                Point b = new Point(i * rnd.Next(-10, 10), i * rnd.Next(-10, 10));
                Point c = new Point(i * rnd.Next(-10, 10), i * rnd.Next(-10, 10));
                    triangles.Add(new Triangle(a, b, c));
            }

            foreach (var tr in triangles)
            {
                Console.WriteLine("Show triangle points:");
                tr.Print();
            }

            Console.WriteLine("Triangle with smalest distanse to Point(0,0)");
            Point zero = new Point(0,0);
            triangles.OrderBy(x => x.Vertex1.Distance(zero))
                            .ThenBy(x => x.Vertex2.Distance(zero))
                            .ThenBy(x => x.Vertex3.Distance(zero)).First().Print();
            Console.ReadKey();
        }
    }

    public struct Point
    {
        public int X, Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Abs(Math.Pow(this.X - p.X, 2)) + Math.Abs(Math.Pow(this.Y - p.Y, 2)));
        }

        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }
    }

    public class Triangle
    {
        private Point vertex1, vertex2, vertex3;

        public Point Vertex1 { get { return vertex1; } set { vertex1 = value; } }
        public Point Vertex2 { get { return vertex2; } set { vertex2 = value; } }
        public Point Vertex3 { get { return vertex3; } set { vertex3 = value; } }

        public Triangle(Point a, Point b, Point c)
        {
            vertex1 = a;
            vertex2 = b;
            vertex3 = c;
        }

        public double Perimeter()
        {
            return vertex1.Distance(vertex2) + vertex1.Distance(vertex3) + vertex2.Distance(vertex3);
        }
        public double Square()
        {
            double p = Perimeter() / 2;
            double sideA = vertex1.Distance(vertex2);
            double sideB = vertex1.Distance(vertex3);
            double sideC = vertex2.Distance(vertex3);

            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }
        public void Print()
        {
            Console.Write($"{vertex1.ToString()}\n{vertex2.ToString()}\n{vertex3.ToString()}\n");
        }
    }

}
