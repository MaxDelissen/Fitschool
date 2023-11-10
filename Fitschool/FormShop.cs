namespace Fitschool
{
    public partial class FormShop : Form
    {

        private readonly UserData UserData;
        public FormShop(UserData userData)
        {   
            InitializeComponent();
            UserData = userData;
        }

        int TotalPoints = 69;

        private void FormShop_Load(object sender, EventArgs e)
        {
            TotalPoints = UserData.loggedInPoints;
            MessageBox.Show(TotalPoints.ToString());
            labelTotalPoints.Text = TotalPoints.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TotalPoints -= 10;
            labelTotalPoints.Text = TotalPoints.ToString();
        }
    }
}
