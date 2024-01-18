using Fitschool.Forms;

namespace Fitschool.Classes.Activiteiten
{
    public partial class FormDDT : Form
    {
        private readonly DorDt Domain;
        private double punten = 0;
        public int Punten { get; private set; } = 0;

        public FormDDT()
        {
            InitializeComponent();
            Domain = new DorDt();
            SetQuestion();
        }

        private Button? correctButton;
        private void SetQuestion()
        {
            Question question = Domain.GetRandomQuestion();
            labelQuestion.Text = question.QuestionName;
            buttonOption1.Text = question.Option1;
            buttonOption2.Text = question.Option2;
            buttonOption3.Text = question.Option3;
            if (question.CorrectAnswer == question.Option1)
            {
                correctButton = buttonOption1;
            }
            else if (question.CorrectAnswer == question.Option2)
            {
                correctButton = buttonOption2;
            }
            else if (question.CorrectAnswer == question.Option3)
            {
                correctButton = buttonOption3;
            }
        }

        private void buttonOption_Click(object sender, EventArgs e)
        {
            if (sender == correctButton)
            {
                correct();
            }
            else
            {
                incorrect();
            }
        }

        private void correct()
        {
            new FormMessageBox("Goed gedaan!", "Fitschool", "???", true);
            ChangePoints(1);
            SetQuestion();
        }

        private void incorrect()
        {
            new FormMessageBox($"Helaas, dit antwoord is niet correct, het juiste antwoord was {(correctButton ?? new Button()).Text}.", "Incorrect", "???", true);
            ChangePoints(-0.25);
            SetQuestion();
        }

        private void ChangePoints(double amount)
        {
            if (amount < 0 && punten + amount < 0) //punten can't be negative, as this would discourage the user from playing the game. (as they lose points for playing)
            {
                punten = 0;
                labelPoints.Text = $"Punten: {DoubleToInt(punten)}";
                return;
            }
            punten += amount;
            labelPoints.Text = $"Punten: {DoubleToInt(punten)}";
        }

        private int DoubleToInt(double d)
        {
            return (int)Math.Round(d);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Punten = DoubleToInt(punten);
            this.Close();
        }
    }
}
