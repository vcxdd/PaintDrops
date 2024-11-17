using ShapeLibrary;

namespace PaintDropSimulation
{
    internal class Surface : ISurface
    {
        public int Width { get; }

        public int Height { get; }

        public List<IPaintDrop> Drops { get; }

        public Surface(int width, int height)
        {
            if (width <= 0 || height <= 0) throw new ArgumentException("width and height must be positive");
            Width = width;
            Height = height;
            Drops = new List<IPaintDrop>();
        }

        public event CalculatePatternPoint PatternGeneration;

        public void AddPaintDrop(IPaintDrop drop)
        {
            if (drop == null) throw new ArgumentNullException("drop must not be null");

            foreach(IPaintDrop d in Drops)
            {
                d.Marble(drop);
            }

            Drops.Add(drop);
        }

        public void GeneratePaintDropPattern(float radius, Colour colour)
        {
            if (radius <= 0) throw new ArgumentException("radius must be positive");
            if (PatternGeneration == null) throw new ArgumentNullException("PatternGeneration must not be null");

            Vector? v = PatternGeneration?.Invoke(this);

            if (v.HasValue)
            {
                ICircle circle = ShapesFactory.CreateCircle(v.Value.X, v.Value.Y, radius, colour);
                IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
                AddPaintDrop(drop);
            }
        }
    }
}
