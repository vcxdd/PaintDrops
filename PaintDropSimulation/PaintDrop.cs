using ShapeLibrary;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PaintDropTests")]
namespace PaintDropSimulation;
internal class PaintDrop : IPaintDrop
{
    public ICircle Circle { get; }

    public IRectangle BoundingBox { get; }

    public PaintDrop(ICircle circle)
    {
        if (circle == null) throw new ArgumentException("circle must not be null");

        Circle = circle;
        BoundingBox = ShapesFactory.CreateRectangle(0, 0, 0, 0, new Colour(0, 0, 0));
    }

    public void Marble(IPaintDrop other)
    {
        if (other == null) throw new ArgumentException("other must not be null");

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

        float minX = Circle.Vertices[0].X;
        float minY = Circle.Vertices[0].Y;
        float maxX = Circle.Vertices[0].X;
        float maxY = Circle.Vertices[0].Y;

        for (int i = 1; i < Circle.Vertices.Length; i++)
        {
            minX = Math.Min(minX, Circle.Vertices[i].X);
            minY = Math.Min(minY, Circle.Vertices[i].Y);
            maxX = Math.Max(maxX, Circle.Vertices[i].X);
            maxY = Math.Max(maxY, Circle.Vertices[i].Y);
        }

        BoundingBox.Width = maxY - minY;
        BoundingBox.Height = maxX - minX;
        BoundingBox.X = minX;
        BoundingBox.Y = minY;
    }
}
