int Prompt(string msg)
{
    System.Console.Write(msg);
    string readInput = System.Console.ReadLine();
    int result = int.Parse(readInput);
    return result;
}

void PrintEvenNumbers(int current, int target)
{
    if (current > target)
    {
        return;
    }

    if (current % 2 == 0)
    {
        Console.WriteLine(current);
        PrintEvenNumbers(current + 2, target);
    }
    else
    {
        PrintEvenNumbers(current + 1, target);
    }

}

// MAIN

int m = Prompt("Input M: ");
int n = Prompt("Input N: ");

PrintEvenNumbers(m, n);
