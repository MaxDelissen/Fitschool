using Fitschool.Classes.Shop;
using Fitschool.Forms;
using System.Diagnostics;

namespace Fitschool
{
    public partial class FormShop : Form
    {
        private readonly Keuzescherm keuzeScherm;
        private readonly Order order;
        public FormShop(Keuzescherm keuzeScherm, User user)
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.keuzeScherm = keuzeScherm;
            this.order = new(user);

            LoadData();
            labelTotalPoints.Text = $"{user.Points}💰"; //the character at the end is a coin emoji
        }

        private void ButtonBackShop_Click(object sender, EventArgs e)
        {
            if (order.Products.Count > 0)
            {
                DialogResult confirmOrder = MessageBox.Show("Wil je deze aankoop bevestigen?", "Bevestiging", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmOrder == DialogResult.Yes)
                {
                    Order.ConfirmStatus status = order.Confirm();
                    switch (status)
                    {
                        case Order.ConfirmStatus.Succes:
                            MessageBox.Show("Bedankt voor je aankoop!", "Aankoop bevestigd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case Order.ConfirmStatus.NotEnoughPoints:
                            MessageBox.Show("Je hebt niet genoeg punten om deze aankoop te doen.", "Niet genoeg punten", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case Order.ConfirmStatus.InvalidEmail:
                            MessageBox.Show("Je hebt geen geldig emailadres ingevuld.", "Ongeldig emailadres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case Order.ConfirmStatus.emailNotSent:
                            MessageBox.Show("Er is een fout opgetreden bij het versturen van de email.", "Email niet verzonden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
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
                    btn.Tag = new Product(i);
                    btn.Text = $"{((Product)btn.Tag).Price}💰";
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = BackColor;

                    if (Controls.Find($"pictureShop{i}", true).FirstOrDefault() is PictureBox pictureBox) //add image to picturebox
                    {
                        try
                        {
                            pictureBox.Load(((Product)btn.Tag).ImageUrl); // load the image from the URL
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

        private void ButtonShop_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button ?? buttonBackShop;

            Product product = (Product)clickedButton.Tag;
            if (!order.Add(product))
            {
                MessageBox.Show("Dit product is niet op voorraad.", "Niet op voorraad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            labelTotalPrice.Text = $"Totaal: {order.TotalPrice}💰";
            shoppingCart.Items.Add(((Product)clickedButton.Tag).Name);
        }
    }
}
