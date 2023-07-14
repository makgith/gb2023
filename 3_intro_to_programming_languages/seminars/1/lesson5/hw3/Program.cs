int Prompt(string msg)
{
    System.Console.Write(msg);
    string readInput = System.Console.ReadLine();
    int result = int.Parse(readInput);
    return result;
}

double[] GenerateArray(int length, double minValue = 0, double maxValue = 100)
{
    double[] array = new double[length];
    Random rndGen = new Random();
    for (int i = 0; i < length; i++)
    {
        array[i] = rndGen.NextDouble() * (maxValue - minValue) + minValue;
    }
    return array;
}

void PrintArray(double[] array)
{
    System.Console.Write('[');
    foreach (double item in array)
    {
        System.Console.Write($"{item}, ");
    }
    System.Console.WriteLine("\b\b]");
}

double FindMinMaxDiff(double[] array)
{
    double min, max;
    min = max = array[0];
    for (int i = 1; i < array.Length; i += 2)
    {
        if (array[i] > max) max = array[i];
        if (array[i] < min) min = array[i];

    }
    return max - min;
}
Random rndGen = new Random();
double [] array = GenerateArray(rndGen.Next(1, 10), 1, 99);
PrintArray(array);
System.Console.WriteLine(FindMinMaxDiff(array));