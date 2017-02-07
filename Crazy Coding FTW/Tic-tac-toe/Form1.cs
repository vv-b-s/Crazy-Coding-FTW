﻿using System;
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
        private void bt1_Click(object sender, EventArgs e)
        {
            BtClick(0, 0);
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            BtClick(0, 1);
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            BtClick(0, 2);
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            BtClick(1, 0);
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            BtClick(1, 1);
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            BtClick(1, 2);
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            BtClick(2, 0);
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            BtClick(2, 1);
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            BtClick(2, 2);
        }

        private void ngBT_Click(object sender, EventArgs e)
        {
            for(int i = 0;i<3;i++)
                for(int j =0;j<3;j++)
                {
                    AccessBT(i, j).Text = "";
                    AccessBT(i, j).Enabled = true;
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scoreC.Text = "0";
            scoreH.Text = "0";
        }
    }
}