using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int size = (int)ReadNum();

        for (int i = 0, j = size - 1; i < size; i++, j--)
        {
            string fill = new string('*', i + 1);
            string temp = "";
            for (int o = 0; o < i + 1; o++)
            {
                temp += fill[o];
                temp += ' ';
            }

            WriteLine(new string(' ', j) + temp);
        }
        for (int i = size - 1, j = 1; i > 0; i--, j++)
        {
            string fill = new string('*', i);
            string temp = "";
            for (int o = 0; o < i; o++)
            {
                temp += fill[o];
                temp += ' ';
            }

            WriteLine(new string(' ', j) + temp);
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

