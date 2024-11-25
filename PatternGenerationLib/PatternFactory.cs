namespace PatternGenerationLib
{
    public static class PatternFactory
    {
        public static IPatternGenerator CreatePhyllotaxis()
        {
            return new Phyllotaxis();
        }

        public static IPatternGenerator CreateHeart()
        {
            return new Heart();
        }
    }
}
