using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    // Used the class name Tuples since Tuple is an already existing class within the .NET framework
    // Alternativly i could have created Tuple class within its own namespace.

    public class Tuples
    {
        public float XAxis { get; private set; }
        public float YAxis { get; private set; }
        public float ZAxis { get; private set; }
        public float WAxis { get; private set; }

        public Tuples(float xAxis, float yAxis, float zAxis , float wAxis)
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

    }
}
