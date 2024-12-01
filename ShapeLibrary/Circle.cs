using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]
[assembly: InternalsVisibleTo("PaintDropTests")]
namespace ShapeLibrary
{
    internal class Circle : ICircle
    {
        public float Radius { get;  }

        public Vector Center { get; }

        private Lazy<Vector[]> _vertices;

        public Vector[] Vertices => _vertices.Value;

        public Colour Colour { get; }

        /*
         * Change to the number of vertices from 1024 (max) to 256 (from ShapesRenderer),
         * with less vertices, the circle will look less smooth but will run faster and number of
         * drops placed can be much higher
         * 
         * Performance: Overall positive with slight loss of smoothness on circles
         */
        public const int _numVertices = 100;

        public Circle(float x, float y, float radius, Colour color)
        {
            if (radius <= 0) throw new ArgumentException("Radius cannot be 0 or less");

            this.Center = new Vector(x, y);
            this.Radius = radius;
            this.Colour = color;
            this._vertices = new Lazy<Vector[]>(() =>
            {
                return CalculateVertices(_numVertices);
            });
        }

        private Vector[] CalculateVertices(int n)
        {
            Vector[] v = new Vector[n];
            for (int i = 0; i < n; i++)
            {
                float Xn = (float)(this.Center.X + this.Radius * Math.Cos(i * ((2 * Math.PI) / n)));
                float Yn = (float)(this.Center.Y + this.Radius * Math.Sin(i * ((2 * Math.PI) / n)));
                v[i] = new Vector(Xn, Yn);
            }

            return v;
        }
    }
}
