using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationsSystems
{
    class Program
    {   
        //Show Matrix arguments(Matrix, Number of rows and columns)
        static void DisplayMatrix(int[,] arr, int M)
        {
            for (int row = 0; row < M; row++)
            {
                for (int col = 0; col < M + 1; col++)
                {
                    Console.Write(arr[row, col]);
                }
                Console.WriteLine();
            }
        }

        //Froward Elimination Method arguments(Matrix, Number of rows and columns)
        static int[,] ForwardElimination(int[,] A, int M)
        {
            //int[,] A = new int[M, M];
            //Array.Copy(arr, A, M);

            for (int k = 0; k < M; k++)
            {
                for (int i = k + 1; i < M; i++)
                {
                    int factor = A[i, k] / A[k, k];
                    for (int j = k; j < M + 1; j++)
                    {
                        A[i, j] -= factor * A[k, j];
                    }
                }
            }
            return A;
        }

        //Backwards Substitution Method arguments(Matrix, Number of rows and columns)
        //Returns an array V[N elements]
        static double[] BackwardsSubstitution(int[,] A, int N)
        {
            double[] V = new double[N];
            for (int i = N - 1; i >= 0; i--)
            {
                V[i] = A[i, N];
                for (int j = i + 1; j <= N - 1; j++)
                {
                    V[i] -= A[i, j] * V[j];
                }
                V[i] /= A[i, i];
            }

            return V;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How many equations do you want to put? ");
            int M;
            while (!int.TryParse(Console.ReadLine(), out M))
            {
                Console.WriteLine("Wrong number, try again");
            }

            int[,] A = new int[M, M+1];

            for (int row = 0; row < M; row++)
            {
                Console.Write($"Eq #{row}: ");
                int numInput;                
                for (int col = 0; col < M+1; col++)
                {
                    while (!int.TryParse(Console.ReadLine(), out numInput))
                    {
                        Console.WriteLine("Wrong number, try again");
                    }
                    A[row, col] = numInput;
                }
            }

            ForwardElimination(A,M);

            Console.WriteLine("result");
            foreach (var item in BackwardsSubstitution(A, M))
            {
                Console.WriteLine(item);
            }
        }
    }
}
