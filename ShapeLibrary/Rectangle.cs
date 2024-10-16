using System;
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
        private float _x;
        private float _y;
        private float _width;
        private float _height;
        private Vector[] _vertices;
        private Colour _colour;
        public float X => _x;

        public float Y => _y;

        public float Width => _width;

        public float Height => _height;

        public Vector[] Vertices => _vertices;

        public Colour Colour => _colour;

        public Rectangle(float x, float y, float width, float height, Colour color)
        {
            if (x <= 0 || y <= 0 || width <= 0 || height <= 0) throw new ArgumentException("Values cannot be 0 or less.");
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
            this._colour = color;
            this._vertices = new Vector[4];
            CalculateVertices();
        }

        private void CalculateVertices()
        {
            this.Vertices[0] = new Vector(X, Y);
            this.Vertices[1] = new Vector(X + _width, Y);
            this.Vertices[2] = new Vector(X + _width, Y + _height);
            this.Vertices[3] = new Vector(X, Y + _height);
        }
    }
}
