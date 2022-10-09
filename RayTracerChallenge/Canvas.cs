using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
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

    }
}
