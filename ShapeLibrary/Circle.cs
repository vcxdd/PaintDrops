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
        public float Radius { get; }

        public Vector Center { get;  }

        public Vector[] Vertices { get; }

        public Colour Colour { get; }

        public Circle(float x, float y, float radius, Colour color)
        {
            if (x < 0 || y < 0 || radius <= 0) throw new ArgumentException("Values cannot be 0 and/or less");

            this.Center = new Vector(x, y);
            this.Radius = radius;
            this.Colour = color;
            this.Vertices = new Vector[100];
            CalculateVertices(100);
        }

        private void CalculateVertices(float n)
        {
            for (int i = 0; i < n; i++)
            {
                float Xn = (float)(this.Center.X + this.Radius * Math.Cos(i * ((2 * Math.PI) / n)));
                float Yn = (float)(this.Center.Y + this.Radius * Math.Sin(i * ((2 * Math.PI) / n)));
                Vertices[i] = new Vector(Xn, Yn);
            }
        }
    }
}
