using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics;

namespace PaintDropTests
{
    [TestClass]
    public class PaintDropTests
    {
        [TestMethod]
        public void MarbleTest()
        {
            Circle c1 = new Circle(8, 16, 100, new Colour(0, 0, 255));
            Circle c2 = new Circle(15, 16, 100, new Colour(0, 0, 255));
            IPaintDrop d1 = PaintDropSimulationFactory.CreatePaintDrop(c1);
            IPaintDrop d2 = PaintDropSimulationFactory.CreatePaintDrop(c2);
            float tolerance = 0.001f;

            Assert.AreEqual(108, d1.Circle.Vertices[0].X);
            Assert.AreEqual(16, d1.Circle.Vertices[0].Y);
            Assert.AreEqual(41.689, d1.Circle.Vertices[50].X, tolerance);
            Assert.AreEqual(110.154, d1.Circle.Vertices[50].Y, tolerance);

            d1.Marble(d2);

            Assert.AreEqual(151.561, d1.Circle.Vertices[0].X, tolerance);
            Assert.AreEqual(16, d1.Circle.Vertices[0].Y, tolerance);
            Assert.AreEqual(53.158, d1.Circle.Vertices[50].X, tolerance);
            Assert.AreEqual(150.615, d1.Circle.Vertices[50].Y, tolerance);
        }

        [TestMethod]
        public void BoundingBoxTest()
        {
            Circle c1 = new Circle(8, 16, 100, new Colour(0, 0, 255));
            IPaintDrop d1 = PaintDropSimulationFactory.CreatePaintDrop(c1);
            float tolerance = 0.001f;

            Assert.AreEqual(-92, d1.BoundingBox.X);
            Assert.AreEqual(-84, d1.BoundingBox.Y);
            Assert.AreEqual(200, d1.BoundingBox.Width);
            Assert.AreEqual(200, d1.BoundingBox.Height);
        }
    }
}