int Prompt(string msg)
{
    System.Console.Write(msg);
    string readInput = System.Console.ReadLine();
    int result = int.Parse(readInput);
    return result;
}

int Ackermann(int m, int n)
{
    if (m == 0)
    {
        return n + 1;
    }
    else if (m > 0 && n == 0)
    {
        return Ackermann(m - 1, 1);
    }
    else if (m > 0 && n > 0)
    {
        return Ackermann(m - 1, Ackermann(m, n - 1));
    }

    return 0; // Invalid input
}

// MAIN

int m = Prompt("Input M: ");
int n = Prompt("Input N: ");

System.Console.WriteLine(Ackermann(m, n));
