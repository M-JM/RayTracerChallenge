using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    public class Matrix
    {
        public int Row { get; set; }
        public int Col { get; set; }

        private double[,] _matrix;

        public Matrix(int row, int col)
        {
            Row = row;
            Col = col;
            _matrix = new double[row, col];
        }

        public double GetElement(int row, int col)
        {
            return _matrix[row, col];
        }
        
        public void InitializeMatrix(string setup)
        {
            {
                string[] rows = setup.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                for (int i = 0; i < Row; i++)
                {
                    string[] cols = rows[i].Replace("{", string.Empty).Replace("}", string.Empty).Replace(",",string.Empty).Split(new string[] { " " }, StringSplitOptions.None);
                    for (int j = 0; j < Col; j++)
                    {
                        _matrix[i, j] = double.Parse(cols[j]);
                    }
                }
            }
        }


    }
}
