using System;
using System.IO;

namespace TechnicalAssessment
{
    class Triangle
    {
        public static void Main()
        {
            Triangle triangle = new Triangle();

            string path = @"triangle.txt";

            int maxSum = triangle.MaxPathSum(path);

            Console.WriteLine("Max adjacent path sum: {0}", maxSum);
            Console.ReadKey();
        }

        //Computes the max path sum of the triangle.txt found at the path provided.
        public int MaxPathSum(string path)
        {
            //Dimensions of matrix.
            //TODO: dynamically find size.
            int m = 100;
            int n = 100;

            //Read triangle from text file.
            string[] lines = File.ReadAllLines(path);

            //Convert string[] lines to 2D MxN matrix.
            int[,] tri = ConvertMatrix(lines, m, n);

            //prints 2D MxN Triangle matrix, for debugging.
            //PrintTriangle(tri, m, n);

            //The following code loops through the matrix, comparing adjacent paths, from the bottom-up.
            //Commented-out statements are for debugging purposes.
            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    //Console.WriteLine("Index: ({0}, {1}) -> {2} vs {3}", i, j, tri[i + 1, j], tri[i + 1, j+1]);
                    if (tri[i + 1, j] > tri[i + 1, j + 1])
                    {
                        //Console.WriteLine("Greater: {0} \n", tri[i+1, j]);
                        tri[i, j] += tri[i + 1, j];
                    }   
                    else
                    {
                        //Console.WriteLine("Greater: {0} \ns", tri[i + 1, j+1]);
                        tri[i, j] += tri[i + 1, j + 1];
                    }
                    //PrintTriangle(tri, m, n);
                    //Console.WriteLine();
                }
            }

            //Returns top most element in our matrix.
            //This element contains the sum.
            return tri[0, 0];
        }

        //Converts string[] lines to int[m,n] matrix.
        public int[,] ConvertMatrix(string[] rows, int m, int n)
        {
            int[,] matrix = new int[m, n];
            int rowNum = 0;
            foreach (string row in rows)
            {
                string[] sub = row.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i <= sub.Length - 1; i++)
                    matrix[rowNum, i] = Int32.Parse(sub[i]);
                rowNum++;
            }
            return matrix;
        }

        //Prints the triangle matrix.
        public void PrintTriangle(int[,] tri, int m, int n)
        {
            for (int i = 0; i <= m - 1; i++)
            {
                for (int j = 0; j <= n - 1 ; j++)
                        Console.Write(tri[i, j] + " ");
                Console.WriteLine("\n");
            }
        }

    }
}
