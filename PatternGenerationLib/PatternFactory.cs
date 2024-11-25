namespace PatternGenerationLib
{
    public static class PatternFactory
    {
        public static IPatternGenerator CreatePhyllotaxis()
        {
            return new Phyllotaxis();
        }

        public static IPatternGenerator CreateSpiral()
        {
            return new Spiral();
        }
    }
}
