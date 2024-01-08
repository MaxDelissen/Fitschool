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

        public enum ConfirmStatus
        {
            Succes,
            NotEnoughPoints,
            InvalidEmail,
            emailNotSent
        }

        public ConfirmStatus Confirm()
        {
            if (!IsValidEmail()) { return ConfirmStatus.InvalidEmail; }
            if (!EnoughPoints()) { return ConfirmStatus.NotEnoughPoints; }

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

            if (!SendMail(onderwerp, bericht)) { return ConfirmStatus.emailNotSent; }

            Products.Clear();
            TotalPrice = 0;
            return ConfirmStatus.Succes;
        }

        public bool EnoughPoints()
        {
            return user.Points >= TotalPrice;
        }

        public bool IsValidEmail()
        {
            return !string.IsNullOrEmpty(user.EmailParents) && user.EmailParents.Contains("@") && user.EmailParents.Contains(".");
        }

        private bool SendMail(string onderwerp, string bericht)
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
