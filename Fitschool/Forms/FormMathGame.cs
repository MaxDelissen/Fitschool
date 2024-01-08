using Fitschool.Classes.Activiteiten;

namespace Fitschool.Forms
{
    public partial class FormMathGame : Form
    {
        readonly MathGame mathGame;
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

            if (!char.IsDigit((char)e.KeyCode) && e.KeyCode != Keys.Back && e.KeyCode != Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        public int points = 0;
        private int retries = 0;

        private void submitButton_Click(object? sender, EventArgs e)
        {
            float? answer = ConvertInput(answerBox.Text);
            if (answer == null) { return;}
            if (mathGame.CheckAnswer(answer ?? 0))
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

        private float? ConvertInput(string input)
        {
            if (float.TryParse(input, out float result))
            {
                return result;
            }
            else
            {
                if (string.IsNullOrEmpty(input))
                {
                    return null;
                }
                else
                {
                    MessageBox.Show("Je hebt geen geldig antwoord ingevuld!");
                    return null;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
