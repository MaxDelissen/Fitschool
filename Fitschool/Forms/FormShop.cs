using Fitschool.Forms;

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

        private void ButtonShop1_Click(object sender, EventArgs e)
        {
            showPoints -= 10;
            DataManagement.WritePointsToDB(UserData.LoggedInId, -10);
            labelTotalPoints.Text = showPoints.ToString();
        }

        private void labelTotalPoints_Click(object sender, EventArgs e)
        {

        }

        private void buttonBackShop_Click(object sender, EventArgs e)
        {
            var myForm = new Keuzescherm(mainForm);
            myForm.Show();
            this.Close();
        }
    }
}
