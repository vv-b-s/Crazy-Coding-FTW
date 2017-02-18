using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int n = (int)ReadNum();
        for (int i = 1, j = 1; i <= n; j++)
        {
            for (int k = 0; k < j; k++)
            {
                Write(i + " ");
                i++;
                if (i > n)
                    break;
            }
            WriteLine();
        }
    }


    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}