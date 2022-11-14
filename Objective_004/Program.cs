/*Задача HARD STAT необязательная: 
Задайте массив случайных целых чисел. +
Найдите максимальный элемент и его индекс, +
минимальный элемент и его индекс, +
среднее арифметическое всех элементов. +
Сохранить эту инфу в отдельный массив и вывести на экран с пояснениями. +
Найти медианное значение первоначалального массива, +
возможно придется кое-что для этого дополнительно выполнить.*/
/*Для себя
Разложить все функции по принципам SOLID
Медианное значение: Полученные результаты располагают в ряд в порядке возрастания или убывания числовых значений +
и определяют медианное значение, которое находится в середине ряда, если число полученных результатов нечетное, +
или является средним арифметическим двух значений,находящихся в середине ряда, если число результатов четное. +
*/

int[] GenerateRandomArray()
{   
    Console.WriteLine("Programm will generate random array, using your information.");
    Console.WriteLine();

    InputSize:

    Console.WriteLine("Please, set the size of array:");
    int size = int.Parse(Console.ReadLine()!);

    if(size < 1) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: Incorrect input! (Size of array cannot be less than 1.)");
        Console.ResetColor();
        goto InputSize;
    }

    InputStartEnd:

    Console.WriteLine("Please, set the start of array range:");
    int startArray = int.Parse(Console.ReadLine()!);
    Console.WriteLine("Please, set the end of array range:");
    int endArray = int.Parse(Console.ReadLine()!);

    if(endArray < startArray) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: Incorrect input! (End of array value cannot be less than start of array value)");
        Console.ResetColor();
        goto InputStartEnd;
    }

    var result = new int[size];

    Random random = new();

    for (int index = 0; index < size; index++)
    {
        result[index] = random.Next(startArray, endArray + 1);
    }

    return result;
}

void PrintArray(int[] arr) // Принтер одномерного массива
{
    int count = arr.Length;
    int position = 0;
    while (position < count)
    {
        Console.Write(arr[position] + " | ");
        position++;
    }
    Console.WriteLine();
}

void PrintArrayString(string[,] arr) // Принтер двумерного массива
{
    int count_x = arr.GetLength(0);
    int count_y = arr.GetLength(1);
    
    for (int i = 0; i < count_x; i++)
    {
        for (int j = 0; j < count_y; j++)
            Console.Write(arr[i, j] + " | ");
        Console.WriteLine();
    }
}

int FindMaxValue(int[] arr)
{
    int index = 0;
    int max = arr[index];

    for (index = 0; index < arr.Length; index++)
    {
        if (arr[index] > max)
            max = arr[index];
    }

    return max;
}

int FindMinValue(int[] arr)
{
    int index = 0;
    int min = arr[index];

    for (index = 0; index < arr.Length; index++)
    {
        if (arr[index] < min)
            min = arr[index];
    }

    return min;
}

int FindMaxValueIndex(int[] arr)
{
    int index = 0;
    int position = 0;
    int find = FindMaxValue(arr);
    while (index < arr.Length)
    {
        if (arr[index] == find)
        {
            position = index;
            break;
        }
        index++;
    }
    return position;
}
// либо юзать int FindMaxValueIndex = IndexOf(array, FindMaxValue);
int FindMinValueIndex(int[] arr)
{
    int index = 0;
    int position = 0;
    int find = FindMinValue(arr);
    while (index < arr.Length)
    {
        if (arr[index] == find)
        {
            position = index;
            break;
        }
        index++;
    }
    return position;
}
// либо юзать int FindMinValueIndex = IndexOf(array, FindMinValue);
double FindArithmeticalMean(int[] arr)
{
    double sum = 0;

    for (int index = 0; index < arr.Length; index++)
    {
        sum += arr[index];
    }

    double result = sum / arr.Length;

    return result;
}

double[] FillArrayWithFunctionalValues(int[] array) // Заполнение массива с искомыми значениями
{
    double[] table = new double[5];
    table[0] = FindMaxValue(array);
    table[1] = FindMaxValueIndex(array);
    table[2] = FindMinValue(array);
    table[3] = FindMinValueIndex(array);
    table[4] = FindArithmeticalMean(array);

    return table;
}

