using Fitschool.Forms;

namespace Fitschool.Classes.Activiteiten
{
    public class DorDt
    {
        static readonly string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static readonly string templateFilePath = Path.Combine(appDirectory, "D of DT.txt");

        public List<Question> Questions { get; set; }
        private int amountOfQuestions = 20;

        public DorDt()
        {
            Questions = GetQuestions();
            amountOfQuestions = Questions.Count;
        }

        public Question GetRandomQuestion()
        {
            Random random = new();
            int index = random.Next(0, amountOfQuestions);

            Question q = Questions[index];
            Questions.RemoveAt(index);
            amountOfQuestions--;
            if (amountOfQuestions <= 0)
            {
                Questions = GetQuestions();
                amountOfQuestions = Questions.Count;
            }
            return q;
        }

        private List<Question> GetQuestions()
        {
            List<Question> questions = new();

            string[] lines = File.ReadAllLines(templateFilePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                string question = parts[0];

                string option1 = parts[1];
                string option2 = parts[2];
                string option3 = parts[3];

                string correctOption = parts[4];

                Question q = new(question, option1, option2, option3, correctOption);
                questions.Add(q);
            }

            return questions;
        }
    }
}
