Console.WriteLine("Enter three numbers:");

Console.Write("Number 1: ");
int num1 = int.Parse(Console.ReadLine());

Console.Write("Number 2: ");
int num2 = int.Parse(Console.ReadLine());

Console.Write("Number 3: ");
int num3 = int.Parse(Console.ReadLine());

int max = num1;
if (num2 > max)
    max = num2;
if (num3 > max)
    max = num3;

Console.WriteLine("The maximum number is: " + max);