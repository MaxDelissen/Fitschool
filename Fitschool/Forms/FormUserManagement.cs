using Fitschool.Classes;
using Fitschool.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Fitschool
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
            selectStyle.DataSource = Enum.GetValues(typeof(Card.CardDesigns));
        }

        static readonly string query = // Query uitvoeren om de gebruiker toe te voegen en de laatst ingevoegde ID ophalen
                @"
                    INSERT INTO gebruikers (gebruiker_id, naam, leeftijd, email_ouder)
                    SELECT COALESCE(MIN(gebruiker_id) + 1, 1), @naam, @leeftijd, @email
                    FROM gebruikers
                    WHERE NOT EXISTS (SELECT 1 FROM gebruikers t2 WHERE t2.gebruiker_id = gebruikers.gebruiker_id + 1);
                    SELECT gebruiker_id from gebruikers where naam = @naam and leeftijd = @leeftijd and email_ouder = @email
                ";

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            DataManagement.Log("Adding user");

            if (!ValidateInput())
            {
                return;
            }

            string naam = NameBox.Text;
            decimal leeftijd = LeeftijdSelector.Value;
            string email = textBoxEmail.Text;
            //adding user, and getting the last inserted ID
            int lastInsertID = Convert.ToInt32(new DataManagement().ExecuteQuery(query, new MySqlParameter("@naam", naam), new MySqlParameter("@leeftijd", leeftijd), new MySqlParameter("@email", email)));
            if (lastInsertID <= 0)
            {
                MessageBox.Show("Er is een fout opgetreden bij het toevoegen van de gebruiker.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataManagement.Log("Failed to add user, last insertedID <= 0");
                return;
            }

            User newUser = new(lastInsertID);

            MessageBox.Show($"De gebruiker is toegevoegd met id nummer {lastInsertID}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataManagement.Log($"User added with ID {lastInsertID}, name {naam}");

            Card designer = new(newUser);
            Bitmap card = designer.GenerateCard((Card.CardDesigns)selectStyle.SelectedItem);
            designer.SaveCard(card);
            //designer.PrintCard(card);
            DataManagement.Log($"Card generated for user {newUser}");
        }

        private void RemoveUserButton_Click(object sender, EventArgs e)
        {
            new DataManagement().RemoveUser(Convert.ToInt32(IdToDelete.Value));
        }

        private bool ValidateInput()
        {
            string naam = NameBox.Text;
            if (naam.Length > 50)
            {
                MessageBox.Show("De naam mag niet langer zijn dan 50 karakters.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataManagement.Log("Name too long: " + naam);
                return false;
            }

            if (!int.TryParse(LeeftijdSelector.Value.ToString(), out int _))
            {
                MessageBox.Show("De leeftijd moet een getal zijn.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DataManagement.Log("Invalid age entered: " + LeeftijdSelector.Value);
                return false;
            }

            string email = textBoxEmail.Text;
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DataManagement.Log("Invalid email entered");
                return false;
            }

            if (ContainsSQLInjection(naam) || ContainsSQLInjection(email))
            {
                Application.Exit();
                return false;
            }

            return true;
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                // Use Regex to check if the email is valid, the pattern consist of checking for characters; Before the @, after the @ and after the '.'.
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern);
            }
            catch (RegexMatchTimeoutException)
            {
                DataManagement.Log("Regex match timeout exception");
                return false;
            }
        }

        private bool ContainsSQLInjection(string input)
        {
            
            if (input.Contains(";"))
            {
                DataManagement.Log($"------------------SQL Injection detected!------------------\nExiting...");
                MessageBox.Show("SQL injection detected, this will be reported and the application will now close.", "SQL Injection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            
            return false;
        }
    }
}
