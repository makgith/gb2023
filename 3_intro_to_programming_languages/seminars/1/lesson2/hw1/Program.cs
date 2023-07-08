int num = 0;
while (num < 99 || num > 1000)
{
    ﻿Console.Write("Enter three-digits number: ");
    num = int.Parse(Console.ReadLine());
    num = num < 0 ? -num : num;
}

num  = num / 10 % 10;

Console.WriteLine($"The 2nd digit of the number is: {num}");