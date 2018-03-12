using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotsAndBoxes
{
    public partial class FrmDAB : Form
    {
        private int mainCounter;
        private int playerOneScore;
        private int playerTwoScore;

        public FrmDAB()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mainCounter = 0;
            playerOneScore = 0;
            playerTwoScore = 0;

            foreach (Control c in Controls)
            {
                if (c.Name.Count() == 1)
                {
                    c.Text = "";
                }
            }
        }


        private void label_Click(object sender, EventArgs eventArgs)
        {
            //Evens are player 1, odds are player 2.

            ((Label)sender).BackColor = PlayerColor();

            var firstLabelLetter = ((Label)sender).Name.Substring(0, 1);
            var secondLabelLetter = ((Label)sender).Name.Substring(1, 1);


            if (CheckBox(firstLabelLetter))
            {
                CompleteBox(firstLabelLetter);
            }

            if (!char.IsDigit(secondLabelLetter.FirstOrDefault()))
            {
                if (CheckBox(secondLabelLetter))
                {
                    CompleteBox(secondLabelLetter);
                }
            }
            mainCounter++;
        }

        public bool CheckBox(string letter)
        {
            var boxSides = Controls.OfType<Label>().Where(x => x.Name.Contains(letter) && x.Name.Count() == 2).ToList();

            var counter = 0;
            foreach (Label a in boxSides)
            {
                if (a.BackColor != Color.White) counter++;
            }
            return (counter == 4);
        }

        public void CompleteBox(string letter)
        {
            Controls.OfType<Label>().Where(x => x.Name == letter).FirstOrDefault().Text = "W";
            Controls.OfType<Label>().Where(x => x.Name == letter).FirstOrDefault().ForeColor = PlayerColor();

            if (mainCounter % 2 == 0)
                playerOneScore++;
            else
                playerTwoScore++;

            lbl1Score.Text = playerOneScore.ToString();
            lbl2Score.Text = playerTwoScore.ToString();

            if (playerOneScore == 9)
            {
                MessageBox.Show("Player 1 has won!");
                return;
            }
            if (playerTwoScore == 9)
            {
                MessageBox.Show("Player 2 has won!");
                return;
            }
        }
        public Color PlayerColor()
        {
            return (mainCounter % 2 == 0) ? Color.Red : Color.Blue;
        }           
    }
}