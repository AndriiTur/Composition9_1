using Composition9_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CompositionTest
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void DistanceTest()
        {
            //Arrange
            Point p1 = new Point(0, 0);
            Point p2 = new Point(1, 0);
            double expected = 1;

            //Act
            double result = p1.Distance(p2);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToStringTest()
        {
            //Arrange
            Point p1 = new Point(0, 0);
            string expected = "(0,0)";

            //Act
            string result = p1.ToString();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void PerimeterTest()
        {
            //Arrange
            Point a = new Point(0, 0);
            Point b = new Point(3, 0);
            Point c = new Point(3, 4);
            double expected = 12;
            Triangle tr = new Triangle(a, b, c);

            //Act
            double result = tr.Perimeter();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SquareTest()
        {
            //Arrange
            Point a = new Point(0, 0);
            Point b = new Point(3, 0);
            Point c = new Point(3, 4);
            double expected  = (b.Distance(a) * c.Distance(b)) / 2;
            Triangle tr = new Triangle(a, b, c);

            //Act
            double result = tr.Square();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PrintTest()
        {
            //Arrange
            Point a = new Point(0, 0);
            Point b = new Point(1, 0);
            Point c = new Point(1, 1);
            Triangle tr = new Triangle(a, b, c);
            string expected = $"(0,0)\n(1,0)\n(1,1)\n";

            //Act
            string result;

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                tr.Print();
                result = stringWriter.ToString();
            }

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
