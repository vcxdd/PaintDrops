using ShapeLibrary;

namespace PaintDropSimulation
{
    public delegate Vector? CalculatePatternPoint(ISurface surface);
    public interface ISurface
    {
        /// <summary>
        /// Width of the surface
        /// </summary>
        int Width { get; }
        /// <summary>
        /// Height of the surface
        /// </summary>
        int Height { get; }

        /// <summary>
        /// The paint drops in the surface
        /// </summary>
        List<IPaintDrop> Drops { get; }

        event EventHandler PatternGeneration;

        /// <summary>
        /// Adds a new paint drop to the surface and performs the marbling of all the paint drops
        /// </summary>
        /// <param name="drop">The new drop to be added to the surface</param>
        void AddPaintDrop(IPaintDrop drop);

        void GeneratePaintDropPattern(float radius, Colour colour);
    }
}
