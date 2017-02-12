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

        if (limArea > limit)
        {
            for (int x2 = limit * -1 + 1; x2 <= limit; x2++)
                for (int y2 = limit * -1 + 1; y2 <= limit; y2++)
                    for (int x1 = limit * -1; x1 < x2; x1++)
                        for (int y1 = limit * -1; y1 < y2; y1++)
                        {
                            if (Area(x1, y1, x2, y2) >= limArea && x1 < x2 && y1 < y2)
                            {
                                WriteLine($"({x1}, {y1}) ({x2}, {y2}) -> {Area(x1, y1, x2, y2)}");
                                isLimArea = true;
                            }
                        }
        }
        if (!isLimArea || limit == 0 || limArea == 0)
            WriteLine("No");
    }

    static int Area(params int[] p)
    {
        int[] side = { Math.Max(p[0], p[2]) - Math.Min(p[0], p[2]), Math.Max(p[1], p[3]) - Math.Min(p[1], p[3]) };
        return side[0] * side[1];
    }
}