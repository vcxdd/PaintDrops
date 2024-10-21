using ShapeLibrary;
using System.Diagnostics;

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
            Vector C = other.Circle.Vertices[i];
            float r = other.Circle.Radius;

            Vector PminusC = P - C;
            float scale = (float)(Math.Sqrt((1 + (r * r) / Math.Sqrt(Math.Pow(Vector.Magnitude(PminusC), 2)))));
            Circle.Vertices[i] = C + PminusC * scale;
        }
    }
}
