Console.Write("Input number: ");
int num = int.Parse(Console.ReadLine());

for (int i = 0; i < 3; i++)
{

}

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
