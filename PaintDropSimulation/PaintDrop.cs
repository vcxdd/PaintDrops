using ShapeLibrary;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PaintDropTests")]
namespace PaintDropSimulation;
internal class PaintDrop : IPaintDrop
{
    public ICircle Circle { get; }

    public IRectangle BoundingBox { get; private set; }

    public PaintDrop(ICircle circle)
    {
        if (circle == null) throw new ArgumentException("circle must not be null");

        Circle = circle;
        BoundingBox = ShapesFactory.CreateRectangle(0, 0, 1, 1, new Colour(0, 0, 0));
        CalculateBoundingBox();
    }

    public void CalculateBoundingBox()
    {
        var minX = Circle.Vertices.Min(v => v.X);
        var minY = Circle.Vertices.Min(v => v.Y);
        var maxX = Circle.Vertices.Max(v => v.X);
        var maxY = Circle.Vertices.Max(v => v.Y);

        BoundingBox = ShapesFactory.CreateRectangle(minX, minY, maxX - minX, maxY - minY, new Colour(0, 0, 0));
    }

    public void Marble(IPaintDrop other)
    {
        if (other == null) throw new ArgumentException("other must not be null");

        /*
         * Changed to Parallel.For to loop through the vertices in parallel and compute
         * marble formula to each vertices in parallel. With the huge amount of vertices,
         * I use to draw a circle, it makes to loop through the vertices in parallel.
         * 
         * Performance: Overall better performance
         */
        Parallel.For(0, Circle.Vertices.Length, i =>
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

            CalculateBoundingBox();
        });
    }
}
