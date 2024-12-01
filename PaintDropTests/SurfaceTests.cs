using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics;

namespace PaintDropTests
{
    [TestClass]
    public class SurfaceDropTests
    {
        [TestMethod]
        public void AddTest()
        {
            ISurface s = PaintDropSimulationFactory.CreateSurface(1280, 720);
            Circle c = new Circle(0, 50, 100, new Colour(0, 0, 255));

            Assert.AreEqual(0, s.Drops.Count);
            IPaintDrop d = PaintDropSimulationFactory.CreatePaintDrop(c);
            s.AddPaintDrop(d);
            Assert.AreEqual(d.Circle.Vertices[0], s.Drops.First().Circle.Vertices[0]);
            Assert.AreEqual(d.Circle.Vertices[50], s.Drops.First().Circle.Vertices[50]);
            Assert.AreEqual(d.Circle.Vertices[100], s.Drops.First().Circle.Vertices[100]);
        }
    }
}