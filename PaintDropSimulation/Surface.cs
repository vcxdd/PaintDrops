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

        public event EventHandler PatternGeneration;

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

            float x = (float)Width / (float)2;
            float y = (float)Height / (float)2;
            ICircle circle = ShapesFactory.CreateCircle(x, y, radius, colour);
            IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            AddPaintDrop(drop);

            PatternGeneration?.Invoke(this, EventArgs.Empty);
        }
    }
}
