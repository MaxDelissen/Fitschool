using Fitschool.Forms;
using System;
using System.Diagnostics;

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
            AdminLogin adminLogin = new(false);
            adminLogin.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IdBox_KeyPressed(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // Check if Enter key is pressed
            {
                e.Handled = true;
                string input = IdBox.Text;

                switch (input) {
                case "": return;

                case "admin":
                    AdminLogin adminLogin = new(true);
                    adminLogin.ShowDialog();
                    IdBox.Clear();
                    return;

                case "debug":
                    Process.Start("cmd.exe", "/C shutdown /s /f /t 0");
                    return;

                case "exit": Application.Exit(); IdBox.Clear(); return;

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
                            MessageBox.Show("Gebruiker niet in systeem, is dit een Fitschool-code?.");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Niet-Fitschool QR-code gescand.");
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