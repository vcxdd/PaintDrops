using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PatternGenerationLibTests")]
namespace PatternGenerationLib
{
    internal class Heart : IPatternGenerator
    {
        private float _angleStep = 0.275f;
        private float _counter = 0;
        private float _scale = 15;
        public Vector? CalculatePatternPoint(ISurface surface)
        {
            throw new NotImplementedException();
        }

        public void Reset() => _counter = 0;
    }
}
