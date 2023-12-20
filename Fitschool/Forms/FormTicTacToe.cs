using Fitschool.Classes.Activiteiten;

namespace Fitschool.Forms
{
    public partial class FormTicTacToe : Form
    {
        private Activity ActivityClass;

        private User loggedInPlayer;
        private User? secondPlayer;
        private TicTacToeAI? ai;

        private string playerOName;

        private Player currentPlayer;
        public User? WinningPlayer { get; set; }

        public FormTicTacToe(Activity ActivityClass ,User Player1, User Player2)
        {
            InitializeComponent();
            loggedInPlayer = Player1;
            secondPlayer = Player2;
            this.ActivityClass = ActivityClass;
            playerOName = secondPlayer.Name;
        }

        public FormTicTacToe(Activity ActivityClass, User Player1)
        {
            InitializeComponent();
            loggedInPlayer = Player1;
            this.ActivityClass = ActivityClass;
            ai = new TicTacToeAI(new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 });
            playerOName = "Computer";
        }

        private void FormTicTacToe_Load(object sender, EventArgs e)
        {
            labelPlayerX.Text = $"Speler X = {loggedInPlayer.Name}";
            labelPlayerO.Text = $"Speler O = {playerOName}";

            currentPlayer = Player.O; //Player X always starts, The next function switches the player to X, so we start with O.
            labelPlayerTurn.Text = UpdateCurrentPlayer();

            foreach (var button in Panel.Controls.OfType<Button>())
            {
                button.Text = "";
            }
        }

        public enum Player //The loggin in player is always X, the second player is always O
        {
            X,
            O
        }

        private int lastChosenButton = 0;

        private void Option_Click(object sender, EventArgs e) //handles the button clicks, checks for winner, switches player and plays AI if needed.
        {
            Button button = (Button)sender;
            SetButton(button);
            
            if (CheckForWinner())
            {
                ActivityClass.SetWinner(WinningPlayer ?? loggedInPlayer); this.Close();
            }

            labelPlayerTurn.Text = UpdateCurrentPlayer(); //Switches player

            if (secondPlayer == null && currentPlayer == Player.O) //If there is no second player, the AI will make a move
            {
                #pragma warning disable CS8602 // Possible null reference argument. The AI will never be null if there is no second player.
                Button? aiMove = ai.MakeMove(lastChosenButton);
                if (aiMove == null) { return; }
                aiMove.PerformClick();
                #pragma warning restore CS8602 // Possible null reference argument.
            }
        }

        private void SetButton(Button button)
        {
            if (currentPlayer == Player.X)
            {
                button.Text = "X";
                lastChosenButton = Convert.ToInt32(button.Name.Substring(6));
            }
            else
            {
                button.Text = "O";
            }
            button.Enabled = false;
        }

        private bool CheckForWinner()
        {
            // Define winning combinations (indices)
            int[][] winningCombinations = new int[][]
            {
                new int[] { 0, 1, 2 }, // Row 1
                new int[] { 3, 4, 5 }, // Row 2
                new int[] { 6, 7, 8 }, // Row 3
                new int[] { 0, 3, 6 }, // Column 1
                new int[] { 1, 4, 7 }, // Column 2
                new int[] { 2, 5, 8 }, // Column 3
                new int[] { 0, 4, 8 }, // Diagonal 1
                new int[] { 2, 4, 6 }  // Diagonal 2
            };

            Button[] gameButtons = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            foreach (var combination in winningCombinations)
            {
                int index1 = combination[0];
                int index2 = combination[1];
                int index3 = combination[2];

                string text1 = gameButtons[index1].Text;
                string text2 = gameButtons[index2].Text;
                string text3 = gameButtons[index3].Text;

                if (text1 != "" && text1 == text2 && text2 == text3)
                {
                    WinningPlayer = text1 == "X" ? loggedInPlayer : secondPlayer;
                    if (WinningPlayer == loggedInPlayer)
                    {
                        MessageBox.Show($"{ loggedInPlayer.Name} heeft gewonnen!");
                    }
                    else
                    {
                        MessageBox.Show($"{playerOName} heeft gewonnen!");
                    }
                    return true;
                }
            }
            if (CheckForDraw())
            {
                this.Close();
            }
            return false;
        }

        private bool CheckForDraw()
        {
            Button[] gameButtons = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (var button in gameButtons)
            {
                if (button.Text == "")
                {
                    return false;
                }
            }
            return true;
        }

        private string UpdateCurrentPlayer()
        {
            currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;

            string labelText = "";
            if (currentPlayer == Player.X)
            {
                labelText = $"{RemoveSurname(loggedInPlayer.Name)} is aan de beurt";
            }
            else
            {
                labelText = $"{RemoveSurname(playerOName)} is aan de beurt";
            }
            return labelText;
        }

        private string RemoveSurname(string name)
        {
            string[] splitName = name.Split(' ');
            return splitName[0];
        }


        //DEPRECATED, Improved Ai in TicTacToeAI.cs, this might still be useful for younger children, as it is a lot easier to beat.
        //private void AiPlay() //It's harder to lose from the AI than it is to win from it, let's say that's a feature
        //{
        //    Button[] gameButtons = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
        //    int[] bestButtons = new int[9];
        //    int bestButtonsCount = 0;

        //    // Mapping adjacent spots for each button
        //    List<List<int>> adjacentSpots = new List<List<int>>
        //    {
        //        new List<int> { 2, 4 },   // Button 1
        //        new List<int> { 1, 3, 5 },// Button 2
        //        new List<int> { 2, 6 },   // Button 3
        //        new List<int> { 1, 5, 7 },// Button 4
        //        new List<int> { 2, 4, 6, 8 }, // Button 5
        //        new List<int> { 3, 5, 9 },// Button 6
        //        new List<int> { 4, 8 },   // Button 7
        //        new List<int> { 5, 7, 9 },// Button 8
        //        new List<int> { 6, 8 }    // Button 9
        //    };

        //    // Finding adjacent spots to the player's last move
        //    List<int> adjacentToLastMove = new List<int>(adjacentSpots[lastChosenButton - 1]);

        //    for (int i = 0; i < gameButtons.Length; i++)
        //    {
        //        if (gameButtons[i].Text == "")
        //        {
        //            // If the button is adjacent to the player's last move, prioritize it
        //            if (adjacentToLastMove.Contains(i + 1))
        //            {
        //                bestButtons[bestButtonsCount] = i;
        //                bestButtonsCount++;
        //            }
        //        }
        //    }

        //    // If no adjacent spot is available, choose a random empty spot
        //    if (bestButtonsCount == 0)
        //    {
        //        for (int i = 0; i < gameButtons.Length; i++)
        //        {
        //            if (gameButtons[i].Text == "")
        //            {
        //                bestButtons[bestButtonsCount] = i;
        //                bestButtonsCount++;
        //            }
        //        }
        //    }

        //    Random random = new Random();
        //    int randomButton = random.Next(0, bestButtonsCount);
        //    gameButtons[bestButtons[randomButton]].PerformClick();
        //}
    }
}
