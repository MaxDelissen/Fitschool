using Fitschool.Classes.Shop;
using Fitschool.Forms;
using System.Diagnostics;

namespace Fitschool
{
    public partial class FormShop : Form
    {
        private readonly Product[] products = new Product[8]
        {
            new Product(0),
            new Product(1),
            new Product(2),
            new Product(3),
            new Product(4),
            new Product(5),
            new Product(6),
            new Product(7)
        };

        private readonly Keuzescherm keuzeScherm;
        private readonly Order order;
        public FormShop(Keuzescherm keuzeScherm, User user)
        {
            InitializeComponent();
            this.keuzeScherm = keuzeScherm;
            this.order = new(user);

            LoadData();
            labelTotalPoints.Text = $"{user.Points}🪙"; //the character at the end is a coin emoji
        }

        private void ButtonBackShop_Click(object sender, EventArgs e)
        {
            if (order.Products.Count > 0)
            {
                DialogResult confirmOrder = MessageBox.Show("Wil je deze aankoop bevestigen?", "Bevestiging", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmOrder == DialogResult.Yes) order.Confirm();
            }

            keuzeScherm.UpdatePoints();
            keuzeScherm.Show();
            this.Close();
        }

        private void LoadData()
        {
            for (int i = 0; i < 8; i++)
            {
                if (Controls.Find($"buttonShop{i}", true).FirstOrDefault() is Button btn) //change button text to price
                {
                    btn.Text = $"{products[i].Price}🪙";
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = BackColor;
                }

                if (Controls.Find($"pictureShop{i}", true).FirstOrDefault() is PictureBox pictureBox) //add image to picturebox
                {
                    try
                    {
                        pictureBox.Load(products[i].ImageUrl); // load the image from the URL
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

        private void ButtonShop_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button ?? buttonBackShop;

            if (int.TryParse(clickedButton.Name.Replace("buttonShop", ""), out int productID))
            {
                order.Add(productID);
                labelTotalPrice.Text = $"Totaal: {order.TotalPrice}🪙";
                shoppingCart.Items.Add(products[productID].Name);
            }
        }
    }
}
