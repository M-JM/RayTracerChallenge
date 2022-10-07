using RayTracerChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonFiringProjectiles
{
    public class Environment
    {
        public Tuples Gravity{ get; set; }

        public Tuples Wind { get; set; }

        public Environment(Tuples gravity, Tuples wind)
        {
            this.Gravity = gravity;
            this.Wind = wind;
        }
               
    }
}
