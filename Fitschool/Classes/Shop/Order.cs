using System.Net;
using System.Net.Mail;

namespace Fitschool.Classes.Shop
{
    internal class Order
    {
        public List<Product> products { get; private set; }
        public int totalPrice { get; private set; }

        private User user;

        public Order(User user)
        {
            this.user = user;
            products = new List<Product>();
        }

        public int AddToOrder(int productID)
        {
            Product product = new Product(productID);

            if (product.InStock())
            {
                totalPrice += product.price;
                products.Add(product);
            }
            else
            {
                MessageBox.Show("Dit product is niet meer op voorraad.", "Niet op voorraad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return totalPrice;
        }

        public bool EnoughPoints()
        {
            if (user.Points >= totalPrice)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg punten om deze bestelling te plaatsen.", "Niet genoeg punten", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public void ConfirmOrder()
        {
            if (!IsValidEmail() || !EnoughPoints())
            {
                return;
            }

            foreach (Product product in products)
            {
                product.RemoveFromStock(1);
            }

            user.UpdatePoints(-totalPrice);

            #region Email bericht
            string onderwerp = "Bevestiging van bestelling bij Fitschool";
            string bericht = $"Beste ouder/verzorger van {user.Name},\n\n" +
                $"Uw kind heeft onlangs een bestelling geplaatst bij Fitschool.\n" +
                $"Fitschool is een initiatief op school waarbij kinderen door middel van opdrachten en oefeningen punten kunnen verdienen om diverse prijzen te kunnen kopen.\n" +
                $"We willen u laten weten dat er geen kosten zijn verbonden aan deze aankoop, en de producten zullen binnenkort op de school van uw kind worden afgeleverd.\n\n" +
                $"Uw bestelling:\n";

            foreach (Product product in products)
            {
                bericht += $"- {product.name}\n"; // Veronderstelde eigenschap voor productnaam is "Name"
            }

            bericht += $"\nHet totaal aantal verdiende punten voor deze aankoop bedraagt: {totalPrice}🪙\n\n" +
                $"Mocht u nog vragen hebben, aarzel dan niet om contact op te nemen met de school of een e-mail te sturen naar 'fitschool@hotmail.com'.\n\n" +
                $"Met vriendelijke groet,\nCasper Wijngaarden\nSupport & Marketing Director Fitschool";
            #endregion

            SendMail(onderwerp, bericht);
        }


        public bool IsValidEmail()
        {
            if (!string.IsNullOrEmpty(user.EmailParents))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Er is iets misgegaan met het ophalen van het email adres van je ouders. Vraag dit na aan je docent.", "Foutmelding", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

            MailMessage mail = new("fitschool@hotmail.com", user.EmailParents, onderwerp, bericht);

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
