using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    // REFACTOR Used the class name Tuples since Tuple is an already existing class within the .NET framework
    // Alternativly i could have created Tuple class within its own namespace.

    // REFACTOR maybe Struct is a more approriate data type for Tuples

    public class Tuples
    {
        public float XAxis { get; private set; }
        public float YAxis { get; private set; }
        public float ZAxis { get; private set; }
        public float WAxis { get; private set; }

        public Tuples(float xAxis, float yAxis, float zAxis, float wAxis)
        {
            this.XAxis = xAxis;
            this.YAxis = yAxis;
            this.ZAxis = zAxis;
            this.WAxis = wAxis;
        }

        public static Tuples CreatePoint(float xAxis, float yAxis, float zAxis)
        {
            return new Tuples(xAxis, yAxis, zAxis, 1.0f);
        }


        public static Tuples CreateVector(float xAxis, float yAxis, float zAxis)
        {
            return new Tuples(xAxis, yAxis, zAxis, 0.0f);
        }

        public bool IsPoint()
        {
            return this.WAxis == 1.0f;
        }

        public bool IsVector()
        {
            return this.WAxis == 0.0f;
        }


        #region Operations

        private static Tuples Add(Tuples a, Tuples b)
        {
           
                if (a == null || b == null)
                {
                    throw new ArgumentNullException();
                }
                else if (a.IsPoint() && b.IsPoint())
                {
                    throw new ArgumentException("Cannot add two points together");
                }
                else
                {
                    return new Tuples(a.XAxis + b.XAxis, a.YAxis + b.YAxis, a.ZAxis + b.ZAxis, a.WAxis + b.WAxis);
                }
                       
        }

        private static Tuples Substract(Tuples a, Tuples b)
        {
            
                if (a == null || b == null)
                {
                    throw new ArgumentNullException();
                }
                else if (a.IsVector() && b.IsPoint())
                {
                    throw new ArgumentException("Cannot substract a point from a vector");

                }
                else
                {
                    return new Tuples(a.XAxis - b.XAxis, a.YAxis - b.YAxis, a.ZAxis - b.ZAxis, a.WAxis - b.WAxis);
                }
                      
        }

        public static Tuples operator -(Tuples a)
        {
            return new Tuples(-a.XAxis, -a.YAxis, -a.ZAxis, -a.WAxis);
        }

        public static Tuples operator +(Tuples a, Tuples b)
        {
            return Add(a, b);
        }

        public static Tuples operator -(Tuples a, Tuples b)
        {
            return Substract(a, b);
        }

        public static Tuples operator *(Tuples a, float b)
        {
            return new Tuples(a.XAxis * b, a.YAxis * b, a.ZAxis * b, a.WAxis * b);
        }

        public static Tuples operator /(Tuples a, float b)
        {
            return new Tuples(a.XAxis / b, a.YAxis / b, a.ZAxis / b, a.WAxis / b);
        }

        public static float Magnitude(Tuples a)
        {
            return (float)Math.Sqrt((a.XAxis * a.XAxis) + (a.YAxis * a.YAxis) + (a.ZAxis * a.ZAxis) + (a.WAxis * a.WAxis));
        }
        public static Tuples Normalize(Tuples a)
        {
            float magnitude = Magnitude(a);
            return new Tuples(a.XAxis / magnitude, a.YAxis / magnitude, a.ZAxis / magnitude, a.WAxis / magnitude);
        }

        public static float DotProduct(Tuples a, Tuples b)
        {
            return (a.XAxis * b.XAxis) + (a.YAxis * b.YAxis) + (a.ZAxis * b.ZAxis) + (a.WAxis * b.WAxis);
        }

        public static Tuples CrossProduct(Tuples a, Tuples b)
        {
            return CreateVector(
                (a.YAxis * b.ZAxis) - (a.ZAxis * b.YAxis),
                (a.ZAxis * b.XAxis) - (a.XAxis * b.ZAxis),
                (a.XAxis * b.YAxis) - (a.YAxis * b.XAxis)
                );
        }


        #endregion

        #region Equality

        // TODO implement Equality properly for Tuples

        public override bool Equals(object obj)
        {
            Tuples t = obj as Tuples;
            Tuples self = this as Tuples;
            if (t == null || self == null)
            {
                return false;
            }
            else
            {
                return (t.XAxis.IsEqualF(self.XAxis)
                    && t.YAxis.IsEqualF(self.YAxis)
                    && t.ZAxis.IsEqualF(self.ZAxis)
                    && t.WAxis.IsEqualF(self.WAxis));
            }
        }

        #endregion

    }
}
