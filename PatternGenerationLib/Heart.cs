using PaintDropSimulation;
using ShapeLibrary;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PatternGenerationLibTests")]
namespace PatternGenerationLib
{
    internal class Heart : IPatternGenerator
    {
        private const double _angleStep = 0.275;
        private const float _scale = 10;
        private float _counter = 0;

        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null) throw new ArgumentNullException("surface must not be null");

            Vector center = new Vector(surface.Width / 2f, surface.Height / 2f);
            double theta = _angleStep * _counter;

            double x = _scale * 16 * (Math.Sin(theta) * Math.Sin(theta) * Math.Sin(theta));
            double y = _scale * (13 * Math.Cos(theta) - 5 * Math.Cos(2 * theta) - 2 * Math.Cos(3 * theta) - Math.Cos(4 * theta));

            y = -y;
            x += center.X;
            y += center.Y;
            _counter++;

            return new Vector((float)x, (float)y);
        }

        public void Reset() => _counter = 0;
    }
}
