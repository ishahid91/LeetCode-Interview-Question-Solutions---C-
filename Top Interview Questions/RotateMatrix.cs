using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class RotateMatrix
    {
        public void Rotate(int[][] matrix)
        {
            Transpose(matrix);
            Reverse(matrix);
        }

        public void Transpose(int[][] matrix)
        {
            var length = matrix.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    var tmp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = tmp;
                }
            }
        }

        public void Reverse(int[][] matrix)
        {
            var length = matrix.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length / 2; j++)
                {
                    var tmp = matrix[i][j];
                    matrix[i][j] = matrix[i][length - j - 1];
                    matrix[i][length - j - 1] = tmp;
                }
            }
        }
    }
}
