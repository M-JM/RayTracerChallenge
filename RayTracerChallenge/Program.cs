// See https://aka.ms/new-console-template for more information
using RayTracerChallenge;

Canvas newCanvas = new Canvas(10, 2);
newCanvas.InitializeCanvas(new Color(1, 0.8, 0.6));
string header = newCanvas.BuildPPMHeader();
Console.WriteLine(header);
string body = newCanvas.BuildPPMData();
Console.WriteLine(body);
Console.ReadKey();