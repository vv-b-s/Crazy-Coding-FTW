using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int size = (int)ReadNum();
        int innerSize = (size * 4 - 4) / 2;
        WriteLine("{0}{1}{0}", new string('*', size * 2), new string(' ', size));
        for (int i = 1; i <= size - 2; i++)
        {
            if (i == (size - 1) / 2)
                WriteLine("*{0}*{1}*{0}*", new string('/', innerSize), new string('|', size));
            else
                WriteLine("*{0}*{1}*{0}*", new string('/', innerSize), new string(' ', size));
        }
        WriteLine("{0}{1}{0}", new string('*', size * 2), new string(' ', size));
    }
    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}


