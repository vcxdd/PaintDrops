using PaintDropSimulation;

internal class Program
{
    private static void Main(string[] args)
    {
        ISurface a = PaintDropSimulationFactory.CreateSurface(640, 480);
        ISurface b = PaintDropSimulationFactory.CreateSurface(1000, 1000);
        ISurface c = PaintDropSimulationFactory.CreateSurface(1280, 720);
        ISurface d = PaintDropSimulationFactory.CreateSurface(1920, 1080);
    }
}
