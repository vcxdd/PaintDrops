﻿using ShapeLibrary;
using System.Diagnostics;

namespace PaintDropSimulation
{
    internal class Surface : ISurface
    {
        public int Width { get; }

        public int Height { get; }

        public List<IPaintDrop> Drops { get; }

        public IRectangle Border { get; }

        public Surface(int width, int height)
        {
            if (width <= 0 || height <= 0) throw new ArgumentException("width and height must be positive");
            Width = width;
            Height = height;
            Drops = new List<IPaintDrop>();
            Border = ShapesFactory.CreateRectangle(0, 0, width, height, new Colour(0, 0, 0));
        }

        public event CalculatePatternPoint PatternGeneration;

        public void AddPaintDrop(IPaintDrop drop)
        {
            if (drop == null) throw new ArgumentNullException("drop must not be null");

            /* Changed to Parallel.ForEach to loop through the drops in parallel.
             * At first, there might not be many drops, but eventually when the drops increase,
             * it makes more sense to loop in parallel the drops.
             * 
             * Impact: Slight performance increase at first, more noticeable with more drops.
            */
            //Parallel.ForEach(Drops, d => d.Marble(drop));

            foreach(IPaintDrop d in Drops) d.Marble(drop);

            Drops.Add(drop);

            List<IPaintDrop> toRemove = new List<IPaintDrop>();
            foreach (IPaintDrop d in Drops)
            {
                if (!d.BoundingBox.Intersect(Border))
                {
                    toRemove.Add(d);
                }
            }

            foreach (IPaintDrop d in toRemove)
            {
                Drops.Remove(d);
            }
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
