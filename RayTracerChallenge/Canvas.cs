using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    //REFACTOR : move all PPM related methods in a seperate class as utility ?

    public class Canvas
    {

        
        public int Width { get; set; }

        public int Height { get; set; }

        private Color[,] _pixels;

        public Canvas(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            _pixels = new Color[width, height];
            InitializeCanvas(new Color(0,0,0));
        }

        public Color GetPixel(int x, int y)
        {
            return _pixels[x, y];
        }

        public void WritePixel(int x, int y, Color color)
        {
            _pixels[x, y] = color;
        }

        public void InitializeCanvas(Color color)
        {
            {
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        _pixels[i, j] = color;
                    }
                }
            }
        }

        public string BuildPPMHeader()
        {
            string header = "P3" + Environment.NewLine + Width + " " + Height + Environment.NewLine + "255";

            return header;
        }

        public string BuildPPMData()
        {
            string data = "";
            for (int i = 0; i < Height; i++)
            {

                data +=AppendPPMLine(i);
               
                data = data.TrimEnd();
                data += Environment.NewLine;
            }
            
           
            
            return data;
        }

        public string PPMFile()
        {
            return BuildPPMHeader() + Environment.NewLine + BuildPPMData();
        }

        public async Task WritePPMToFileAsync()
        {
            string PPM = PPMFile();

            await File.WriteAllTextAsync("PPM.text", PPM);


        }
        
        public string AppendPPMLine(int j)
        {
            string fullLine = "";
            for (int i = 0; i < Width; i++)
            {
               fullLine += ConvertColorInInt(_pixels[i, j].Red) + " " + ConvertColorInInt(_pixels[i, j].Green) + " " + ConvertColorInInt(_pixels[i, j].Blue) + " ";
            }
            string result = StringCheckRecursion(fullLine,"");



            return result;
        }

        //REFACTOR : Using recursion here is slow and not efficient.
        // change this to a loop and use a stringbuilder

        public string StringCheckRecursion(string line, string resultR)
        {
            string result = resultR;
            string newLine = line;
            if (line.Length > 70)
            {
                if (newLine[69] == ' ')
                {
                    resultR += string.Concat(newLine.AsSpan(0, 69), Environment.NewLine);
                    newLine = newLine.Remove(0, 69);
                    return StringCheckRecursion(newLine,resultR);

                }
                else
                {
                    for (int i = 70; i >= 0; i-- )
                    {
                        if (newLine[i-1] == ' ')
                        {
                            resultR += string.Concat(newLine.AsSpan(0, i), Environment.NewLine);
                            newLine = newLine.Remove(0, i).TrimStart();
                            return StringCheckRecursion(newLine, resultR);
                            
                        }  
                    }
                   
                }
            }
            else
            {
                result += string.Concat(newLine.AsSpan(0, line.Length-1), Environment.NewLine);
            }
            return result;
        }

        // REFACTOR : This method could be in a seperate class as utility
        // REFACTOR : Checking the floor and ceiling can be done via Math class method. Remove the if statement.

        public static int ConvertColorInInt(double colorValue)
        {
            int result = (int)Math.Round(colorValue * 255, MidpointRounding.AwayFromZero);

            if (result > 255)
            {
                result = 255;
            }
            else if (result < 0)
            {
                result = 0;
            }

            return result;
            
        }
    }

}
