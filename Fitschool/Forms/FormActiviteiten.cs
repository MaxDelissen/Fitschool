using Fitschool.Classes.Activiteiten;

namespace Fitschool.Forms
{
    public partial class FormActiviteiten : Form
    {
        private readonly Keuzescherm keuzeScherm;
        public User loggedInUser { get; private set; }
        public User? secondUser { get; private set; } = null;

        public FormActiviteiten(Keuzescherm keuzeScherm, User user)
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            IdBox.KeyPress += IdBox_KeyPressed;

            this.keuzeScherm = keuzeScherm;
            this.loggedInUser = user;
        }

        private void FormActiviteiten_Load(object sender, EventArgs e)
        {
            IdBox.Focus();
        }

        private void buttonBackActiviteiten_Click(object sender, EventArgs e)
        {
            keuzeScherm.UpdatePoints();
            keuzeScherm.Show();
            this.Close();
        }

        #region multiplayer
        private void IdBox_KeyPressed(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Check if Enter key is pressed
            {
                e.Handled = true;
                string input = IdBox.Text;
                try
                {
                    int userId = Convert.ToInt32(input);
                    if (userId < int.Parse(new DataManagement().ExecuteQuery("SELECT MAX(gebruiker_id) AS highest FROM gebruikers;"))) // Check if loggedInUser exists
                    {
                        if (userId != loggedInUser.Id)
                        {
                            secondUser = new User(userId);
                            MessageBox.Show($"2e Speler toegevoegd! Welkom {secondUser.Name}");
                        } else MessageBox.Show("Je kan niet tegen jezelf spelen!");
                    }
                    else
                    {
                        DataManagement.Log("User not in Database, Scanned ID bigger then highest.");
                    }
                }
                catch (Exception)
                {
                    DataManagement.Log("Non-Fitschool QR-code scanned.");
                }
                finally
                {
                    IdBox.Clear();
                }
                return;
            }
        }

        public bool MultiplayerReady(User secondUser)
        {
            if (secondUser != null)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Scan de QR-code van een 2e speler om deze activiteit te starten.", "Scan QR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IdBox.Focus();
                return false;
            }
        }
        #endregion


        private void buttonPushUps_Click(object sender, EventArgs e)
        {
            Activity activity = new(ActivityType.PushUps, this);
            activity.StartActivity();
        }

        private void buttonTTT_Click(object sender, EventArgs e)
        {
            Activity activity = new(ActivityType.TicTacToe, this);
            activity.StartActivity();
            IdBox.Focus();
        }
    }
}