Console.Write("Enter a number: ");

int number = int.Parse(Console.ReadLine());

Console.WriteLine("Even numbers from 1 to " + number + ":");

for (int i = 1; i <= number; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}