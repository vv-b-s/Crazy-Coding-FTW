using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        int numbers = (int)ReadNum();

        int number = 0;
        int record = 0;

        for (int i = 0, j = 0; i < numbers; i++)
        {
            int temp = (int)ReadNum();
            if (i == 0 || temp > number)
            {
                number = temp;
                j++;
            }
            else if (i > 0 && temp <= number)
            {
                record = (record < j) ? j : record;
                j = 1;
                number = temp;
            }
            if (record < j)
                record = j;
        }

        WriteLine(record);
    }
    static decimal ReadNum()
    {
        string input = ReadLine();
        decimal output;
        decimal.TryParse(input, out output);
        return output;
    }
}