using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    public class Color
    {
        public double Red { get; set; }

        public double Green { get; set; }

        public double Blue { get; set; }


        public Color(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public static Color operator +(Color a, Color b)
        {
            return new Color(a.Red + b.Red, a.Green + b.Green, a.Blue + b.Blue);
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color(a.Red - b.Red, a.Green - b.Green, a.Blue - b.Blue);
        }

        public static Color operator *(Color a, Color b)
        {
            return new Color(a.Red * b.Red, a.Green * b.Green, a.Blue * b.Blue);
        }

        public static Color operator *(double scalar, Color a)
        {
            return new Color(a.Red * scalar, a.Green * scalar, a.Blue * scalar);
        }

        public static Color operator *(Color a, double scalar)
        {
            return new Color(a.Red * scalar, a.Green * scalar, a.Blue * scalar);
        }

        // TODO implement equality properly for Color

        public override bool Equals(object? obj)
        {
            Color t = obj as Color;
            Color self = this as Color;
            
            if(t == null || self == null)
            {
                return false;
            }
            else
            {
                return (
                    t.Green.isEqualD(this.Green) &&
                    t.Red.isEqualD(this.Red) &&
                    t.Blue.isEqualD(this.Blue)
                    );
            }

        }

    }
}
