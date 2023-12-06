using Fitschool.Classes;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Fitschool
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
            selectStyle.DataSource = Enum.GetValues(typeof(CardDesign.CardDesigns));
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
            string naam = NameBox.Text;
            int leeftijd = Convert.ToInt32(LeeftijdSelector.Value);
            string email = textBoxEmail.Text;
            if (IsValidEmail(email))
            {
                string newIdString = DataManagement.ExecuteQuery(query, new MySqlParameter("@naam", naam), new MySqlParameter("@leeftijd", leeftijd), new MySqlParameter("@email", email));
                int lastInsertID = Convert.ToInt32(newIdString);

                if (lastInsertID > 0)
                {
                    MessageBox.Show($"Gebruiker succesvol toegevoegd. ID: {lastInsertID}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CardDesign designer = new CardDesign(newIdString);
                    designer.name = naam;
                    Bitmap card = designer.GenerateCard((CardDesign.CardDesigns)selectStyle.SelectedItem);
                    designer.SaveCard(card);
                    //designer.PrintCard(card);
                }
                else MessageBox.Show("Er is een fout opgetreden bij het toevoegen van de gebruiker.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                return false;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
