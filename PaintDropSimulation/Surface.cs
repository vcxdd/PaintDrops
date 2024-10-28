using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddPaintDrop(IPaintDrop drop)
        {
            if (drop == null) throw new ArgumentNullException("drop must not be null");

            foreach(IPaintDrop d in Drops)
            {
                d.Marble(drop);
            }

            Drops.Add(drop);
        }
    }
}
