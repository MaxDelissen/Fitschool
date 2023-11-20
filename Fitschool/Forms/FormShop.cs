using Fitschool.Forms;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace Fitschool
{
    public partial class FormShop : Form
    {
        private Form mainForm;
        public FormShop(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadData();
        }

        private void FormShop_Load(object sender, EventArgs e)
        {
            labelTotalPoints.Text = $"{UserData.loggedInPoints.ToString()}🪙"; //het icoontje hierachter is een munt emoji teken
        }

        private void buttonBackShop_Click(object sender, EventArgs e)
        {
            var myForm = new Keuzescherm(mainForm);
            myForm.Show();
            this.Close();
        }

        readonly string[] productNaam = new string[9];
        readonly int[] productPrijs = new int[9];

        private void LoadData()
        {
            for (int i = 1; i <= 8; i++)
            {
                productNaam[i] = DataManagement.ExecuteQuery("SELECT product_naam FROM producten WHERE product_id = @id", new MySqlParameter("@id", i));
                productPrijs[i] = Convert.ToInt32(DataManagement.ExecuteQuery("SELECT product_prijs FROM producten WHERE product_id = @id", new MySqlParameter("@id", i)));

                Button? btn = Controls.Find($"buttonShop{i}", true).FirstOrDefault() as Button;
                if (btn != null)
                {
                    string prijsText = productPrijs[i].ToString();
                    btn.Text = $"{prijsText}🪙";// Set the button text to the corresponding price
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = BackColor;
                }
            }

        }

        private bool inStock(int productId)
        {
            int stock = Convert.ToInt32(DataManagement.ExecuteQuery($"SELECT product_voorraad FROM producten WHERE product_id = @id", new MySqlParameter("@id", productId)));
            if (stock > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Het spijt ons, maar dit product is niet meer op voorraad.", "Niet op voorraad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void PlaceOrder(int productID)
        {
            if (IsPurchased(productPrijs[productID]))
            {
                string email = DataManagement.ExecuteQuery($"SELECT email_ouder FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", UserData.LoggedInId));

                if (email != null)
                {
                    // Use the retrieved information
                    UserData.loggedInPoints -= productPrijs[productID]; //punten verminderen in shop
                    DataManagement.WritePointsToDB(UserData.LoggedInId, -productPrijs[productID]); // en in DB
                    labelTotalPoints.Text = $"{UserData.loggedInPoints.ToString()}🪙";

                    DataManagement.ExecuteQuery($"UPDATE producten SET product_voorraad = product_voorraad - 1, aankopen = aankopen + 1 WHERE product_id = @id;", new MySqlParameter("@id", productID)); //voorraad verminderen in DB

                    string emailMessageBody = "Beste ouder/verzorger,\n\n" + //email versuren
                    "Gefeliciteerd! Uw kind heeft met zijn/haar verdiende punten het product '" + productNaam[productID] + "' besteld in onze applicatie Fitschool. Dit toont niet alleen hun inzet maar ook hun toewijding aan het programma.\n\n" +
                    "Wij willen u laten weten dat het product binnenkort op school wordt afgeleverd. Uw kind kan het dan persoonlijk ophalen. We moedigen aan om dit moment met uw kind te bespreken om hun prestatie te vieren!\n\n" +
                    "Mocht u vragen hebben of meer informatie willen, aarzel dan niet om contact met ons op te nemen.\n\n" +
                    "Met vriendelijke groet,\nTeam Fitschool";

                    sendMail(email, "Fitschool - Bestelling Succesvol", emailMessageBody);
                }
                else MessageBox.Show("Geen informatie ingevuld, bestelling geanuleerd.", "Geen informatie ingevuld", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool IsPurchased(int cost)
        {
            if (UserData.loggedInPoints >= cost)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg punten om dit te kopen", "Niet genoeg punten", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void sendMail(string email, string onderwerp, string bericht)
        //Fitschool Gmail account: fitschool@hotmail.com ==> Wachtwoord: LwKJT3b%@y4mRvq29F&4
        {
            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587, // SMTP-poort voor Outlook.com met STARTTLS
                Credentials = new NetworkCredential("fitschool@hotmail.com", "LwKJT3b%@y4mRvq29F&4"),
                EnableSsl = true // STARTTLS-versleuteling inschakelen
            };

            MailMessage mail = new MailMessage("fitschool@hotmail.com", email, onderwerp, bericht);

            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                MessageBox.Show("Er is iets fout gegaan met het afronden van de bestelling.", "Mail niet verzonden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonShop_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int buttonNumber;

            // Extract the number from the button's name
            if (int.TryParse(clickedButton.Name.Replace("buttonShop", ""), out buttonNumber))
            {
                if (inStock(buttonNumber))
                {
                    PlaceOrder(buttonNumber);
                }
            }
        }
    }
}
