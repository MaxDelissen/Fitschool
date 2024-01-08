using Fitschool.Classes.Activiteiten;

namespace Fitschool.Forms
{
    public partial class FormChooseLanguageGame : Form
    {
        public FormChooseLanguageGame()
        {
            InitializeComponent();
        }

        public LanguageGames GetSelectedGame()
        {
            return (LanguageGames)gameSelector.SelectedItem;
        }

        public LanguageGames SelectedGame { get; private set; }

        private void FormChooseLanguageGame_Load(object sender, EventArgs e)
        {
            gameSelector.DataSource = Enum.GetValues(typeof(LanguageGames));
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            SelectedGame = GetSelectedGame();
            this.Close();
        }
    }
}
