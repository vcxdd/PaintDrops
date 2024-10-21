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
            Assert.AreEqual(103.330, d1.Circle.Vertices[50].X, tolerance);
            Assert.AreEqual(46.201, d1.Circle.Vertices[50].Y, tolerance);

            d1.Marble(d2);

            Assert.AreEqual(151.561, d1.Circle.Vertices[0].X, tolerance);
            Assert.AreEqual(16, d1.Circle.Vertices[0].Y, tolerance);
            Assert.AreEqual(144.444, d1.Circle.Vertices[50].X, tolerance);
            Assert.AreEqual(60.257, d1.Circle.Vertices[50].Y, tolerance);
        }
    }
}