namespace Fitschool.Forms
{
    public partial class FormTicTacToe : Form
    {
        private readonly FormActiviteiten formActiviteiten;
        private User loggedInPlayer;
        private User secondPlayer;

        private Player currentPlayer;
        public User WinningPlayer { get; set; }

        public FormTicTacToe(FormActiviteiten formActiviteiten)
        {
            InitializeComponent();
            this.formActiviteiten = formActiviteiten;
            loggedInPlayer = formActiviteiten.user;
            currentPlayer = Player.X;
        }

        public enum Player //The loggin in player is always X, the second player is always O
        {
            X,
            O
        }

        private void Option_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
            CheckForWinner();
            // SUGESTION: Login second player and play against each other instead of against the computer
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
                    MessageBox.Show($"{text1} wins!");
                    WinningPlayer = text1 == "X" ? loggedInPlayer : secondPlayer;
                    return true;
                }
            }

            return false;
        }


    }
}
