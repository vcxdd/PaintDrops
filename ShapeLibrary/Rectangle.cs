using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    sealed class Rectangle : IRectangle
    {
        /// <summary>
        /// The x coord of the upper left corner of the rectangle
        /// </summary>
        public float X { get; }

        /// <summary>
        /// The y coord of the upper left corner of the rectangle
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// The width of the rectangle
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// The height of the rectangle
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// The vertices that make up the shape.
        /// The list of vertices is created automatically when the property is accessed and cached
        /// </summary>
        public Vector[] Vertices { get; }

        /// <summary>
        /// The color of the shape
        /// </summary>
        public Colour Colour { get; }

        public Rectangle(float x, float y, float width, float height, Colour color)
        {
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
    }
}
