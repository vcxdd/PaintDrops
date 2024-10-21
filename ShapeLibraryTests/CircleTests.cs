using ShapeLibrary;
using System.Runtime.CompilerServices;

namespace ShapeLibraryTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Radius cannot be 0 or less.")]
        public void CircleRadiusTest()
        {
            Circle c = new Circle(50, 50, 0, new Colour(0, 0, 255));
        }

        [TestMethod]
        public void VerticesTest()
        {
            Circle c = new Circle(8, 16, 100, new Colour(0, 0, 255));
            float tolerance = 0.001f;

            Assert.AreEqual(108, c.Vertices[0].X);
            Assert.AreEqual(16, c.Vertices[0].Y);
            Assert.AreEqual(107.998, c.Vertices[1].X, tolerance);
            Assert.AreEqual(16.614, c.Vertices[1].Y, tolerance);
            Assert.AreEqual(103.331, c.Vertices[50].X, tolerance);
            Assert.AreEqual(46.201, c.Vertices[50].Y, tolerance);

        }
    }
}
