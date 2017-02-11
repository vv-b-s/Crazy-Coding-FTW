using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int size = (int)ReadNum();

        WriteLine(new string(' ', size + 1) + "|");
        for (int i = 1, j = size - 1; i <= size; i++, j--)
            WriteLine("{0}{1} | {1}", new string(' ', j), new string('*', i));

    }
    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}