int CountOfMaxValueDoubles(int[] arr) // Подсчет количества повторений максимального элемента.
{
    int index = 0;
    int count = 0;
    int example = FindMaxValue(arr);
    int[] doublesMax = new int[count];
    while (index < arr.Length)
    {
        if (arr[index] == example)
        {
            count++;
        }
        index++;
        
    }
    return count;
}

int[] ContainerForMaxValueDoubles(int[] arr) // Вывод массива всех позиций где есть макс значение.
{
    int index = 0;
    int position = 0;
    int size = CountOfMaxValueDoubles(arr);
    int example = FindMaxValue(arr);
    int[] doublesMax = new int[size];
    while (index < arr.Length)
    {
        if (arr[index] == example)
        {
            doublesMax[position] = index;
            position++;
        }
        index++;
        
    }
    return doublesMax;
}

int CountOfMinValueDoubles(int[] arr) // Подсчет количества повторений минимального элемента.
{
    int index = 0;
    int count = 0;
    int example = FindMinValue(arr);
    int[] doublesMin = new int[count];
    while (index < arr.Length)
    {
        if (arr[index] == example)
        {
            count++;
        }
        index++;
        
    }
    return count;
}

int[] ContainerForMinValueDoubles(int[] arr) // Вывод массива всех позиций где есть мин значение.
{
    int index = 0;
    int position = 0;
    int size = CountOfMinValueDoubles(arr);
    int example = FindMinValue(arr);
    int[] doublesMin = new int[size];
    while (index < arr.Length)
    {
        if (arr[index] == example)
        {
            doublesMin[position] = index;
            position++;
        }
        index++;
        
    }
    return doublesMin;
}

string IndexDoublesToString (int[] arr) // Приведение массива повторяшек в строку.
{
    string result = String.Join(", ", arr);
        
    return result;
}

string DoubleToStringValues(double value) // Приведение полученных даблов к стрингам для введения в массив-таблицу
{

string result = value.ToString();

return result;
}

double MedianValue(int[] arr) // Поиск медианного значения
{
    int temp;
    for (int i = 0; i < arr.Length - 1; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
    
    int index = 0;
    double result = -1;

    if(arr.Length % 2 == 0)
    {
        int centreUpEven = arr.Length / 2;
        int centreDownEven = centreUpEven - 1;

        double a = arr[centreUpEven];
        double b = arr[centreDownEven];
        result = ( a + b ) /2;
    }
    else
    {
        index = arr.Length / 2;
        result = arr[index];
    }
    
    return result;
}

// Creation of array

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("**** START *****");
Console.ResetColor();
Console.WriteLine();

int[] array = GenerateRandomArray();

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("*****Generated array is:*****"); 
Console.ResetColor();
Console.WriteLine();

PrintArray(array);

// объявление массива, содержащего итоговые значения (значения индексов макс и мин эл-та берутся не из него, тк могут быть повторения макс и мин значений в массиве; для них используются свои функции)
double[] resultArray = FillArrayWithFunctionalValues(array);

// контейнеры для индексов макс и мин эл-тов
int[] maxIndexContainer = ContainerForMaxValueDoubles(array);
int[] minIndexContainer = ContainerForMinValueDoubles(array);

//приведение массивов индексов макс и мин эл-тов в строки
string indexMaxDoubles = IndexDoublesToString(maxIndexContainer);
string indexMinDoubles = IndexDoublesToString(minIndexContainer);

// приведение даблов в стринги
string maximum = DoubleToStringValues(resultArray[0]);
string minimum = DoubleToStringValues(resultArray[2]);
string indexMaximum = DoubleToStringValues(resultArray[1]);
string indexMinimum = DoubleToStringValues(resultArray[3]);
string arithmeticalMiddle = DoubleToStringValues(resultArray[4]);

// вывод массива-таблицы в консоль
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("**** Program execution result *****");
Console.ResetColor();
Console.WriteLine();

string[,] tableOfResults = { { "max value", maximum },
                             { "index max value", indexMaxDoubles },
                             { "min value", minimum },
                             { "index min value", indexMinDoubles },
                             { "arithmetical middle", arithmeticalMiddle } };

PrintArrayString(tableOfResults);

// вычисление медианного значения
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("**** Median value is *****");
Console.ResetColor();
Console.WriteLine();

double medianValue = MedianValue(array);
Console.WriteLine("| " + medianValue + " |");

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("**** END *****");
Console.ResetColor();
Console.WriteLine();