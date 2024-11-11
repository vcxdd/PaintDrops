using PaintDropSimulation;
using PatternGenerationLib;
using ShapeLibrary;

namespace PaintDropTests
{
    [TestClass]
    public class PatternGenerationTests
    {
        [TestMethod]
        public void CalcTest()
        {
            IPatternGenerator g = new Phyllotaxis();
            ISurface s = PaintDropSimulationFactory.CreateSurface(640, 480);
            Colour c = new Colour(255, 0, 0);
            s.GeneratePaintDropPattern(16, c);
            Vector? v = g.CalculatePatternPoint(s);


        }
    }
}