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
            if (surface == null) throw new ArgumentNullException("surface must not be null");

            float theta = _angleStep * _counter;
            Vector center = new Vector(surface.Width / 2f, surface.Height / 2f);
            double X = _scale * (16 * (Math.Pow(Math.Sin(_angleStep * _counter), 3)));
            double Y = _scale * (13 * (Math.Cos(theta) - 5 * Math.Cos(2 * theta) - 2 * Math.Cos(3 * theta) - Math.Cos(4 * theta)));
            
            Y = -Y; //flip the y axis so heart is upside right

            //Center the heart of the surface
            X = X + center.X;
            Y = Y + center.Y;

            _counter++;

            return new Vector((float)X, (float)Y);
        }

        public void Reset() => _counter = 0;
    }
}
