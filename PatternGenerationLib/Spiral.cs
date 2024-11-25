using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PatternGenerationLibTests")]
namespace PatternGenerationLib
{
    internal class Spiral : IPatternGenerator
    {
        private float _angleStep = 1;
        private float _counter = 0;
        private float _scale = 5;
        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null) throw new ArgumentNullException("surface must not be null");

            float theta = _angleStep * _counter;
            Vector center = new Vector(surface.Width / 2f, surface.Height / 2f);

            double X = center.X + _scale * _counter * (Math.Cos(theta));
            double Y = center.Y + _scale * _counter * (Math.Sin(theta));

            _counter++;

            return new Vector((float)X, (float)Y);
        }

        public void Reset() => _counter = 0;
    }
}
