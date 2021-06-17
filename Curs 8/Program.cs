using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs_8
{
    class Program
    {
        // Descartes - ha n^n
        static void back(int k, int n, int[] sol)
        {
            if (k >= n)
            {

                bool ok = (sol.ToList().Distinct().ToList().Count == 1);

                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{sol[i]} ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    sol[k] = i + 1;
                    back(k + 1, n, sol);
                }
            }
        }

        // Permutacio - n!
        private static void permutari(int k, int n, int[] sol, bool[] vis)
        {
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(sol[i]);
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!vis[i])
                    {
                        vis[i] = true;
                        sol[k] = i + 1;
                        permutari(k + 1, n, sol, vis);
                        vis[i] = false;
                    }
                }
            }
        }

        // Variaciok [1,2,3,4,5,6] 3 tag
        // 1 2 3  1 2 4  1 2 5 .....
        static void variacio(int k, int n, int p, int[] sol, bool[] vis)
        {
            if (k >= p)
            {
                for (int i = 0; i < p; i++)
                    Console.Write(sol[i]);
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!vis[i])
                    {
                        vis[i] = true;
                        sol[k] = i + 1;
                        variacio(k + 1, n, p, sol, vis);
                        vis[i] = false;
                    }
                }
            }
        }

        // Kombinacio [1,2,3,4,5,6]
        // 1 2 3, 1 3 2, 2 3 1...
        private static void combinari(int k, int n, int p, int[] sol, bool[] vis)
        {
            if (k >= p)
            {
                bool ok = true;

                for (int i = 0; i < p - 1; i++)
                {
                    if (sol[i] > sol[i + 1])
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    for (int i = 0; i < p; i++)
                        Console.Write(sol[i]);
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!vis[i])
                    {
                        vis[i] = true;
                        sol[k] = i + 1;
                        combinari(k + 1, n, p, sol, vis);
                        vis[i] = false;
                    }
                }
            }
        }

        // Matrice 3x3
        // Are valori distincte in multimea [1, 9]
        // O solutie: suma pe fiecare linie = cu suma pe fiecare coloana = suma pe fiecare diagonala
        // Afisati o solutie (daca exista)

        static void Main(string[] args)
        {
            matrixProb();
        }

        static int[,] m = new int[3, 3];
        static Random rnd = new Random();

        private static void init()
        {
            int k = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m[i, j] = k;
                    k++;
                }
            }
        }

        private static void matrixProb()
        {
            init();
            do
            {
                interchange();
            } while (!verify());
            view();
        }


        private static void interchange()
        {
            int l1 = rnd.Next(3);
            int c1 = rnd.Next(3);
            int l2 = rnd.Next(3);
            int c2 = rnd.Next(3);

            int aux = m[l1, c1];
            m[l1, c1] = m[l2, c2];
            m[l2, c2] = aux;
        }

        private static bool verify()
        {
            int s1 = m[0, 0] + m[0, 1] + m[0, 2];
            int s2 = m[1, 0] + m[1, 1] + m[1, 2];
            int s3 = m[2, 0] + m[2, 1] + m[2, 2];

            int c1 = m[0, 0] + m[1, 0] + m[2, 0];
            int c2 = m[0, 1] + m[1, 1] + m[2, 1];
            int c3 = m[0, 2] + m[1, 2] + m[2, 2];

            int d1 = m[0, 0] + m[1, 1] + m[2, 2];
            int d2 = m[0, 2] + m[1, 1] + m[2, 0];

            return (s1 & s2 % s3 % c1 % c2 % c3 % d1 % d2) == s1;
        }

        private static void view()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
