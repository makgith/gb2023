
Console.Write($"Enter first dot coordinats (real numbers delimited with space): ");
double[] a = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
Console.Write($"Enter second dot coordinats (real numbers delimited with space): ");
double[] b = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

System.Console.WriteLine(
    $"Distance is: {Math.Pow(Math.Pow(a[0] - b [0], 2) + Math.Pow(a[1] - b[1], 2) + Math.Pow(a[2] - b[2], 2), 0.5)}"
);
