using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;

namespace Fitschool.Classes
{
    internal class Order
    {
        public string productNaam { get; private set; }
        public int productPrijs { get; private set; }
        public int productVoorraad { get; private set; }
        public string email { get; private set; }
        private readonly int productId;

        public Order(int id)
        {
            productId = id;
            productNaam = DataManagement.ExecuteQuery("SELECT product_naam FROM producten WHERE product_id = @id", new MySqlParameter("@id", id));
            productPrijs = Convert.ToInt32(DataManagement.ExecuteQuery("SELECT product_prijs FROM producten WHERE product_id = @id", new MySqlParameter("@id", id)));
            productVoorraad = Convert.ToInt32(DataManagement.ExecuteQuery("SELECT product_voorraad FROM producten WHERE product_id = @id", new MySqlParameter("@id", id)));
            email = DataManagement.ExecuteQuery("SELECT email_ouder FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", UserData.LoggedInId));
        }

        public bool InStock()
        {
            if (productVoorraad > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Het spijt ons, maar dit product is niet meer op voorraad.", "Niet op voorraad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public bool EnoughPoints()
        {
            if (UserData.loggedInPoints >= productPrijs)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg punten om dit product te kopen.", "Niet genoeg punten", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public bool IsValidEmail()
        {
            if (!string.IsNullOrEmpty(email))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Er is iets misgegaan met het ophalen van het email adres van je ouders. Vraag dit na aan je docent.", "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void UpdateStock()
        {
            DataManagement.ExecuteQuery("UPDATE producten SET product_voorraad = @voorraad WHERE product_id = @id", new MySqlParameter("@voorraad", productVoorraad - 1), new MySqlParameter("@id", productId));
        }

        public void UpdatePoints()
        {
            UserData.loggedInPoints -= productPrijs; //punten verminderen in shop
            DataManagement.WritePointsToDB(UserData.LoggedInId, -productPrijs); // en in DB
        }

        public void SendMail(string onderwerp, string bericht)
        //Fitschool outlook account: fitschool@hotmail.com ==> Wachtwoord: LwKJT3b%@y4mRvq29F&4
        {
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587, // SMTP-poort voor Outlook.com met STARTTLS
                Credentials = new NetworkCredential("fitschool@hotmail.com", "LwKJT3b%@y4mRvq29F&4"),
                EnableSsl = true // STARTTLS-versleuteling inschakelen
            };

            MailMessage mail = new("fitschool@hotmail.com", email, onderwerp, bericht);

            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                MessageBox.Show("Er is iets fout gegaan met het verzenden van de email.\nWaarschijnlijk is het email adress niet correct.", "Mail niet verzonden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
