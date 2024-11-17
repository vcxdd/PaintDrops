using PaintDropSimulation;
using PatternGenerationLib;
using Moq;
using ShapeLibrary;

namespace PaintDropTests
{
    [TestClass]
    public class PatternGenerationTests
    {
        [TestMethod]
        public void CalcTest()
        {
            var surfaceMock = new Mock<ISurface>();
            surfaceMock.Setup(s => s.Width).Returns(1280);
            surfaceMock.Setup(s => s.Height).Returns(720);
            Phyllotaxis p = new Phyllotaxis();

            Vector? v1 = p.CalculatePatternPoint(surfaceMock.Object);
            Vector? v2 = p.CalculatePatternPoint(surfaceMock.Object);
            Vector? v3 = p.CalculatePatternPoint(surfaceMock.Object);

            Assert.IsNotNull(v1);
            Assert.AreEqual(625.25, v1.Value.X, 0.1);
            Assert.AreEqual(373.51, v1.Value.Y, 0.1);

            Assert.IsNotNull(v2);
            Assert.AreEqual(642.47, v2.Value.X, 0.1);
            Assert.AreEqual(331.82, v2.Value.Y, 0.1);

            Assert.IsNotNull(v3);
            Assert.AreEqual(661.09, v3.Value.X, 0.1);
            Assert.AreEqual(387.48, v3.Value.Y, 0.1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "surface must not be null")]
        public void NullTest()
        {
            Phyllotaxis p = new Phyllotaxis();

            Vector? v = p.CalculatePatternPoint(null);
        }
    }
}