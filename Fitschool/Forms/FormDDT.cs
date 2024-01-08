using Fitschool.Forms;

namespace Fitschool.Classes.Activiteiten
{
    public partial class FormDDT : Form
    {
        private readonly DorDt Domain;
        public int punten { get; private set; } = 0;

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
                MessageBox.Show("Goed gedaan!");
                PuntVerdient();
            }
            else
            {
                MessageBox.Show($"Helaas, dit antwoord is niet correct, het juiste antwoord was {(correctButton ?? new Button()).Text}.");
            }
            SetQuestion();
        }

        private void PuntVerdient()
        {
            punten++;
            labelPoints.Text = $"Punten: {punten}";
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.forceclose();

        }
        private void forceclose()
        {
            this.Close();
        }
    }
}
