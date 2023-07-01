System.Console.Write("Input number 1: ");
string inputString = Console.ReadLine();
int number1 = Convert.ToInt32(inputString);

System.Console.Write("Input number 2: ");
int number2 = Convert.ToInt32(Console.ReadLine());

if (number1 >= number2)
{
    System.Console.WriteLine($"Max = {number1}, min = {number2}");
}
else
{
    System.Console.WriteLine($"Max = {number2}, min = {number1}");
}
