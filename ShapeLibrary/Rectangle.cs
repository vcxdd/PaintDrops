﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    internal class Rectangle : IRectangle
    {
        public float X { get; }

        public float Y { get; }

        public float Width { get; }

        public float Height { get; }

        public Vector[] Vertices { get; }

        public Colour Colour { get; }

        public Rectangle(float x, float y, float width, float height, Colour color)
        {
            if (width <= 0 || height <= 0) throw new ArgumentException("Values cannot be 0 or less.");
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Colour = color;
            this.Vertices = new Vector[4];
            CalculateVertices();
        }

        private void CalculateVertices()
        {
            this.Vertices[0] = new Vector(X, Y);
            this.Vertices[1] = new Vector(X + Width, Y);
            this.Vertices[2] = new Vector(X + Width, Y + Height);
            this.Vertices[3] = new Vector(X, Y + Height);
        }

        public bool Intersect(IRectangle rectangle)
        {
            if (rectangle == null) throw new ArgumentNullException("rectangle must not be null.");

            if (X + Width <= rectangle.X || X >= rectangle.X + rectangle.Width) return false;
            if (Y + Height <= rectangle.Y || Y >= rectangle.Y + rectangle.Height) return false;

            return true;
        }
    }
}
