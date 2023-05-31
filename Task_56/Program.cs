// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку 
// с наименьшей суммой элементов.
Console.Clear();

int rows = GetNonnegativeUserNumber("Enter number of rows: ", "Input error!");
int colums = GetNonnegativeUserNumber("Enter number of colums: ", "Input error!");
int min = GetUserNumber("Enter a minimal value of array: ", "Input error!");
int max = GetUserNumber("Enter a maximal value of array: ", "Input error!");

var arr = GenerateArray(rows, colums, min, max);

PrintArray(arr);

int minSumLine = 0;
int sumLine = SumLineElements(arr, 0);
for (int i = 1; i < arr.GetLength(0); i++)
{
  int tempSumLine = SumLineElements(arr, i);
  if (sumLine > tempSumLine)
  {
    sumLine = tempSumLine;
    minSumLine = i;
  }
}

Console.WriteLine($"\n{minSumLine+1} - строкa с наименьшей суммой ({sumLine}) элементов ");


int SumLineElements(int[,] array, int i)
{
  int sumLine = array[i,0];
  for (int j = 1; j < array.GetLength(1); j++)
  {
    sumLine += array[i,j];
  }
  return sumLine;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i,j]} ");
        }
        Console.WriteLine();
    }
}

int[,] GenerateArray(int m, int n, int minValue, int maxValue)
{
    int[,] arr = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            arr[i,j] = new Random().Next(minValue,maxValue + 1);
        }
    }
    return arr;
}

int GetUserNumber(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        int userInput;
        if (int.TryParse(Console.ReadLine(), out userInput))
        {
            return userInput;
        }
        else Console.WriteLine(errorMessage);
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