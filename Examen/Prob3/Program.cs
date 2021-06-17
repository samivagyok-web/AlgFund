using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob3
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader file = new StreamReader(@"data2.in");
            string[] lines = file.ReadToEnd().Split('\n');
            int n = lines.Length;
            int m = lines[0].Length - 1;


            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(lines[i][j].ToString());
                }
            }

            matrix = PutZeroToBound(matrix, n, m); // // ca sa nu avem problem cu index out of bound exception cand ne uitam la vecini punem 0 la margini
            int[] freq = FindNumbers(matrix);

            string result = "";

            for (int i = 1; i < freq.Length; i++)
                result += freq[i] + " ";

            CreateAndWriteFile(@"C:\Users\Sami\source\repos\AlgFund\Examen\Prob3\data2.out", result);
        }

        public static int[,] PutZeroToBound(int[,] matrix, int n, int m)
        {
            int[,] matrix2 = new int[n + 2, m + 2];

            for (int i = 1; i < matrix2.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < matrix2.GetLength(1) - 1; j++)
                {
                    matrix2[i, j] = matrix[i - 1, j - 1];
                }
            }

            return matrix2;
        }

        public static int[] FindNumbers(int[,] matrix)
        {
            bool[,] Checked = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            int[] values = new int[4];

            for (int i = 1; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] != 0 && !Checked[i, j])
                    {
                        Checked[i, j] = true;
                        values[matrix[i, j]]++;
                        CheckNeighbours(i, j, matrix, matrix[i, j], ref Checked);
                    }
                }
            }

            return values;
        }

        private static void CheckNeighbours(int i, int j, int[,] matrix, int number, ref bool[,] Checked)
        {
            if (matrix[i - 1, j] == number && !Checked[i - 1, j])
            {
                Checked[i - 1, j] = true;
                CheckNeighbours(i - 1, j, matrix, number, ref Checked);
            }
            if (matrix[i, j - 1] == number && !Checked[i, j - 1])
            {
                Checked[i, j - 1] = true;
                CheckNeighbours(i, j - 1, matrix, number, ref Checked);
            }
            if (matrix[i, j + 1] == number && !Checked[i, j + 1])
            {
                Checked[i, j + 1] = true;
                CheckNeighbours(i, j + 1, matrix, number, ref Checked);
            }
            if (matrix[i + 1, j] == number && !Checked[i + 1, j])
            {
                Checked[i + 1, j] = true;
                CheckNeighbours(i + 1, j, matrix, number, ref Checked);
            }

        }

        public static void View2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static void CreateAndWriteFile(string path, string content) => File.WriteAllText(path, content);

    }
}
