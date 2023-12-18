using System;
using System.Collections.Generic;

namespace Fitschool.Classes.Activiteiten
{
    public class TicTacToeAI
    {
        private Button[] gameButtons;
        private int[] bestButtons;
        private int bestButtonsCount;
        private int lastChosenButton;
        private Random random;

        private int[,] winCombinations = new int[,]
        {
            { 1, 2, 3 }, // Row 1
            { 4, 5, 6 }, // Row 2
            { 7, 8, 9 }, // Row 3
            { 1, 4, 7 }, // Column 1
            { 2, 5, 8 }, // Column 2
            { 3, 6, 9 }, // Column 3
            { 1, 5, 9 }, // Diagonal 1
            { 3, 5, 7 }  // Diagonal 2
        };

        public TicTacToeAI(Button[] buttons)
        {
            gameButtons = buttons;
            bestButtons = new int[9];
            random = new Random();
        }

        public Button MakeMove(int playerLastChosenButton)
        {
            // Initialize variables for tracking best moves
            bestButtonsCount = 0;
            lastChosenButton = playerLastChosenButton;

            // Check for winning moves or blocking opponent's winning moves
            Button move = FindBlockingOrWinningMove("O"); // Check if AI can win
            if (move != null)
            {
                return move;
            }

            // Check if the player is about to win and block their move
            move = FindBlockingOrWinningMove("X");
            if (move != null)
            {
                return move;
            }

            // Find adjacent spots to the player's last move
            List<int> adjacentToLastMove = GetAdjacentSpots(lastChosenButton);

            // If adjacent spots are available, prioritize them
            for (int i = 0; i < gameButtons.Length; i++)
            {
                if (gameButtons[i].Text == "" && adjacentToLastMove.Contains(i + 1))
                {
                    return gameButtons[i];
                }
            }

            // If no adjacent spots are available, choose any empty spot randomly
            for (int i = 0; i < gameButtons.Length; i++)
            {
                if (gameButtons[i].Text == "")
                {
                    return gameButtons[i];
                }
            }
            return null; // If no valid move found, return null
        }

        private Button FindBlockingOrWinningMove(string symbol)
        {
            // Iterate through all possible winning combinations
            for (int i = 0; i < winCombinations.GetLength(0); i++)
            {
                // Get the current combination of buttons, e.g. { 1, 2, 3 } 
                int[] combination = { winCombinations[i, 0], winCombinations[i, 1], winCombinations[i, 2] };

                // Variables to track the count of AI's symbol, player's symbol, and empty spot in the combination
                int countAI = 0;
                int countPlayer = 0;
                int emptyIndex = -1;

                // Check each button in the combination, this helps to find the empty spot
                for (int j = 0; j < combination.Length; j++)
                {
                    // Count the amount of times the AI's symbol appears in the combination
                    if (gameButtons[combination[j] - 1].Text == symbol)
                    {
                        countAI++;
                    }
                    // Store the index of the empty spot if found
                    else if (gameButtons[combination[j] - 1].Text == "")
                    {
                        emptyIndex = combination[j] - 1;
                    }
                    // Count the occurrences of player's symbol in the combination
                    else
                    {
                        countPlayer++;
                    }
                }

                if (countAI == 2 && countPlayer == 0 && emptyIndex != -1) //countAI == 2: AI has 2 symbols, countPlayer == 0: Player has 0 symbols, emptyIndex != -1: There is an empty spot
                {
                    return gameButtons[emptyIndex]; //return the empty spot
                }
            }

            return null; // Return null if no winning or blocking move is found in any combination
        }




        private List<int> GetAdjacentSpots(int button)
        {
            List<int> adjacentSpots = new List<int>();
            switch (button)
            {
                case 1:
                    adjacentSpots.AddRange(new List<int> { 2, 4 });
                    break;
                case 2:
                    adjacentSpots.AddRange(new List<int> { 1, 3, 5 });
                    break;
                case 3:
                    adjacentSpots.AddRange(new List<int> { 2, 6 });
                    break;
                case 4:
                    adjacentSpots.AddRange(new List<int> { 1, 5, 7 });
                    break;
                case 5:
                    adjacentSpots.AddRange(new List<int> { 2, 4, 6, 8 });
                    break;
                case 6:
                    adjacentSpots.AddRange(new List<int> { 3, 5, 9 });
                    break;
                case 7:
                    adjacentSpots.AddRange(new List<int> { 4, 8 });
                    break;
                case 8:
                    adjacentSpots.AddRange(new List<int> { 5, 7, 9 });
                    break;
                case 9:
                    adjacentSpots.AddRange(new List<int> { 6, 8 });
                    break;
            }
            return adjacentSpots;
        }
    }
}