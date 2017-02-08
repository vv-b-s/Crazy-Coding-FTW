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
            {true,true,true },
            {true,true,true },
            {true,true,true }
        };

        public static void Check(string[,] XO)
        {
            for (int i = 0; i < XO.GetLength(0); i++)
                for (int j = 0; j < XO.GetLength(1); j++)
                    if (XO[i, j] == "X")
                    {
                        hasX[i, j] = true;
                        XesCount++;
                        empty[i, j] = false;
                    }
                    else if (XO[i, j] == "O")
                    {
                        hasO[i, j] = true;
                        OesCount++;
                        empty[i, j] = false;
                    }
        }

        public static int[] GenerateO()
        {
            int[] output = new int[2];
            if (XesCount == 1 && OesCount == 0)
            {
                for (;;)
                {
                    output[0] = rand.Next(3);
                    output[1] = rand.Next(3);

                    if (!empty[output[0], output[1]])
                        continue;
                    else
                    {
                        empty[output[0], output[1]] = false;
                        return output;
                    }
                }
            }
            if (XesCount > 1)
            {
                if (StrikeMove("O", ref output))              // Tries to win
                    return output;
                else if (StrikeMove("X", ref output))       // Makes sure the oponent doesn't
                    return output;
                else
                {
                    for (;;)
                    {
                        output[0] = rand.Next(3);
                        output[1] = rand.Next(3);

                        if (!empty[output[0], output[1]])
                            continue;
                        else
                        {
                            empty[output[0], output[1]] = false;
                            return output;
                        }
                    }
                }
            }
            return output;
        }


        static bool StrikeMove(string _XorO, ref int[] pos)
        {
            bool[,] XorO = new bool[3, 3];
            switch (_XorO)               //Decides what to look for
            {
                case "X":
                    XorO = hasX;
                    break;
                case "O":
                    XorO = hasO;
                    break;
            }

            #region Check roll
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (XorO[i, j])
                    {
                        if (XorO[i, (j + 1) % 3] && empty[i, (j + 2) % 3])   // If j + 1 = 3, 3%3=0
                        {
                            pos[0] = i;
                            pos[1] = (j + 2) % 3;
                            return true;
                        }
                        if (XorO[i, (j + 2) % 3] && empty[i, (j + 1) % 3])
                        {
                            pos[0] = i;
                            pos[1] = (j + 1) % 3;
                            return true;
                        }
                    }
                }
            #endregion

            #region Check col
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (XorO[j, i])
                    {
                        if (XorO[(j + 1) % 3, i] && empty[(j + 2) % 3, i])   // If i + 1 = 3, 3%3=0
                        {
                            pos[1] = i;
                            pos[0] = (j + 2) % 3;
                            return true;
                        }
                        if (XorO[(j + 2) % 3, i] && empty[(j + 1) % 3, i])
                        {
                            pos[1] = i;
                            pos[0] = (j + 1) % 3;
                            return true;
                        }
                    }
                }
            #endregion

            #region Diagonals
            for (int i = 0; i < 3; i++)
            {
                if (XorO[i, i])
                {
                    if (XorO[(i + 1) % 3, (i + 1) % 3] && empty[(i + 2) % 3, (i + 2) % 3])
                    {
                        pos[0] = (i + 2) % 3;
                        pos[1] = (i + 2) % 3;
                        return true;
                    }
                    if (XorO[(i + 2) % 3, (i + 2) % 3] && empty[(i + 1) % 3, (i + 1) % 3])
                    {
                        pos[0] = (i + 1) % 3;
                        pos[1] = (i + 1) % 3;
                    }
                }
            }

            for (int i = 0, j = 2; i < 3; i++, j--)
            {
                if (XorO[i, j])
                {
                    if (XorO[(i + 1) % 3, Math.Abs(j - i)] && empty[(i + 2) % 3, (j+1)%3])          // Math.Abs() is used so when 2,0 is reached to look at 0,2 and not 0,-2
                    {
                        pos[0] = (i + 2) % 3;
                        pos[1] = (j + 1) % 3;
                        return true;
                    }
                    if (XorO[(i + 2) % 3, (j + 1) % 3] && empty[(i + 1) % 3, Math.Abs(j - i)])
                    {
                        pos[0] = (i + 1) % 3;
                        pos[1] = Math.Abs(j - i);
                        return true;
                    }
                }
            }
            #endregion
            return false;
        }

        public static void EmptyReset()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    empty[i, j] = true;
                    hasO[i, j] = false;
                    hasX[i, j] = false;
                    XesCount = 0;
                    OesCount = 0;
                }
        }
    }
}
