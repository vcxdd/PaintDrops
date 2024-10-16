using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
namespace ShapeLibrary
{
    internal class Circle : ICircle
    {
        private float _radius;
        public float Radius => _radius;

        private Vector _center;
        public Vector Center => _center;

        private Vector[] _vertices;
        public Vector[] Vertices => _vertices;

        private Colour _colour;
        public Colour Colour => _colour;

        private const int _numVertices = 100;
        public int NumVertices => _numVertices;

        public Circle(float x, float y, float radius, Colour color)
        {
            if (radius <= 0) throw new ArgumentException("Radius cannot be 0 or less");

            this._center = new Vector(x, y);
            this._radius = radius;
            this._colour = color;
            this._vertices = new Vector[_numVertices];
            CalculateVertices(_numVertices);
        }

        private void CalculateVertices(float n)
        {
            for (int i = 0; i < n; i++)
            {
                float Xn = (float)(this._center.X + this._radius * Math.Cos(i * ((2 * Math.PI) / n)));
                float Yn = (float)(this._center.Y + this._radius * Math.Sin(i * ((2 * Math.PI) / n)));
                _vertices[i] = new Vector(Xn, Yn);
            }
        }
    }
}
