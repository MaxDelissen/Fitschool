using Fitschool.Classes.Shop;
using Fitschool.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Fitschool
{
    public partial class FormShop : Form
    {
        private Product[] products = new Product[8]
        {
            new Product(1),
            new Product(2),
            new Product(3),
            new Product(4),
            new Product(5),
            new Product(6),
            new Product(7),
            new Product(8)
        };

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
            for (int i = 0; i < 8; i++)
            {
                if (Controls.Find($"buttonShop{i}", true).FirstOrDefault() is Button btn) //buttontext veranderen naar prijs
                {
                    btn.Text = $"{products[i].price}🪙";
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = BackColor;
                }

                if (Controls.Find($"pictureShop{i}", true).FirstOrDefault() is PictureBox pictureBox) //afbeelding toevoegen
                {
                    try
                    {
                        pictureBox.Load(products[i].imageUrl); // afbeelding inladen
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

        private void AddToOrder(int productID)
        {
            order.AddToOrder(productID);
            shoppingCard.Items.Add(products[productID].name);
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
