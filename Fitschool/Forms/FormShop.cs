using Fitschool.Classes;
using Fitschool.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Fitschool
{
    public partial class FormShop : Form
    {
        private readonly Form mainForm;
        public FormShop(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadData();
        }

        private void FormShop_Load(object sender, EventArgs e)
        {
            labelTotalPoints.Text = $"{UserData.loggedInPoints}🪙"; //het icoontje hierachter is een munt emoji teken
        }

        private void ButtonBackShop_Click(object sender, EventArgs e)
        {
            var myForm = new Keuzescherm(mainForm);
            myForm.Show();
            this.Close();
        }

        readonly string[] productNaam = new string[9];
        readonly int[] productPrijs = new int[9];
        readonly string[] productAfbeelding = new string[9];

        private void LoadData()
        {
            for (int i = 1; i <= 8; i++)
            {
                productNaam[i] = DataManagement.ExecuteQuery("SELECT product_naam FROM producten WHERE product_id = @id", new MySqlParameter("@id", i));
                productPrijs[i] = Convert.ToInt32(DataManagement.ExecuteQuery("SELECT product_prijs FROM producten WHERE product_id = @id", new MySqlParameter("@id", i)));
                productAfbeelding[i] = DataManagement.ExecuteQuery("SELECT product_afbeelding FROM producten WHERE product_id = @id", new MySqlParameter("@id", i));

                if (Controls.Find($"buttonShop{i}", true).FirstOrDefault() is Button btn) //buttontext veranderen naar prijs
                {
                    string prijsText = productPrijs[i].ToString();
                    btn.Text = $"{prijsText}🪙";
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = BackColor;
                }

                if (Controls.Find($"pictureShop{i}", true).FirstOrDefault() is PictureBox pictureBox) //afbeelding toevoegen
                {
                    if (!string.IsNullOrEmpty(productAfbeelding[i]))
                    {
                        try
                        {
                            pictureBox.Load(productAfbeelding[i]); // afbeelding inladen
                            pictureBox.BackColor = Color.Transparent;
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions that might occur while loading the image
                            Debug.WriteLine($"Error loading image for product {i}: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void PlaceOrder(int productID)
        {
            Order order = new(productID);

            if (order.EnoughPoints() && order.EnoughPoints() && order.IsValidEmail())
            {
                order.UpdatePoints();
                labelTotalPoints.Text = $"{UserData.loggedInPoints}🪙";
                order.UpdateStock();

                string emailMessageBody = "Beste ouder/verzorger,\n\n" +
                    "Gefeliciteerd! Uw kind heeft met zijn/haar verdiende punten het product '" + productNaam[productID] + "' besteld in onze applicatie Fitschool. Dit toont niet alleen hun inzet maar ook hun toewijding aan het programma.\n\n" +
                    "Wij willen u laten weten dat het product binnenkort op school wordt afgeleverd. Uw kind kan het dan persoonlijk ophalen. We moedigen aan om dit moment met uw kind te bespreken om hun prestatie te vieren!\n\n" +
                    "Mocht u vragen hebben of meer informatie willen, aarzel dan niet om contact met ons op te nemen.\n\n" +
                    "Met vriendelijke groet,\nTeam Fitschool";

                order.SendMail("Bestelling Succesvol", emailMessageBody);
            }
        }


        private void ButtonShop_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button ?? buttonBackShop;

            if (int.TryParse(clickedButton.Name.Replace("buttonShop", ""), out int buttonNumber))
            {
                PlaceOrder(buttonNumber);
            }
        }
    }
}
