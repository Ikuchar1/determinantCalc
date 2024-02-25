// See https://aka.ms/new-console-template for more information
using System;


public class calculator
{
    //funcation that will get the starting matrix that we will perform determinant calculations upon.
    public static int[,] getStartingMatrixValues(int n)
    {
        int[,] matrix = new int[n, n];
        Console.WriteLine("Please enter the value you would like for each position: ");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine("Enter value to be in row " + (i + 1) + " and col " + (j + 1));
                int value = int.Parse(Console.ReadLine());
                matrix[i, j] = value;
            }
        }

        return matrix;
    }

    //Function that will print each value in a matrix
    public static void printMatrix(int n, int[,] matrix)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    //functions that determins if the matrix is invertible
    public static string isInvertible(double determinant)
    {
        if(determinant != 0)
        {
            return "INVERTIBLE";
        } else
        {
            return "NOT INVERTIBLE";
        }
    }

    //gets determinant of any size
    public static double getDeterminant(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        if (n == 1)
        {
            return matrix[0, 0];
        }

        double determinant = 0;
        for (int i = 0; i < n; i++)
        {
            determinant += Math.Pow(-1, i) * matrix[0, i] * getDeterminant(getSubMatrix(matrix, 0, i));
        }

        return determinant;
    }

    public static int[,] getSubMatrix(int[,] matrix, int rowToRemove, int colToRemove)
    {
        int n = matrix.GetLength(0);
        int[,] subMatrix = new int[n - 1, n - 1];

        for(int i = 0, r = 0 ; i < n; i++)
        {
            //skips past row that we are moving
            if (i == rowToRemove)
            {
                continue;
            }

            for (int j = 0, c = 0; j < n; j++)
            {
                if(j == colToRemove){
                    continue;
                }
                
                    subMatrix[r,c] = matrix[i,j];
                    c++;
                
                
            }
            r++;
        }

        return subMatrix;
    }


    public static void Main(String[] args)
    {
        Console.WriteLine("What is the size of your matrix? ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = getStartingMatrixValues(n);


        Console.WriteLine("This is your matrix");
        printMatrix(n, matrix);

        Console.WriteLine();
        double determinant = getDeterminant(matrix);
        Console.WriteLine(determinant);

        Console.WriteLine();
        Console.WriteLine("Based on this information the matrix is " + isInvertible(determinant));

    }
}
