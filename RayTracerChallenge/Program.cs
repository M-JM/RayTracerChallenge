// See https://aka.ms/new-console-template for more information
using RayTracerChallenge;

Console.WriteLine("Hello, World!");
Tuples _pointA = new Tuples(3f, -2f, 5f, 1f);
Tuples _pointB = new Tuples(-2f, 3f, 1f, 0f);


var expectedResult = new Tuples(1f, 1f, 6f, 1f);
bool result = expectedResult.Equals(_pointA + _pointB);
Console.WriteLine(result);
Console.ReadKey();