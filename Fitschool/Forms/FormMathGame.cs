using Fitschool.Classes.Activiteiten;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitschool.Forms
{
    public partial class FormMathGame : Form
    {
        MathGame mathGame;
        public FormMathGame(int userGrade)
        {
            mathGame = new MathGame(userGrade);
            InitializeComponent();
            answerBox.KeyDown += Key_Pressed;
        }

        private void FormMathGame_Load(object sender, EventArgs e)
        {
            questionLabel.Text = mathGame.AskQuestion();
        }

        private void Key_Pressed(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submitButton_Click(sender, e);
            }
        }   

        public int points = 0;
        private int retries = 0;

        private void submitButton_Click(object? sender, EventArgs e)
        {
            float answer = float.Parse(answerBox.Text);
            if (mathGame.CheckAnswer(answer))
            {
                points++;
                MessageBox.Show("Goed gedaan!");
                answerBox.Clear();
                answerBox.Focus();
                questionLabel.Text = mathGame.AskQuestion();
            }
            else
            {
                answerBox.Clear();
                retries++;
                if (retries >= 3)
                {
                    MessageBox.Show("Helaas, je hebt het 3 keer fout, het goede antwoord was: " + mathGame.Awnser);
                    questionLabel.Text = mathGame.AskQuestion();
                }
                else MessageBox.Show("Helaas, probeer het nog eens!");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
