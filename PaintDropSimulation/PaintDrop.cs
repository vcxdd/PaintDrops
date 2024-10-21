using ShapeLibrary;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PaintDropTests")]
namespace PaintDropSimulation;
internal class PaintDrop : IPaintDrop
{
    public ICircle Circle { get; }

    public PaintDrop(ICircle circle)
    {
        Circle = circle;
    }

    public void Marble(IPaintDrop other)
    {
        for (int i = 0; i < Circle.Vertices.Length; i++)
        {
            Vector P = Circle.Vertices[i];
            Vector C = other.Circle.Center;
            float r = other.Circle.Radius;

            Vector PminusC = P - C;
            Debug.Assert(PminusC.X == P.X - C.X);
            Debug.Assert(PminusC.Y == P.Y - C.Y);
            double MagnitudeSquared = Math.Pow(Vector.Magnitude(PminusC), 2);
            float scale = (float)(Math.Sqrt((1 + ((r * r) / MagnitudeSquared))));

            Circle.Vertices[i] = C + (PminusC * scale);
        }
    }
}
