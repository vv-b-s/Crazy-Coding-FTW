using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int size = (int)ReadNum();

        int roofSize = ((size + 1) / 2) - 1;
        int bottom = size / 2;

        for (int i = roofSize; i > 0; i--)
            WriteLine("{0}{1}{0}", new string('-', i), new string('*', size - i * 2));

        WriteLine(new string('*', size));

        for (int i = 0; i < bottom; i++)
            WriteLine($"|{new string('*', size - 2)}|");
    }
    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}