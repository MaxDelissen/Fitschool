using Fitschool.Forms;

namespace Fitschool
{
    public partial class Form1 : Form
    {
        User? CurrentUser;

        public Form1()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            IdBox.KeyPress += IdBox_KeyPressed;
        }

        private void OpenUserManagementButton_Click(object sender, EventArgs e)
        {
            DataManagement.Log("Opening loggedInUser management using button");
            AdminLogin adminLogin = new(false);
            adminLogin.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DataManagement.Log("Exiting application using exit button");
            Application.Exit();
        }

        private void IdBox_KeyPressed(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Check if Enter key is pressed
            {
                e.Handled = true;
                string input = IdBox.Text;

                switch (input)
                {
                    case "": return;

                    case "admin":
                        DataManagement.Log("Opening loggedInUser management using QR code");
                        AdminLogin adminLogin = new(true);
                        adminLogin.ShowDialog();
                        IdBox.Clear();
                        return;

                    case "exit":
                        DataManagement.Log("Exiting application using QR code");
                        Application.Exit();
                        IdBox.Clear();
                        return;
                    case "rand":
                        DataManagement.Log("Logging in as random User using QR code");
                        CurrentUser = RandomUser();
                        IdBox.Clear();
                        Keuzescherm keuze = new(this, CurrentUser);
                        keuze.Show();
                        this.Hide();
                        return;
                    default:
                        try
                        {
                            int userId = Convert.ToInt32(input);
                            if (userId <= int.Parse(new DataManagement().ExecuteQuery("SELECT MAX(gebruiker_id) AS highest FROM gebruikers;"))) // Check if loggedInUser exists
                            {
                                CurrentUser = new User(userId);
                                Keuzescherm keuzescherm = new(this, CurrentUser);
                                keuzescherm.Show();
                                this.Hide();
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
        }

        private User RandomUser() //this functions only purpose is to have a function which returns an object, this is to meet the Verdieping requirements.
        {
            DataManagement DB = new();
            int maxId = int.Parse(DB.ExecuteQuery("SELECT MAX(gebruiker_id) AS highest FROM gebruikers;"));
            int userId = new Random().Next(1, maxId + 1);
            return new User(userId);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = IdBox;
        }
    }
}