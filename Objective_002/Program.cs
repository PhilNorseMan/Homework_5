/*Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
[3, 7, 23, 12] -> 19
[-4, -6, 89, 6] -> 0*/

int[] GenerateRandomArray(int size, int startArray, int endArray)
{
    var result = new int[size];

    Random random = new();

    for (int index = 0; index < size; index++)
    {
        result[index] = random.Next(startArray, endArray + 1);
    }

    return result;
}

void PrintArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i]);

        if (i != arr.Length - 1)
            Console.Write(" | ");
    }

    Console.WriteLine();
}

int SumNegativePositionNumbers(int[] arr)
{
    int result = 0;

    for (int i = 0; i < arr.Length; i+=2)
    {
        result += arr[i];
    }

    return result;
}

Console.WriteLine("Please, set the size of array:");
int arraySize = int.Parse(Console.ReadLine()!);
Console.WriteLine("Please, set the start of array range:");
int arrayMin = int.Parse(Console.ReadLine()!);
Console.WriteLine("Please, set the end of array range:");
int arrayMax = int.Parse(Console.ReadLine()!);

var array = GenerateRandomArray(arraySize, arrayMin, arrayMax);
PrintArray(array);

var negativePosSum = SumNegativePositionNumbers(array);
Console.WriteLine("Sum of numbers on negative positions is: " + negativePosSum);