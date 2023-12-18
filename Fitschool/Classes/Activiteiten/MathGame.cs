﻿using Fitschool.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Fitschool.Classes.Activiteiten.MathGame;

namespace Fitschool.Classes.Activiteiten
{
    public class MathGame
    {
        int userGrade;
        FormMathGame formMathGame;

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

            if (lastOperator == MathOperator.Subtraction && lastNumber1 < lastNumber2)
            { //If the subtraction result is negative, change the numbers to make it positive.
                int temp = lastNumber1;
                lastNumber1 = lastNumber2;
                lastNumber2 = temp;
            }

            if (lastOperator == MathOperator.Division && lastNumber1 % lastNumber2 != 0) 
            {
                //If the division result is not a whole number, change the numbers to make it a whole number.
                //Problem: The result can be too big for the user to calculate, this still needs work.
                lastNumber1 = lastNumber2 * lastNumber1;
            }

            return $"{lastNumber1} {(char)lastOperator} {lastNumber2}";
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
            MathOperator randomOperator = (MathOperator)operators.GetValue(random.Next(operators.Length));
            return randomOperator;
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
                        number = random.Next(1, 21); // Tot 20 voor groep 1
                        break;
                    case 2:
                    case 3:
                        number = random.Next(1, 101); // Tot 100 voor groep 2
                        break;
                    case 4:
                        number = random.Next(1, 1001); // Tot 1.000 voor groep 4
                        break;
                    case 5:
                        number = random.Next(1, 10001); // Tot 10.000 voor groep 5
                        break;
                    case 6:
                        number = random.Next(1, 100001); // Tot 100.000 voor groep 6
                        break;
                    default:
                        number = random.Next(1, 1000000); // Tot 1.000.000 voor hogere groepen
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
                        number = 0; // Geen delingen of vermenigvuldigen voor groep 1, 2 en 3
                        break;
                    case 4:
                        number = random.Next(1, 11); // Tot 10 voor groep 4
                        break;
                    case 5:
                        number = random.Next(1, 13); // Tot 12 voor groep 5
                        break;
                    case 6:
                        number = random.Next(1, 21); // Tot 20 voor groep 6
                        break;
                    default:
                        number = random.Next(1, 101); // Tot 100 voor groep 7 en 8
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
