using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AI;

namespace Tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            scoreC.Text = "0";
            scoreH.Text = "0";
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    AccessBT(i, j).BackColor = Control.DefaultBackColor;
        }

        private void ngBT_Click(object sender, EventArgs e)         // New Game
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    AccessBT(i, j).Text = "";
                    AccessBT(i, j).Enabled = true;
                    AccessBT(i, j).BackColor = Control.DefaultBackColor;
                }
            AI.AI.EmptyReset();

        }

        private Button AccessBT(params int[] b)
        {
            Button[,] bt =
            {
                {bt1,bt2,bt3 },
                {bt4,bt5,bt6 },
                {bt7,bt8,bt9 },
            };

            return bt[b[0], b[1]];
        }

        private void BtClick(params int[] position)
        {
            AccessBT(position[0], position[1]).Text = "X";
            AccessBT(position[0], position[1]).Enabled = false;
        }

        private void PlaceO()
        {
            string[,] bt =
            {
                {bt1.Text,bt2.Text,bt3.Text },
                {bt4.Text,bt5.Text,bt6.Text },
                {bt7.Text,bt8.Text,bt9.Text },
            };

            bool canRun = false;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (AccessBT(i, j).Enabled)
                        canRun = true;

            if (canRun&&!CheckWin())
            {
                AI.AI.Check(bt);
                int[] pastePosition = AI.AI.GenerateO();
                AccessBT(pastePosition[0], pastePosition[1]).Text = "O";
                AccessBT(pastePosition[0], pastePosition[1]).Enabled = false;
                CheckWin();
            }
        }
        private void bt1_Click(object sender, EventArgs e)
        {
            BtClick(0, 0);
            PlaceO();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            BtClick(0, 1);
            PlaceO();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            BtClick(0, 2);
            PlaceO();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            BtClick(1, 0);
            PlaceO();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            BtClick(1, 1);
            PlaceO();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            BtClick(1, 2);
            PlaceO();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            BtClick(2, 0);
            PlaceO();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            BtClick(2, 1);
            PlaceO();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            BtClick(2, 2);
            PlaceO();
        }

        private bool CheckWin()
        {
            int X = 0;
            int O = 0;

            for (int i = 0; i < 3; i++)                             //line
            {
                for (int j = 0; j < 3; j++)
                {
                    if (AccessBT(i, j).Text == "X")
                        X++;
                    else if (AccessBT(i, j).Text == "O")
                        O++;
                }
                if (O == 3)
                {
                    for (int k = 0; k < 3; k++)
                        AccessBT(i, k).BackColor = Color.OrangeRed;
                    scoreC.Text = (int.Parse(scoreC.Text) + 1).ToString();

                    DisableButtons();
                    return true;
                }
                else if (X == 3)
                {
                    for (int k = 0; k < 3; k++)
                        AccessBT(i, k).BackColor = Color.GreenYellow;
                    scoreH.Text = (int.Parse(scoreH.Text) + 1).ToString();

                    DisableButtons();
                    return true;
                }
                else
                {
                    X = 0;
                    O = 0;
                }
            }

            for (int i = 0; i < 3; i++)                             //Colomn
            {
                for (int j = 0; j < 3; j++)
                {
                    if (AccessBT(j, i).Text == "X")
                        X++;
                    else if (AccessBT(j, i).Text == "O")
                        O++;
                }
                if (O == 3)
                {
                    for (int k = 0; k < 3; k++)
                        AccessBT(k, i).BackColor = Color.OrangeRed;
                    scoreC.Text = (int.Parse(scoreC.Text) + 1).ToString();


                    DisableButtons();
                    return true;
                }
                else if (X == 3)
                {
                    for (int k = 0; k < 3; k++)
                        AccessBT(k, i).BackColor = Color.GreenYellow;
                    scoreH.Text = (int.Parse(scoreH.Text) + 1).ToString();

                    DisableButtons();
                    return true;
                }
                else
                {
                    X = 0;
                    O = 0;
                }
            }

            #region Diagonal 1
            for(int i=0;i<3;i++)
            {
                if (AccessBT(i, i).Text == "X")
                    X++;
                else if (AccessBT(i, i).Text == "O")
                    O++;
            }

            if (O == 3)
            {
                AccessBT(0, 0).BackColor = Color.OrangeRed;
                AccessBT(1, 1).BackColor = Color.OrangeRed;
                AccessBT(2, 2).BackColor = Color.OrangeRed;
                scoreC.Text = (int.Parse(scoreC.Text) + 1).ToString();

                DisableButtons();
                return true;
            }
            else if (X == 3)
            {
                AccessBT(0, 0).BackColor = Color.GreenYellow;
                AccessBT(1, 1).BackColor = Color.GreenYellow;
                AccessBT(2, 2).BackColor = Color.GreenYellow;
                scoreH.Text = (int.Parse(scoreH.Text) + 1).ToString();

                DisableButtons();
                return true;
            }
            else
            {
                X = 0;
                O = 0;
            }
            #endregion

            #region Diagonal 2
            for(int i =0,j=2;i<3;j--,i++)
            {
                if (AccessBT(i, j).Text == "X")
                    X++;
                else if (AccessBT(i, j).Text == "O")
                    O++;
            }

            if (O == 3)
            {
                AccessBT(0, 2).BackColor = Color.OrangeRed;
                AccessBT(1, 1).BackColor = Color.OrangeRed;
                AccessBT(2, 0).BackColor = Color.OrangeRed;
                scoreC.Text = (int.Parse(scoreC.Text) + 1).ToString();

                DisableButtons();
                return true;
            }
            else if (X == 3)
            {
                AccessBT(0, 2).BackColor = Color.GreenYellow;
                AccessBT(1, 1).BackColor = Color.GreenYellow;
                AccessBT(2, 0).BackColor = Color.GreenYellow;
                scoreH.Text = (int.Parse(scoreH.Text) + 1).ToString();

                DisableButtons();
                return true;
            }
            else
            {
                X = 0;
                O = 0;
            }

            if (X == 0 && O == 0)
                return false;

            return true;
            #endregion
        }

        private void DisableButtons()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    AccessBT(i, j).Enabled = false;
        }
    }
}
