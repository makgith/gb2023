int num = 0;
while (num < 1 || num > 7)
{
    ﻿Console.Write("Enter week day number (1-7): ");
    num = int.Parse(Console.ReadLine());
}

if (num > 5)
{
    Console.WriteLine("Yes!");
}
else
{
    Console.WriteLine("No!");
}
