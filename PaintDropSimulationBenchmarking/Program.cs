using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        Colour color = new Colour(255, 0, 0);
        Random random = new Random();
        ICircle circle = ShapesFactory.CreateCircle(random.Next(500), random.Next(500), 8, color);
        int[] widths = new int[4];
        int[] heights = new int[4];

        widths[0] = 640;
        widths[1] = 1280;
        widths[2] = 1920;
        widths[3] = 2560;

        heights[0] = 480;
        heights[1] = 720;
        heights[2] = 1080;
        heights[3] = 1440;

        int inc = 5;
        for(int i = 0; i < 4; i++)
        {
            Bench(() =>
            {
                ISurface surface = PaintDropSimulationFactory.CreateSurface(widths[i], heights[i]);
                for (int i = 0; i < inc; i++)
                {
                    surface.AddPaintDrop(PaintDropSimulationFactory.CreatePaintDrop(circle));
                }
                Console.WriteLine($"\nSurface: {surface.Width}x{surface.Height} with {surface.Drops.Count} added drops.");
                inc += 5;
            });
        }
    }

    private static void Bench(Action task)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        task?.Invoke();
        stopwatch.Stop();
        Console.WriteLine($"\nTime Elapsed: {stopwatch.ElapsedMilliseconds}ms");
        Console.ReadKey();
    }
}
