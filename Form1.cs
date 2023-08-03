using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        // enumeration for controlling symbols for both players(user and system)
        public enum Player
        {
            X, O
        }

        List<Button> buttons; // creating a LIST or array of buttons
        Random rand = new Random();
        int playerWins = 0;
        int computerWins = 0;
        public Form1()
        {
            InitializeComponent();
            resetGame();
        }
        private void PlayerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Text = "X";
            button.Enabled = false;
            buttons.Remove(button); //remove the button from the list buttons so the AI can't click it either
            Check();
            SystemMoves.Start();
        }

        private void SyatemMove(object sender, EventArgs e)
        {
            // THE CPU will randomly choose a button from the list to click. 
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count); // generate a random number within the number of buttons available
                buttons[index].Enabled = false;
                buttons[index].Text = "O";
                //buttons.RemoveAt(index); // remove that button from the list
                buttons.Remove(buttons[index]);
                Check();
                SystemMoves.Stop();
            }
        }

        private void restartGame(object sender, EventArgs e)
        {
            resetGame();
        }

        private void loadbuttons()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button9, button8 };
        }

        private void resetGame()
        {
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true;
                    ((Button)X).Text = "";
                }
            }
            loadbuttons();
        }

        private void Check()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                SystemMoves.Stop();
                playerWins++;
                label1.Text = "Player Wins- " + playerWins;
                resetGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                SystemMoves.Stop();
                computerWins++;
                label2.Text = "System Wins- " + computerWins;
                resetGame();
            }
            else if ((button1.Text == "X" || button1.Text == "O")
                && (button2.Text == "X" || button2.Text == "O")
                && (button3.Text == "X" || button3.Text == "O")
                && (button4.Text == "X" || button4.Text == "O")
                && (button5.Text == "X" || button5.Text == "o")
                && (button6.Text == "X" || button6.Text == "O")
                && (button7.Text == "X" || button7.Text == "")
                && (button8.Text == "X" || button8.Text == "O")
                && (button9.Text == "X" || button9.Text == "O"))
            {
                this.label3.Text = "Match Draw" ;
                SystemMoves.Stop();
                resetGame();
            }
        }
    }
}
