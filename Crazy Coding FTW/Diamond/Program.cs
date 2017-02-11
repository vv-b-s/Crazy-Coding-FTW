using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int size = (int)ReadNum();
        int leftRight = (size - 1) / 2;
        int middle = size - 2 * leftRight - 2;

        WriteLine("{0}{1}{0}", new string('-', leftRight), (size % 2 == 0) ? "**" : "*");

        for (int i = 0, j = leftRight - 1, k = (size % 2 == 0) ? 2 : 1; i < ((size % 2 == 0) ? size / 2 - 1 : size / 2); i++, j--, k += 2)
            WriteLine("{0}{1}{2}{3}{0}", new string('-', j), '*', new string('-', k), ((k < 0) ? "" : '*'.ToString()));

        for (int i = (size - 1) - ((size % 2 == 0) ? size / 2 - 1 : size / 2), j = 1, k = size - 4; i > 1; i--, j++, k -= 2)
            WriteLine("{0}*{1}*{0}", new string('-', j), new string('-', k));

        WriteLine((size % 2 == 0 || size == 1) ? "" : "{0}{1}{0}", new string('-', leftRight), (size % 2 == 0) ? "**" : "*");

    }
    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}