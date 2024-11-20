using PaintDropSimulation;
using ShapeLibrary;
using System.Diagnostics;

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

        SingleTest(widths, heights, circle);
        AverageTest(widths, heights, circle);
    }

    private static void SingleTest(int[] widths, int[] heights, ICircle circle)
    {
        Console.WriteLine("===== ELAPSED TIME =====");
        int inc = 5;
        for (int i = 0; i < 4; i++)
        {
            long elapsedTime = Bench(() =>
            {
                ISurface surface = PaintDropSimulationFactory.CreateSurface(widths[i], heights[i]);
                for (int j = 0; j < inc; j++)
                {
                    surface.AddPaintDrop(PaintDropSimulationFactory.CreatePaintDrop(circle));
                }
            });
            Console.WriteLine($"\nElapsed time for {widths[i]}x{heights[i]} with {inc} paint drops: {elapsedTime}ms");
            inc += 5;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static void AverageTest(int[] widths, int[] heights, ICircle circle)
    {
        Console.WriteLine("\n===== AVERAGE ELAPSED TIME =====");
        int inc = 5;
        for (int i = 0; i < 4; i++)
        {
            long elapsedTime = 0;
            for (int j = 0; j < 5; j++)
            {
                elapsedTime += Bench(() =>
                {
                    ISurface surface = PaintDropSimulationFactory.CreateSurface(widths[i], heights[i]);
                    for (int j = 0; j < inc; j++)
                    {
                        surface.AddPaintDrop(PaintDropSimulationFactory.CreatePaintDrop(circle));
                    }
                });
            }
            Console.WriteLine($"\nAverage time for {widths[i]}x{heights[i]} with {inc} paint drops: {elapsedTime / 5}ms");
            inc += 5;
        }
    }

    private static long Bench(Action task)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        task?.Invoke();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
