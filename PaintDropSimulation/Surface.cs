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

            int i = 0;
            while (i < 100)
            {
                Vector? v = PatternGeneration?.Invoke(this);
                Random random = new Random();
                int red = random.Next(255);
                int green = random.Next(255);
                int blue = random.Next(255);

                colour = new Colour(red, green, blue);

                if (v.HasValue)
                {
                    float x = (float)Width / (float)2;
                    float y = (float)Height / (float)2;
                    ICircle circle = ShapesFactory.CreateCircle(v.Value.X, v.Value.Y, radius, colour);
                    IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
                    AddPaintDrop(drop);
                }
                i++;
            }
        }
    }
}
