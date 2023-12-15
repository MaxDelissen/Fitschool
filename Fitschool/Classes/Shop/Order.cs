using System.Net;
using System.Net.Mail;

namespace Fitschool.Classes.Shop
{
    internal class Order
    {
        public List<Product> Products { get; private set; }
        public int TotalPrice { get; private set; }

        private readonly User user;

        public Order(User user)
        {
            this.user = user;
            Products = new List<Product>();
        }

        public bool Add(Product product)
        {
            if (product.InStock())
            {
                TotalPrice += product.Price;
                Products.Add(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(Product product)
        {
            if (Products.Contains(product))
            {
                TotalPrice -= product.Price;
                Products.Remove(product);
                return true;
            }
            return false;
        }

        public void Confirm()
        {
            if (!IsValidEmail() || !EnoughPoints())
            {
                return;
            }

            foreach (Product product in Products) //remove products from stock
            {
                product.RemoveFromStock(1);
            }

            user.UpdatePoints(-TotalPrice);

            #region Email
            string onderwerp = "Bevestiging van bestelling bij Fitschool";
            string bericht = $"Beste ouder/verzorger van {user.Name},\n\n" +
                $"Uw kind heeft onlangs een bestelling geplaatst bij Fitschool.\n" +
                $"Fitschool is een initiatief op school waarbij kinderen door middel van opdrachten en oefeningen punten kunnen verdienen om diverse prijzen te kunnen kopen.\n" +
                $"We willen u laten weten dat er geen kosten zijn verbonden aan deze aankoop, en de producten zullen binnenkort op de school van uw kind worden afgeleverd.\n\n" +
                $"Uw bestelling:\n";

            foreach (Product product in Products)
            {
                bericht += $"- {product.Name}\n";
            }

            bericht += $"\nHet totaal aantal verdiende punten voor deze aankoop bedraagt: {TotalPrice}🪙\n\n" +
                $"Mocht u nog vragen hebben, aarzel dan niet om contact op te nemen met de school of een e-mail te sturen naar 'fitschool@hotmail.com'.\n\n" +
                $"Met vriendelijke groet,\nCasper Wijngaarden\nSupport & Marketing Director Fitschool";
            #endregion

            SendMail(onderwerp, bericht);

            MessageBox.Show("Je bestelling is geplaatst. Je ontvangt een email ter bevestiging.", "Bestelling geplaatst", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Products.Clear();
            TotalPrice = 0;
        }

        public bool EnoughPoints()
        {
            if (user.Points >= TotalPrice)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg punten om deze bestelling te plaatsen.", "Niet genoeg punten", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
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

        private void SendMail(string onderwerp, string bericht)
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
