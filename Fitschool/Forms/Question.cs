namespace Fitschool.Forms
{
    public class Question
    {
        public string QuestionName { get; private set; }
        public string CorrectAnswer { get; private set; }

        public string Option1 { get; private set; }
        public string Option2 { get; private set; }
        public string Option3 { get; private set; }

        public Question(string question, string option1, string option2, string option3, string Awnser)
        {
            QuestionName = question;
            CorrectAnswer = Awnser;

            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
        }

        public int GetCorrectOption()
        {
            if (CorrectAnswer == Option1)
            {
                return 1;
            }
            else if (CorrectAnswer == Option2)
            {
                return 2;
            }
            else if (CorrectAnswer == Option3)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }
}
