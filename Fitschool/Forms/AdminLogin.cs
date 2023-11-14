namespace Fitschool.Forms
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        static readonly string storedPassword = "admin";

        private void SubmitPasswordButton_Click(object sender, EventArgs e)
        {
            string password = passwordBox.Text;
            if (password == storedPassword)
            {
                new FormUserManagement().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wachtwoord is onjuist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
