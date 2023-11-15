using System.Security.Cryptography;

namespace Fitschool.Forms
{
    public partial class Keuzescherm : Form
    {
        private Form mainForm; 
        public Keuzescherm(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.mainForm.Hide();
        }

        private void buttonToShop_Click(object sender, EventArgs e)
        {
            var shop = new FormShop(mainForm);
            shop.Show();
            this.Close();
        }

        private void buttonToActivity_Click(object sender, EventArgs e)
        {
            var activiteiten = new FormActiviteiten(mainForm);
            activiteiten.Show();
            this.Close();
        }

        private void Keuzescherm_Load(object sender, EventArgs e)
        {
            buttonToActivity.FlatStyle = FlatStyle.Flat;
            buttonToActivity.FlatAppearance.BorderColor = BackColor;
            buttonToShop.FlatStyle = FlatStyle.Flat;
            buttonToShop.FlatAppearance.BorderColor = BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            this.mainForm.Show();
            this.Close();
        }
    }
}
