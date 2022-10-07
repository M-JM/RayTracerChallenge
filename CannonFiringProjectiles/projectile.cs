using RayTracerChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonFiringProjectiles
{
    public class Projectile
    {
        // this shows the problem of having static factory methods in Tuples class
        // it is not clear what the difference is between Point and Vector
        // position is a point
        // velocity is a vector

        // Should be refactored during refactor run so there is no ambiguity possible

        public Tuples Position { get; set; }

        public Tuples Velocity { get; set; }


        public Projectile(Tuples position, Tuples velocity)
        {
            this.Position = position;
            this.Velocity = velocity;
        }
        
    }
}
