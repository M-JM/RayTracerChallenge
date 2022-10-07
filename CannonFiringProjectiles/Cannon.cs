﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonFiringProjectiles
{
    public class Cannon
    {
        public Environment Environment { get; set; }
        public Projectile Projectile { get; set; }

        public int TickCounter { get; set; }

        public IList<double> XPositions { get; set; }

        public IList<double> YPositions { get; set; }

        public Cannon(Environment environment, Projectile projectile, IList<double> xPositions, IList<double> yPositions)
        {
            this.Environment = environment;
            this.Projectile = projectile;
            this.XPositions = xPositions;
            this.YPositions = yPositions;
        }
    
        public Projectile Tick()
        {
            Projectile.Position = Projectile.Position + Projectile.Velocity;
            Projectile.Velocity = Projectile.Velocity + Environment.Gravity + Environment.Wind;

            return Projectile;
  
        }

        public void Fire()
        {
  
            while (Projectile.Position.YAxis >= 0)
            {
                Tick();
                TickCounter++;
                XPositions.Add(Projectile.Position.XAxis);
                YPositions.Add(Projectile.Position.YAxis);
                Console.WriteLine($"Tick {TickCounter} - Projectile Position: {Projectile.Position.XAxis}, {Projectile.Position.YAxis}, {Projectile.Position.ZAxis}");
            }
            Plot();
        }

        public void Plot()
        {
            var plt = new ScottPlot.Plot(600, 400);
            plt.AddScatter(XPositions.ToArray(), YPositions.ToArray());
            Console.WriteLine($"image of projectile trajectory can be found here : " + plt.SaveFig("cannon.png"));
        }
        


    }
}
