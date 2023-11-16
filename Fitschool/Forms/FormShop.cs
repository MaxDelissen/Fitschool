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
        }

        int showPoints = 69;

        private void FormShop_Load(object sender, EventArgs e)
        {
            showPoints = UserData.LoggedInPoints;
            labelTotalPoints.Text = showPoints.ToString();
            buttonShop1.FlatStyle = FlatStyle.Flat;
            buttonShop1.FlatAppearance.BorderColor = BackColor;
        }

        private void buttonBackShop_Click(object sender, EventArgs e)
        {
            var myForm = new Keuzescherm(mainForm);
            myForm.Show();
            this.Close();
        }

        private void ButtonShop1_Click(object sender, EventArgs e)
        {
            PlaceOrder(100, "€10 Roblox giftcard");
        }


        private void PlaceOrder(int price, string product)
        {
            if (IsPurchased(price))
            {
                string email = DataManagement.ExecuteQuery($"SELECT email_ouder FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", UserData.LoggedInId));

                if (email != null)
                {
                    // Use the retrieved information
                    showPoints -= price;
                    DataManagement.WritePointsToDB(UserData.LoggedInId, -price);
                    labelTotalPoints.Text = showPoints.ToString();
                    string emailMessageBody = "Beste ouder/verzorger,\n\n" +
                    "Gefeliciteerd! Uw kind heeft met zijn/haar verdiende punten het product '" + product + "' besteld in onze applicatie Fitschool. Dit toont niet alleen hun inzet maar ook hun toewijding aan het programma.\n\n" +
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
            if (showPoints >= cost)
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
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("no.reply.delissen@gmail.com", "yxvf vbqi ojrb jqar"),
                EnableSsl = true,
            };

            MailMessage mail = new MailMessage("no.reply.delissen@gmail.com", email, onderwerp, bericht);

            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                MessageBox.Show("Er is iets fout gegaan met het afronden van de bestelling.", "Mail niet verzonden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
