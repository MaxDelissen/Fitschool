namespace Fitschool.Forms
{
    public partial class Keuzescherm : Form
    {
        private readonly Form mainForm;
        private User user;
        public Keuzescherm(Form mainForm, User user)
        {
            InitializeComponent();
            this.user = user;
            this.mainForm = mainForm;
        }

        private void buttonToShop_Click(object sender, EventArgs e)
        {
            FormShop shop = new FormShop(this, user);
            shop.Show();
            this.Hide();
        }

        private void buttonToActivity_Click(object sender, EventArgs e)
        {
            FormActiviteiten activiteiten = new FormActiviteiten(this, user);
            activiteiten.Show();
            this.Hide();
        }

        private void Keuzescherm_Load(object sender, EventArgs e)
        {
            buttonToActivity.FlatStyle = FlatStyle.Flat;
            buttonToActivity.FlatAppearance.BorderColor = BackColor;
            buttonToShop.FlatStyle = FlatStyle.Flat;
            buttonToShop.FlatAppearance.BorderColor = BackColor;

            labelName.BackColor = Color.Transparent;
            labelPunten.BackColor = Color.Transparent;

            labelName.Text = user.Name;
            labelPunten.Text = user.Points.ToString();
        }

        private void button1_Click(object sender, EventArgs e) //back button, forgot to rename it
        {
            mainForm.Show();
            this.Close();
        }
    }
}
