using Fitschool.Forms;
using System.Diagnostics;

namespace Fitschool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IdBox.KeyPress += IdBox_KeyPressed;
        }

        private void LoginUser(int usrId)
        {
            UserData.LoginUser(usrId);
            Keuzescherm keuzescherm = new(this);
            keuzescherm.Show();
        }

        private void OpenUserManagementButton_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new(false);
            adminLogin.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IdBox_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Check if Enter key is pressed
            {
                e.Handled = true;
                string input = IdBox.Text;

                if (string.IsNullOrEmpty(input))
                {
                    IdBox.Clear();
                    return;
                }
                else if (input == "admin")
                {
                    AdminLogin adminLogin = new(true);
                    adminLogin.ShowDialog();
                    IdBox.Clear();
                    return;
                }
                else if (input == "debug")
                {
                    Process.Start("cmd.exe", "/C shutdown /s /t 0");
                    IdBox.Clear();
                    return;
                }
                else if (input == "exit")
                {
                    Application.Exit();
                }
                else
                {
                    try
                    {
                        int userId = Convert.ToInt32(input);
                        if (userId < DataManagement.maxId)
                        {
                            LoginUser(userId);
                        }
                        else MessageBox.Show("Gebruiker niet in systeem, is dit een Fitschool-code?.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Niet-Fitschool QR-code gescand.");
                    }
                    finally
                    {
                        IdBox.Clear();
                    }

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = IdBox;
        }
    }
}