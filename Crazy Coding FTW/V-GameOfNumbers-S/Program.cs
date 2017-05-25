using System;
using static System.Console;

class Program
{
    static void Main()
    {
        int numberN = int.Parse(ReadLine());
        int numberM = int.Parse(ReadLine());
        int magicNum = int.Parse(ReadLine());

        int comb = 0;
        int[] magicNumCoordinates = new int[2];
        bool magicNumberIsFound = false;
        for (int i = numberN; i <= numberM; i++)
        {
            for (int j = numberN; j <= numberM; j++)
            {
                comb++;
                if (i + j == magicNum)
                {
                    magicNumberIsFound = true;
                    magicNumCoordinates[0] = i;
                    magicNumCoordinates[1] = j;
                }
            }
        }
        WriteLine(magicNumberIsFound ? $"Number found! {magicNumCoordinates[0]} + {magicNumCoordinates[1]} = {magicNum}" : $"{comb} combinations - neither equals {magicNum}");
    }
}