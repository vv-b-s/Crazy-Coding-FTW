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
            if (XesCount == 1&&OesCount==0)
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
                if (WinPotential(ref output))
                    return output;
                else if (FailPotential(ref output))
                    return output;
                else
                {                    
                    for(;;)
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


        static bool FailPotential(ref int[] pos)
        {
            #region 0,0
            if (hasX[0, 0])                                          /// Left top
            {
                if (hasX[0, 1] && empty[0, 2])                      // Middle Top
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[0, 2] && empty[0, 1])             // Right Top
                {
                    pos[0] = 0;
                    pos[1] = 1;
                    return true;
                }
                if (hasX[1, 0] && empty[2, 0])             //Left Middle
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[2, 0] && empty[1, 0])          // Bottom Left
                {
                    pos[0] = 1;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[1, 1] && empty[2, 2])       // Middle Middle
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[2, 2] && empty[1, 1])   // Right bottom
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 0,1
            if (hasX[0, 1])                         /// Middle top
            {
                if (hasX[0, 0] && empty[0, 2])                      // Left Top
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[0, 2] && empty[0, 0])             // Right Top
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[1, 1] && empty[2, 1])             //Middle Middle
                {
                    pos[0] = 2;
                    pos[1] = 1;
                    return true;
                }
                if (hasX[2, 1] && empty[1, 1])          // Bottom Middle
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 0,2
            if (hasX[0, 2])                                  ///Right top
            {
                if (hasX[0, 1] && empty[0, 0])                      // Middle Top
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[0, 0] && empty[0, 1])             // Left Top
                {
                    pos[0] = 0;
                    pos[1] = 1;
                    return true;
                }
                if (hasX[1, 2] && empty[2, 2])             //Right Middle
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[2, 2] && empty[1, 1])          // Bottom Right
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
                if (hasX[1, 1] && empty[2, 0])       // Middle Middle
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[2, 0] && empty[1, 1])   // Right bottom
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 1,0
            if (hasX[1, 0])                                        /// Middle left
            {
                if (hasX[0, 0] && empty[2, 0])                      // Left Top
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[2, 0] && empty[0, 0])             // Left Bottom
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[1, 1] && empty[1, 2])             //Middle Middle
                {
                    pos[0] = 1;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[1, 2] && empty[1, 1])          // Middle Right
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 1,2
            if (hasX[1, 2])                                      ///Right Middle
            {
                if (hasX[0, 2] && empty[2, 2])                      // Right Top
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[2, 2] && empty[0, 2])             // Right Bottom
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[1, 1] && empty[1, 0])             //Middle Middle
                {
                    pos[0] = 1;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[1, 0] && empty[1, 1])          // Middle Left
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 2,0
            if (hasX[2, 0])                                      /// Left Bottom
            {
                if (hasX[2, 1] && empty[2, 2])                      // Middle Bottom
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[2, 2] && empty[2, 1])             // Right Bottom
                {
                    pos[0] = 2;
                    pos[1] = 1;
                    return true;
                }
                if (hasX[1, 0] && empty[0, 0])             //Left Middle
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[0, 0] && empty[1, 0])          // Left Top
                {
                    pos[0] = 1;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[1, 1] && empty[0, 2])       // Middle Middle
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[0, 2] && empty[1, 1])   // Right Top
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion 2,0

            #region 2,1
            if (hasX[2, 1])                              /// Middle Bottom
            {
                if (hasX[2, 2] && empty[2, 0])                      // Right Bottom
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[2, 0] && empty[2, 2])             // Left Bottom
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[1, 1] && empty[0, 1])             //Middle Middle
                {
                    pos[0] = 0;
                    pos[1] = 1;
                    return true;
                }
                if (hasX[0, 1] && empty[1, 1])          // Top Middle
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 2.2
            if (hasX[2, 2])              /// Right Middle
            {
                if (hasX[2, 1] && empty[2, 0])                      // Middle Bottom
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[2, 0] && empty[2, 1])             // Right Bottom
                {
                    pos[0] = 2;
                    pos[1] = 1;
                    return true;
                }
                if (hasX[1, 2] && empty[0, 2])             //Right Middle
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[0, 2] && empty[1, 2])          // Top Right
                {
                    pos[0] = 1;
                    pos[1] = 2;
                    return true;
                }
                if (hasX[1, 1] && empty[0, 0])       // Middle Middle
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasX[0, 0] && empty[1, 1])   // Top Left
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            return false;            
        }

        static bool WinPotential(ref int[] pos)
        {
            #region 0,0
            if (hasO[0, 0])                                          /// Left top
            {
                if (hasO[0, 1] && empty[0, 2])                      // Middle Top
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[0, 2] && empty[0, 1])             // Right Top
                {
                    pos[0] = 0;
                    pos[1] = 1;
                    return true;
                }
                if (hasO[1, 0] && empty[2, 0])             //Left Middle
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[2, 0] && empty[1, 0])          // Bottom Left
                {
                    pos[0] = 1;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[1, 1] && empty[2, 2])       // Middle Middle
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[2, 2] && empty[1, 1])   // Right bottom
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 0,1
            if (hasO[0, 1])                         /// Middle top
            {
                if (hasO[0, 0] && empty[0, 2])                      // Left Top
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[0, 2] && empty[0, 0])             // Right Top
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[1, 1] && empty[2, 1])             //Middle Middle
                {
                    pos[0] = 2;
                    pos[1] = 1;
                    return true;
                }
                if (hasO[2, 1] && empty[1, 1])          // Bottom Middle
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 0,2
            if (hasO[0, 2])                                  ///Right top
            {
                if (hasO[0, 1] && empty[0, 0])                      // Middle Top
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[0, 0] && empty[0, 1])             // Left Top
                {
                    pos[0] = 0;
                    pos[1] = 1;
                    return true;
                }
                if (hasO[1, 2] && empty[2, 2])             //Right Middle
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[2, 2] && empty[1, 1])          // Bottom Right
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
                if (hasO[1, 1] && empty[2, 0])       // Middle Middle
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[2, 0] && empty[1, 1])   // Right bottom
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 1,0
            if (hasO[1, 0])                                        /// Middle left
            {
                if (hasO[0, 0] && empty[2, 0])                      // Left Top
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[2, 0] && empty[0, 0])             // Left Bottom
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[1, 1] && empty[1, 2])             //Middle Middle
                {
                    pos[0] = 1;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[1, 2] && empty[1, 1])          // Middle Right
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 1,2
            if (hasO[1, 2])                                      ///Right Middle
            {
                if (hasO[0, 2] && empty[2, 2])                      // Right Top
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[2, 2] && empty[0, 2])             // Right Bottom
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[1, 1] && empty[1, 0])             //Middle Middle
                {
                    pos[0] = 1;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[1, 0] && empty[1, 1])          // Middle Left
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 2,0
            if (hasO[2, 0])                                      /// Left Bottom
            {
                if (hasO[2, 1] && empty[2, 2])                      // Middle Bottom
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[2, 2] && empty[2, 1])             // Right Bottom
                {
                    pos[0] = 2;
                    pos[1] = 1;
                    return true;
                }
                if (hasO[1, 0] && empty[0, 0])             //Left Middle
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[0, 0] && empty[1, 0])          // Left Top
                {
                    pos[0] = 1;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[1, 1] && empty[0, 2])       // Middle Middle
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[0, 2] && empty[1, 1])   // Right Top
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion 2,0

            #region 2,1
            if (hasO[2, 1])                              /// Middle Bottom
            {
                if (hasO[2, 2] && empty[2, 0])                      // Right Bottom
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[2, 0] && empty[2, 2])             // Left Bottom
                {
                    pos[0] = 2;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[1, 1] && empty[0, 1])             //Middle Middle
                {
                    pos[0] = 0;
                    pos[1] = 1;
                    return true;
                }
                if (hasO[0, 1] && empty[1, 1])          // Top Middle
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
                }
            }
            #endregion

            #region 2.2
            if (hasO[2, 2])              /// Right Middle
            {
                if (hasO[2, 1] && empty[2, 0])                      // Middle Bottom
                {
                    pos[0] = 2;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[2, 0] && empty[2, 1])             // Right Bottom
                {
                    pos[0] = 2;
                    pos[1] = 1;
                    return true;
                }
                if (hasO[1, 2] && empty[0, 2])             //Right Middle
                {
                    pos[0] = 0;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[0, 2] && empty[1, 2])          // Top Right
                {
                    pos[0] = 1;
                    pos[1] = 2;
                    return true;
                }
                if (hasO[1, 1] && empty[0, 0])       // Middle Middle
                {
                    pos[0] = 0;
                    pos[1] = 0;
                    return true;
                }
                if (hasO[0, 0] && empty[1, 1])   // Top Left
                {
                    pos[0] = 1;
                    pos[1] = 1;
                    return true;
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
