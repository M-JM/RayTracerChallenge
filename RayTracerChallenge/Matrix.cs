﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerChallenge
{
    public class Matrix : IEquatable<Matrix>
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
                    string[] cols = rows[i].Replace("{", string.Empty).Replace("}", string.Empty).Replace(",", string.Empty).Split(new string[] { " " }, StringSplitOptions.None);
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
                        var test = x.GetElement(i, j);
                        var test2 = this.GetElement(i, j);
                        if (!floatExtensions.isEqualD(x.GetElement(i, j), this.GetElement(i, j)))
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
            // REFACTOR needs to be rewritten by using col and row values from matrix
            // multiplying anything else than a 4*4 matrix with a tuple will give an out of bound index

            {
                return new Tuples(
                    (float)((y.XAxis * x._matrix[0, 0]) + (y.YAxis * x._matrix[0, 1])
                    + (y.ZAxis * x._matrix[0, 2]) + (y.WAxis * x._matrix[0, 3])),

                    (float)((y.XAxis * x._matrix[1, 0]) + (y.YAxis * x._matrix[1, 1])
                    + (y.ZAxis * x._matrix[1, 2]) + (y.WAxis * x._matrix[1, 3])),

                    (float)((y.XAxis * x._matrix[2, 0]) + (y.YAxis * x._matrix[2, 1])
                    + (y.ZAxis * x._matrix[2, 2]) + (y.WAxis * x._matrix[2, 3])),

                    (float)((y.XAxis * x._matrix[3, 0]) + (y.YAxis * x._matrix[3, 1])
                    + (y.ZAxis * x._matrix[3, 2]) + (y.WAxis * x._matrix[3, 3]))

                   );
            }
        }



        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public Matrix Transpose()
        {
            Matrix transposedMatrix = new Matrix(this.Col, this.Row);

            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    transposedMatrix._matrix[i, j] = this._matrix[j, i];
                }
            }
            return transposedMatrix;

        }

        public Matrix Submatrix(int p0, int p1)
        {
            Matrix result = new(this.Row - 1, this.Col - 1);
            for (int i = 0; i < this.Row; i++)
            {
                for( int j = 0; j < this.Col; j++)
                {
                    if (i != p0 && j != p1) {
                        if (i < p0 && j < p1)
                            result._matrix[i, j] = this._matrix[i, j];
                        else if (i < p0 && j > p1)
                            result._matrix[i, j - 1] = this._matrix[i, j];
                        else if (i > p0 && j < p1)
                            result._matrix[i - 1, j] = this._matrix[i, j];
                        else if (i > p0 && j > p1)
                            result._matrix[i - 1, j - 1] = this._matrix[i, j];
                    }
                }
            }
            return result;
        }
        
        public float Determinant()
        {
            if (this.Row == 2 && this.Col == 2)
            {
                return (float)(this._matrix[0, 0] * this._matrix[1, 1] - this._matrix[0, 1] * this._matrix[1, 0]);
            }
            else
            {
                float sum = 0;
                for (int i = 0; i < this.Col; i++)
                {
                    sum += (float)(this._matrix[0, i] * Cofactor(this,0, i));
                }
                return sum;
            }
          
        }

        public static float Minor(Matrix _matrixsub)
        {
            return (float)_matrixsub.Determinant();
        }

        public static float Cofactor(Matrix matrix, int p0, int p1)
        {
            Matrix subMatrix = matrix.Submatrix(p0, p1);
            if ((p0 + p1) % 2 == 0)
            {
                return (float)subMatrix.Determinant();
            }
            else
            {
                return (float)-subMatrix.Determinant();
            }
        }

        public bool IsInvertible()
        {
            var det = this.Determinant();
            return det != 0;
        }

        public Matrix Inverse()
        {
            if (!this.IsInvertible())
            {
                throw new Exception("Matrix is not invertible");
            }
            Matrix result = new(this.Row, this.Col);
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                {
                    result._matrix[j, i] = (float)(Cofactor(this, i, j) / this.Determinant());
                }
            }
            return result;
        }
    }
}
