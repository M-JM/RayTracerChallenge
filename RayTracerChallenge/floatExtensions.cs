using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    // TODO rename class to something more appropriate since we are using it for more than just floats

    public static class floatExtensions
    {
        private const float Epsilon = 0.0001f;

        public static bool IsEqualF(this float a, float b)
        {
            return Math.Abs(a - b) <= Epsilon;
        }

        public static bool isEqualD(this double a, double b)
        {
            return Math.Abs(a - b) <= Epsilon;
        }

    }
}
