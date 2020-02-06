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
        public static void DisplayMatrix(int[,] arr, int M, int N)
        {
            for (int row = 0; row < M; row++)
            {
                Console.Write("[");
                for (int col = 0; col < N; col++)
                {
                    Console.Write(arr[row, col] + ", ");
                }
                Console.Write("]");
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

        static int CheckInt()
        {
            int M;
            while (!int.TryParse(Console.ReadLine(), out M))
            {
                Console.WriteLine("Wrong number, try again");
            }
            return M;
        }

        static void Main(string[] args)
        {
            

            Console.WriteLine("How many equations do you want to put? ");
            int M = CheckInt();

            Console.WriteLine("x1 | x2 | x3 | b \n");
            Entering_Equations.UserInterface(M);

            int[,] A = new int[M, M + 1];
            A = Entering_Equations.ReturnMatrix();

            DisplayMatrix(A, M, M+1);
           

            /*for (int row = 0; row < M; row++)
            {
                Console.Write($"Eq #{row}: ");
                             
                for (int col = 0; col < M+1; col++)
                {
                    A[row, col] = CheckInt(); ;
                }
            }*/

            ForwardElimination(A,M);

            Console.WriteLine("result");
            foreach (var item in BackwardsSubstitution(A, M))
            {
                Console.WriteLine(item);
            }
        }
    }
}
