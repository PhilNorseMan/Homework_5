/*Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.*/

/* Попробовал рандомайзер для float, но пока нашел только через Random.NextSingle, что генерит только от 0 до 1. Также как и для double NextDouble.
float[] GenerateRandomArrayFloat(int size)
{
    var result = new float[size];

    Random random = new();

    for (int index = 0; index < size; index++)
    {
        result[index] = random.NextSingle();
    }

    return result;
}
*/

float[] ArrayByString()
{
    Console.WriteLine("");

NewInput:

    Console.WriteLine("Please, input your numbers (!!! Separate them by slash!!!)");

    string str = Console.ReadLine()!;
    string[] strSep = str.Split('/');

    float[] result = new float[strSep.Length];

    for (int i = 0; i < strSep.Length; i++)
    {
        string temp = strSep[i].Trim();

        if (float.TryParse(temp, out float tempInt))
        {
            result[i] = tempInt;
        }
        else
        {
            Console.WriteLine($"ERROR: Incorrect input! (Value {i +1})");

            goto NewInput;
        }
    }

    return result;
}

void PrintArray(float[] arr)
{
    Console.WriteLine("Array created:");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i]);

        if (i != arr.Length - 1)
            Console.Write(" | ");
    }

    Console.WriteLine();
}


void DifferenceBetweenMinMaxFloat(float[] arr)
{
    int index = 0;
    float max = arr[index];
    float min = arr[index];
    for (index = 0; index < arr.Length; index++)
    {
        if(arr[index] > max)
            max = arr[index];
        if(arr[index] < min)
            min = arr[index];
    }

    Console.WriteLine($"max is {max}.");
    Console.WriteLine($"min is {min}.");

    float result = max - min;

    Console.WriteLine($"Difference between minimal and maximal numbers is: {result}.");
}

var array = ArrayByString();
PrintArray(array);
DifferenceBetweenMinMaxFloat(array);