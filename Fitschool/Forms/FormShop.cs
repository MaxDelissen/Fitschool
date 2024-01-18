using Fitschool.Classes.Shop;
using Fitschool.Forms;
using System.Diagnostics;

namespace Fitschool
{
    public partial class FormShop : Form
    {
        private readonly Keuzescherm keuzeScherm;
        private readonly User user;
        private Order order;
        public FormShop(Keuzescherm keuzeScherm, User user)
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.keuzeScherm = keuzeScherm;
            this.user = user;
            this.order = new(user);

            LoadData();

            shoppingCart.DisplayMember = "Name";
            labelTotalPoints.Text = $"{user.Points}💰"; //the character at the end is a coin emoji
        }

        private void ConfirmOrder(object sender, EventArgs _)
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
                            new FormMessageBox("Bedankt voor je aankoop!", "Aankoop bevestigd", "Klaar");
                            order = new(user);
                            labelTotalPrice.Text = TotalPrice();
                            shoppingCart.Items.Clear();
                            labelTotalPoints.Text = $"{user.Points}💰";
                            break;
                        case Order.ConfirmStatus.NotEnoughPoints:
                            new FormMessageBox("Je hebt niet genoeg punten om deze aankoop te doen.", "Niet genoeg punten", "Sluiten");
                            break;
                        case Order.ConfirmStatus.InvalidEmail:
                            new FormMessageBox("Je hebt geen geldig emailadres ingevuld.", "Ongeldig emailadres", "Sluiten");
                            break;
                        case Order.ConfirmStatus.emailNotSent:
                            new FormMessageBox("Er is een fout opgetreden bij het versturen van de email.", "Email niet verzonden", "Sluiten");
                            break;
                    }
                }
            }
        }

        private void ButtonBackShop_Click(object sender, EventArgs e)
        {
            if (order.Products.Count > 0)
            {
                DialogResult result = MessageBox.Show("Wil je deze terug gaan? alle artilelen worden uit je lijstje verwijderd.?", "Terug", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) { return; }
            }
            //else:
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

        private void RemoveProductButton(object sender, EventArgs _)
        {
            Product? productToRemove = (Product)shoppingCart.SelectedItem;
            if (productToRemove != null)
            {
                if (RemoveProduct(productToRemove))
                {
                    shoppingCart.Items.Remove(productToRemove);
                }
                else //product not removed
                {
                    new FormMessageBox("Er is een fout opgetreden bij het verwijderen van dit product.", "Fout");
                }
            }
        }

        private bool RemoveProduct(Product product)
        {
            if (order.Remove(product))
            {
                labelTotalPrice.Text = TotalPrice();
                return true;
            }
            return false;
        }

        private void ButtonShop_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button ?? buttonBackShop;

            Product product = (Product)clickedButton.Tag;
            if (!order.Add(product))
            {
                new FormMessageBox("Dit product is niet op voorraad.", "Niet op voorraad", "Sluiten");
            }
            labelTotalPrice.Text = TotalPrice();
            shoppingCart.Items.Add(((Product)clickedButton.Tag));
        }

        private string TotalPrice()
        {
            return order.TotalPrice.ToString();
        }
    }
}
