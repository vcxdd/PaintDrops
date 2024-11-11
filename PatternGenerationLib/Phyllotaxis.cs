using PaintDropSimulation;
using ShapeLibrary;

namespace PatternGenerationLib
{
    public class Phyllotaxis : IPatternGenerator
    {
        private const double _goldenAngle = (55 * Math.PI) / 72;
        private const float _scale = 20;

        public Phyllotaxis()
        {

        }

        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null) throw new ArgumentNullException("surface must not be null");

            Vector center = new Vector(surface.Width / 2f, surface.Height / 2f);
            float i = surface.Drops.Count() + 1;

            double x = center.X + _scale * Math.Sqrt(i) * Math.Cos(_goldenAngle * i);
            double y = center.Y + _scale * Math.Sqrt(i) * Math.Sin(_goldenAngle * i);

            return new Vector((float)x, (float)y);
        }
    }
}
