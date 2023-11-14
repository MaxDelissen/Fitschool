namespace Fitschool
{
    public partial class FormShop : Form
    {
        public FormShop()
        {   
            InitializeComponent();
        }

        int showPoints = 69;

        private void FormShop_Load(object sender, EventArgs e)
        {
            showPoints = UserData.LoggedInPoints;
            labelTotalPoints.Text = showPoints.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            showPoints -= 10;
            DataManagement.WritePointsToDB(UserData.LoggedInId, -10);
            labelTotalPoints.Text = showPoints.ToString();
        }
    }
}
