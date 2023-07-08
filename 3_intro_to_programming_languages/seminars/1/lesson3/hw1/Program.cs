int number = 0;
int digits_num = 5;

while (Math.Pow(10, digits_num - 1) > number || number > Math.Pow(10, digits_num + 1))
{
    ﻿Console.Write($"Enter {digits_num}-digits number: ");
    number = int.Parse(Console.ReadLine());
    number = number < 0 ? - number : number;
}

for (
    int i = 0, denominator = (int) Math.Pow(10, digits_num - 1);
    i < digits_num / 2;
    i++, number = number % denominator / 10, denominator /= 100
)
{
    System.Console.WriteLine($"n is: {number} den is: {denominator}");
    if (number / denominator != number % 10)
    {
        System.Console.WriteLine("No");
        return 0;
    }
}
System.Console.WriteLine("Yes");
return 0;