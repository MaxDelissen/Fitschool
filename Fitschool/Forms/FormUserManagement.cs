using System.Text.RegularExpressions;

namespace Fitschool
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            string naam = NameBox.Text;
            int leeftijd = Convert.ToInt32(LeeftijdSelector.Value);
            string Email = string.Empty;
            if (IsValidEmail(textBoxEmail.Text))
            {
                Email = textBoxEmail.Text;
                DataManagement.AddUser(naam, leeftijd, Email);
            }
            else
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoveUserButton_Click(object sender, EventArgs e)
        {
            DataManagement.RemoveUser(Convert.ToInt32(IdToDelete.Value));
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Use Regex to check if the email is valid, the pattern consist of checking for characters; Before the @, after the @ and after the '.'.
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
