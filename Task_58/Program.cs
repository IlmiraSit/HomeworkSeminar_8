// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Console.Clear();

int m = GetNonnegativeUserNumber("Enter the number of rows of the 1 st matrix: ", "Input error!");
int n = GetNonnegativeUserNumber("Enter the number of columns of the 1 st matrix (and rows 2nd): ", "Input error!");
int p = GetNonnegativeUserNumber("Enter the number of columns of the 2 st matrix: ", "Input error!");
int range = InputNumbers("Enter a range of random numbers: from 1 to ");

int[,] firstMartrix = new int[m, n];
CreateArray(firstMartrix);
Console.WriteLine($"The first matrix:");
WriteArray(firstMartrix);

int[,] secondMartrix = new int[n, p];
CreateArray(secondMartrix);
Console.WriteLine($"The second matrix:");
WriteArray(secondMartrix);

int[,] resultMatrix = new int[m, p];

MultiplyMatrix(firstMartrix, secondMartrix, resultMatrix);
Console.WriteLine($"The product of the first and second matrices:");
WriteArray(resultMatrix);

void MultiplyMatrix(int[,] firstMartrix, int[,] secomdMartrix, int[,] resultMatrix)
{
  for (int i = 0; i < resultMatrix.GetLength(0); i++)
  {
    for (int j = 0; j < resultMatrix.GetLength(1); j++)
    {
      int sum = 0;
      for (int k = 0; k < firstMartrix.GetLength(1); k++)
      {
        sum += firstMartrix[i,k] * secomdMartrix[k,j];
      }
      resultMatrix[i,j] = sum;
    }
  }
}

int InputNumbers(string input)
{
    Console.Write(input);
    int output = Convert.ToInt32(Console.ReadLine());
    return output;
}

void CreateArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(range);
        }
    }
}

int GetNonnegativeUserNumber(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        int userInput;
        if (int.TryParse(Console.ReadLine(), out userInput) && userInput >= 0)
        {
            return userInput;
        }
        else Console.WriteLine(errorMessage);
    }
}

void WriteArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}
