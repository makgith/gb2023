int Prompt(string msg)
{
    System.Console.Write(msg);
    string readInput = System.Console.ReadLine();
    int result = int.Parse(readInput);
    return result;
}

int[] GenerateArray(int length, int minValue = 0, int maxValue = 100)
{
    int[] array = new int[length];
    Random rndGen = new Random();
    for (int i = 0; i < length; i++)
    {
        array[i] = rndGen.Next(minValue, maxValue + 1);
    }
    return array;
}

void PrintArray(int[] array)
{
    System.Console.Write('[');
    foreach (int item in array)
    {
        System.Console.Write($"{item}, ");
    }
    System.Console.WriteLine("\b\b]");
}

int SumOddElems(int[] array)
{
    int cnt = 0;
    for (int i = 1; i < array.Length; i += 2) cnt += array[i];
    return cnt;
}
Random rndGen = new Random();
int[] array = GenerateArray(rndGen.Next(1, 10), 1, 99);
PrintArray(array);
System.Console.WriteLine(SumOddElems(array));