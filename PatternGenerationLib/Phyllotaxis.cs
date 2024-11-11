using PaintDropSimulation;
using ShapeLibrary;

namespace PatternGenerationLib
{
    public class Phyllotaxis : IPatternGenerator
    {
        private const double _goldenAngle = (55 * Math.PI) / 72;
        private const float _scale = 15;
        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null) throw new ArgumentNullException("surface must not be null");

            Vector center = new Vector((float)surface.Width/(float)2, (float)surface.Height/(float)2);

            double x = center.X + _scale * Math.Sqrt(0) * Math.Cos(_goldenAngle * 0);
            double y = center.Y + _scale * Math.Sqrt(0) * Math.Sin(_goldenAngle * 0);

            return new Vector((float)x, (float)y);
        }
    }
}
