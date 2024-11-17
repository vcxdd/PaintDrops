using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib
{
    public static class PatternFactory
    {
        public static IPatternGenerator CreatePhyllotaxis()
        {
            return new Phyllotaxis();
        }
    }
}
