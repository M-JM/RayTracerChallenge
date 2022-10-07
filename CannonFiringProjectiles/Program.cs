// See https://aka.ms/new-console-template for more information
using CannonFiringProjectiles;
using RayTracerChallenge;


var projectile = new Projectile(Tuples.CreatePoint(0f, 1f, 0f), Tuples.Normalize(Tuples.CreateVector(1f, 1f, 0f)));
var enviroment = new CannonFiringProjectiles.Environment(Tuples.CreateVector(0f, -0.1f, 0f), Tuples.CreateVector(-0.01f, 0f, 0f));

var cannon = new Cannon(enviroment, projectile, new List<double>(), new List<double>());

cannon.Fire();

Console.ReadKey();