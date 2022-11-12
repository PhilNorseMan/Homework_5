/*Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
[345, 897, 568, 234] -> 2*/

void FillArray(int[] arr)
{
    int length = arr.Length;
    int index = 0;
    while (index < length)
    {
        arr[index] = new Random().Next(100, 1000);
        index++;
    }
}

void PrintArray(int[] arr)
{
    int count = arr.Length;
    int position = 0;
    Console.Write("| ");
    while (position < count)
    {
        Console.Write(arr[position] + " | ");
        position++;
    }
    Console.WriteLine();
}

void CountEvenInArray(int[] arr)
{
    int result = 0;
    for (int index = 0; index < arr.Length; index++)
    {
        if (arr[index] % 2 == 0)
            result++;
    }
    Console.WriteLine($"Number of even numbers in generated array is: {result}.");
}

int[] array = new int[4];
FillArray(array);
PrintArray(array);
CountEvenInArray(array);