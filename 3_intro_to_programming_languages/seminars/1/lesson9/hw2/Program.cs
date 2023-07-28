int Prompt(string msg)
{
    System.Console.Write(msg);
    string readInput = System.Console.ReadLine();
    int result = int.Parse(readInput);
    return result;
}

int FindSumm(int current, int target)
{
    if (current > target)
    {
        return 0;
    }

    return current + FindSumm(current + 1, target);
}

// MAIN

int m = Prompt("Input M: ");
int n = Prompt("Input N: ");

System.Console.WriteLine(FindSumm(m, n));
