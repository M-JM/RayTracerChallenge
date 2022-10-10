// See https://aka.ms/new-console-template for more information
using CannonFiringProjectiles;
using RayTracerChallenge;


var projectile = new Projectile(Tuples.CreatePoint(1f, 10f, 0f), Tuples.Normalize(Tuples.CreateVector(1f, 1.8f, 0f))*11.25f);
var enviroment = new CannonFiringProjectiles.Environment(Tuples.CreateVector(0f, -0.5f, 0f), Tuples.CreateVector(-0.02f, 0f, 0f));

var cannon = new Cannon(enviroment, projectile, new List<double>(), new List<double>());

//cannon.Fire();
await cannon.PlotOnCanvasAsync(900,550);


Console.WriteLine("enter a key");
Console.ReadKey();