System.Console.Write("Input n: ");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    System.Console.Write($"{Math.Pow(i, 3)} ");
}
