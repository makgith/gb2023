Console.Write("Input number: ");
int num = int.Parse(Console.ReadLine());

num = num < 0 ? -num: num;

if (num < 99)
{
    Console.WriteLine("There is no 3rd digit in the number!");
}
else
{
    num = num / 100 % 10;
    Console.WriteLine($"3rd digit of the number is: {num}");
}
