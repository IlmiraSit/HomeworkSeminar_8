// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
//по убыванию элементы каждой строки двумерного массива.
Console.Clear();

var rows = GetNonnegativeUserNumber("Enter number of rows: ", "Input error!");
var colums = GetNonnegativeUserNumber("Enter number of colums: ", "Input error!");
var min = GetUserNumber("Enter a minimal value of array: ", "Input error!");
var max = GetUserNumber("Enter a maximal value of array: ", "Input error!");

var arr = GenerateArray(rows, colums, min, max);

PrintArray(arr);

SortToLower(arr);

Console.WriteLine();
PrintArray(arr);

void SortToLower(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(1) - 1; k++)
            {
                if (arr[i, k] < arr[i, k + 1])
                {
                    int res = arr[i, k + 1];
                    arr[i, k + 1] = arr[i, k];
                    arr[i, k] = res;
                }
            }
        }
    }
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