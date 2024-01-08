namespace Fitschool.Classes.Activiteiten
{
    public class MathGame
    {
        readonly int userGrade;

        public MathGame(int userGrade)
        {
            this.userGrade = userGrade;
        }

        public enum MathOperator
        {
            Addition = '+',
            Subtraction = '-',
            Multiplication = '*',
            Division = '/'
        }

        int lastNumber1 = 0;
        int lastNumber2 = 0;
        MathOperator lastOperator;


        public string AskQuestion()
        {
            lastOperator = GetRandomOperator(userGrade);
            lastNumber1 = GetRandomNumber(lastOperator);
            lastNumber2 = GetRandomNumber(lastOperator);

            FixQuestion();

            return $"{lastNumber1} {(char)lastOperator} {lastNumber2}";
        }

        private void FixQuestion()
        {
            if (lastOperator == MathOperator.Subtraction && lastNumber1 < lastNumber2)
            { //If the subtraction result is negative, change the numbers to make it positive.
                int temp = lastNumber1;
                lastNumber1 = lastNumber2;
                lastNumber2 = temp;
            }

            while (!DevisionCheck())
            {
                // Keep generating new numbers until the division is a whole number
            }
        }

        private bool DevisionCheck()
        {
            if (lastOperator == MathOperator.Division && lastNumber1 % lastNumber2 != 0)
            {
                lastNumber1 = GetRandomNumber(lastOperator);
                lastNumber2 = GetRandomNumber(lastOperator);
                return false;
            }
            return true;
        }

        public int Awnser
        {
            get
            {
                return (int)Calculate(lastNumber1, lastNumber2, ((char)lastOperator).ToString());
            }
            private set { }
        }

        public bool CheckAnswer(float answerUser)
        {
            return answerUser == Calculate(lastNumber1, lastNumber2, ((char)lastOperator).ToString());
        }

        private MathOperator GetRandomOperator(int userGrade)
        {
            Random random = new Random();
            Array operators;

            // Groepen 1, 2 en 3 mogen alleen optellen en aftrekken
            if (userGrade <= 3)
            {
                operators = new MathOperator[] { MathOperator.Addition, MathOperator.Subtraction };
            }
            else
            {
                // Alle operatoren zijn toegestaan voor hogere groepen
                operators = Enum.GetValues(typeof(MathOperator));
            }

            // Selecteer willekeurig een operator uit de beschikbare lijst
#pragma warning disable CS8605 // Unboxing a possibly null value. This is intended behaviour, the value can't be null.
            MathOperator randomOperator = (MathOperator)operators.GetValue(random.Next(operators.Length));
            return randomOperator;
#pragma warning restore CS8605 // Unboxing a possibly null value.
        }


        private int GetRandomNumber(MathOperator mathOperator)
        {
            int number;
            Random random = new Random();
            if (mathOperator == MathOperator.Addition || mathOperator == MathOperator.Subtraction) // Optellen en aftrekken
            {
                switch (userGrade)
                {
                    case 1:
                    case 2:
                        number = random.Next(1, 11); // Tot 10 voor groep 1 en 2
                        break;
                    case 3:
                    case 4:
                        number = random.Next(1, 21); // Tot 20 voor groep 3 en 4
                        break;
                    case 5:
                        number = random.Next(1, 101); // Tot 100 voor groep 5
                        break;
                    case 6:
                        number = random.Next(1, 201); // Tot 200 voor groep 6
                        break;
                    default:
                        number = random.Next(1, 1001); // Tot 1000 voor groep 7 en 8 (standaard)
                        break;
                }
            }
            else // Vermenigvuldigen en delen
            {
                switch (userGrade)
                {
                    case 1:
                    case 2:
                    case 3:
                        number = 0; // Geen vermenigvuldigingen voor groep 1, 2 en 3
                        break;
                    case 4:
                        number = random.Next(1, 6); // Tot 5 voor groep 4
                        break;
                    case 5:
                        number = random.Next(1, 11); // Tot 10 voor groep 5
                        break;
                    case 6:
                        number = random.Next(1, 21); // Tot 20 voor groep 6
                        break;
                    default:
                        number = random.Next(1, 101); // Tot 100 voor groep 7 en 8 (standaard)
                        break;
                }
            }
            return number;
        }

        public double Calculate(int number1, int number2, string operatorUser)
        {
            switch (operatorUser)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number1 - number2;
                case "*":
                    return number1 * number2;
                case "/":
                    return number1 / number2;
                default:
                    return 0;
            }
        }
    }
}
