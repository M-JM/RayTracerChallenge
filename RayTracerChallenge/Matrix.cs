using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    public class Matrix: IEquatable<Matrix>
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

        public override bool Equals(object? obj)
        {
            if (obj is not Matrix || obj is null)
            {
                return false;
            }
            Matrix other = (Matrix)obj;
            return this.Equals(other);

        }

       
        public bool Equals(Matrix? x)
        {
          
            if (x.Row != this.Row || x.Col != this.Col)
            {
                return false;
            }
            else if (x.Row == this.Row && x.Col == this.Col)
            {
                for (int i = 0; i < x.Row; i++)
                {
                    for (int j = 0; j < x.Col; j++)
                    {
                        if (x.GetElement(i, j) != this.GetElement(i, j))
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool operator ==(Matrix x, Matrix y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Matrix x, Matrix y)
        {
            return x.Equals(y);
        }

        public static Matrix operator *(Matrix x, Matrix y)
        {
            Matrix result = new Matrix(x.Row, y.Col);
            for (int i = 0; i < x.Row; i++)
            {
                for (int j = 0; j < y.Col; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < x.Col; k++)
                    {
                        sum += x.GetElement(i, k) * y.GetElement(k, j);
                    }
                    result._matrix[i, j] = sum;
                }
            }
            return result;
        }
        public static Tuples operator *(Matrix x, Tuples y)
        {
            {
                return new Tuples(
                    (float)((y.XAxis * x._matrix[0, 0]) + (y.YAxis * x._matrix[0, 1]) 
                    + (y.ZAxis * x._matrix[0, 2]) + (y.WAxis * x._matrix[0, 3])),
                                
                    (float)((y.XAxis * x._matrix[1, 0])+(y.YAxis * x._matrix[1, 1])
                    + (y.ZAxis * x._matrix[1, 2]) + (y.WAxis * x._matrix[1, 3])),
                                 
                    (float)((y.XAxis * x._matrix[2, 0]) +(y.YAxis * x._matrix[2, 1])
                    + (y.ZAxis * x._matrix[2, 2]) + (y.WAxis * x._matrix[2, 3])),
                                 
                    (float)((y.XAxis * x._matrix[3, 0]) +(y.YAxis * x._matrix[3, 1])
                    + (y.ZAxis * x._matrix[3, 2]) + (y.WAxis * x._matrix[3, 3]))

                   );
            }
        }
        
        

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
