using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics;

namespace PatternGenerationLib
{
    internal class Phyllotaxis : IPatternGenerator
    {
        private const double _goldenAngle = (55 * Math.PI) / (double) 72;
        private const float _scale = 20;
        private float _counter = 0;

        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null) throw new ArgumentNullException("surface must not be null");

            Vector center = new Vector(surface.Width / 2f, surface.Height / 2f);
            _counter++;

            double x = center.X + _scale * Math.Sqrt(_counter) * Math.Cos(_goldenAngle * _counter);
            double y = center.Y + _scale * Math.Sqrt(_counter) * Math.Sin(_goldenAngle * _counter);

            return new Vector((float)x, (float)y);
        }

        public void Reset() => _counter = 0;
    }
}
