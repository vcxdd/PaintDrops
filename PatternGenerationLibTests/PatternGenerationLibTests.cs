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
            IPatternGenerator g = PatternFactory.CreatePhyllotaxis();
        }
    }
}