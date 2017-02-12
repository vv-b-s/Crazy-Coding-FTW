using System;
using System.Text;
using static System.Console;

class Program
{
    static void Main()
    {
        sbyte limit = sbyte.Parse(ReadLine());
        int limArea = int.Parse(ReadLine());

        bool isLimArea = false;

        if (limit!=0)
        {
            for (int x2 = limit * -1 + 1; x2 <= limit; x2++)
                for (int y2 = limit * -1 + 1; y2 <= limit; y2++)
                    for (int x1 = limit * -1; x1 < x2; x1++)
                        for (int y1 = limit * -1; y1 < y2; y1++)
                        {
                            int side1 = Math.Max(x1, x2) - Math.Min(x1, x2);
                            int side2 = Math.Max(y1, y2) - Math.Min(y1, y2);
                            if(side1*side2 >= limArea && x1 < x2 && y1 < y2)
                            {
                                WriteLine($"({x1}, {y1}) ({x2}, {y2}) -> {side2*side1}");
                                isLimArea = true;
                            }
                        }
        }
        if (!isLimArea || limit == 0)
            WriteLine("No");
    }

}