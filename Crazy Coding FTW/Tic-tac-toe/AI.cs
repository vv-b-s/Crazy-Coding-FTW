using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public class AI
    {
        static int XesCount = 0;
        static int OesCount = 0;
        static int EmptyCount = 0;

        static Random rand = new Random();
        static bool[,] hasX =
        {
            {false,false,false },
            {false,false,false },
            {false,false,false }
        };

        static bool[,] hasO =
        {
            {false,false,false },
            {false,false,false },
            {false,false,false }
        };

        static bool[,] empty =
        {
            {false,false,false },
            {false,false,false },
            {false,false,false }
        };

        public static void Check(string[,] XO)
        {
            for (int i = 0; i < XO.GetLength(0); i++)
                for (int j = 0; j < XO.GetLength(1); j++)
                    if (XO[i, j] == "X")
                    {
                        hasX[i, j] = true;
                        XesCount++;
                    }
                    else if (XO[i, j] == "O")
                    {
                        hasO[i, j] = true;
                        OesCount++;
                    }
                    else
                    {
                        empty[i, j] = true;
                        EmptyCount++;
                    }
        }

        public static int[] GenerateO()
        {
            int[] output = new int[2];
            if(OesCount==1)
            {
                for(;;)
                {
                    output[0] = rand.Next(3);
                    output[1] = rand.Next(3);

                    if (hasX[output[0], output[1]] == true)
                        continue;
                    else return output;
                }
            }
            return output;
        }

    }
}
