using Fitschool.Forms;

namespace Fitschool
{
    public partial class Form1 : Form
    {
        User? CurrentUser;

        public Form1()
        {
            InitializeComponent();
            IdBox.KeyPress += IdBox_KeyPressed;
        }

        private void OpenUserManagementButton_Click(object sender, EventArgs e)
        {
            DataManagement.Log("Opening user management using button");
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
                        DataManagement.Log("Opening user management using QR code");
                        AdminLogin adminLogin = new(true);
                        adminLogin.ShowDialog();
                        IdBox.Clear();
                        return;

                    case "exit":
                        DataManagement.Log("Exiting application using QR code");
                        Application.Exit();
                        IdBox.Clear();
                        return;

                    default:
                        try
                        {
                            int userId = Convert.ToInt32(input);
                            if (userId < DataManagement.maxId)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = IdBox;
        }
    }
}