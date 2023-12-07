using Fitschool.Classes.Shop;
using Fitschool.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Fitschool
{
    public partial class FormShop : Form
    {
        readonly string[] productNaam = new string[9];
        readonly int[] productPrijs = new int[9];
        readonly string[] productAfbeelding = new string[9];

        private Form keuzeScherm;
        private Order order;
        public FormShop(Form keuzeScherm, User user)
        {
            InitializeComponent();
            this.keuzeScherm = keuzeScherm;
            this.order = new(user);

            LoadData();
            labelTotalPoints.Text = $"{user.Points}🪙"; //het icoontje hierachter is een munt emoji teken
        }

        private void ButtonBackShop_Click(object sender, EventArgs e)
        {
            //var myForm = new Keuzescherm(keuzeScherm, user);
            keuzeScherm.Show();
            this.Close();
        }

        

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

        private void AddToOrder(int productID)
        {
            order.AddToOrder(productID);
            shoppingCard.Items.Add(productNaam[productID]);
        }


        private void ButtonShop_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button ?? buttonBackShop;

            if (int.TryParse(clickedButton.Name.Replace("buttonShop", ""), out int buttonNumber))
            {
                AddToOrder(buttonNumber);
            }
        }
    }
}
