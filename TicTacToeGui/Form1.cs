using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

using TicTacToe;

namespace TicTacToeGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            disableBtn(btn, "X");
            Game game = new Game(CheckButtons());
            
            if(game.WinCheck() == 0)
            {
                System.Windows.Forms.MessageBox.Show("You won???");
                return;
            }
            if (game.DrawCheck())
            {
                System.Windows.Forms.MessageBox.Show("Draw");
                return;
            }
            int nextMove = game.NextMove();
            Debugger.Log(1, "nextMove", nextMove + "");
            if(nextMove == -1)
            {
                System.Windows.Forms.MessageBox.Show("-1");
                return;
            }
            Control[] ctrl = this.Controls.Find("button" + nextMove, true);
            Button aiBtn = (Button)ctrl[0];
            disableBtn(aiBtn, "O");
            game.Turns = CheckButtons();
            int temp = game.WinCheck();
            if (game.WinCheck() == 1)
            {
                System.Windows.Forms.MessageBox.Show("You lost!");
                //System.Diagnostics.Process.Start(Application.ExecutablePath);
                //this.Close(); //to turn off current app
                return;
            }
            if (game.DrawCheck())
            {
                System.Windows.Forms.MessageBox.Show("Draw");
                return;
            }
        }

        private int[] CheckButtons()
        {
            int[] currentPlaces = new int[9];
            for(int i = 0; i<9; i++)
            {
                Control[] ctrl = this.Controls.Find("button"+i, true);
                Button btn = (Button)ctrl[0];
                Debugger.Log(1, "buttontext", btn.Text);
                if (btn.Text == "")
                {
                    currentPlaces[i] = -1;
                }
                else if(btn.Text.ToLower() == "x")
                {
                    currentPlaces[i] = 0;
                }
                else
                {
                    currentPlaces[i] = 1;
                }
            }
            return currentPlaces;
        }

        private void disableBtn(Button btn, String str)
        {
            btn.Enabled = false;
            btn.Text = str;
            btn.BackColor = Color.AntiqueWhite;
        }
    }
}
