using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int num1 = int.Parse(ReadLine());
        int num2 = int.Parse(ReadLine());
        if (num2 - num1 >= 5)
        {
            for (int i = num1; i <= num2 - 4; i++)
                for (int j = i + 1; j <= num2 - 3; j++)
                    for (int k = j + 1; k <= num2 - 2; k++)
                        for (int l = k + 1; l <= num2 - 1; l++)
                            for (int m = l + 1; m <= num2; m++)
                                WriteLine($"{i} {j} {k} {l} {m}");
        }
        else
            WriteLine("No");
    }
}