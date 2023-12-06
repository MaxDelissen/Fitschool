namespace Fitschool.Forms
{
    public partial class AdminLogin : Form
    {
        readonly bool unlocked = false;

        public AdminLogin(bool unlocked)
        {
            InitializeComponent();
            this.unlocked = unlocked;
        }

        static readonly string storedPassword = "admin";

        private void SubmitPasswordButton_Click(object sender, EventArgs e)
        {
            string password = passwordBox.Text;
            if (password == storedPassword)
            {
                OpenUserManagement();
            }
            else
            {
                MessageBox.Show("Wachtwoord is onjuist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenUserManagement()
        {
            new FormUserManagement().Show();
            this.Close();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            if (unlocked)
            {
                OpenUserManagement();
            }
        }
    }
}
