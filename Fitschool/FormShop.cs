namespace Fitschool
{
    public partial class FormShop : Form
    {
        private readonly DataManagement Data = new();
        private readonly UserData UserData;
        public FormShop(UserData userData)
        {   
            InitializeComponent();
            UserData = userData;
        }

        int showPoints = 69;

        private void FormShop_Load(object sender, EventArgs e)
        {
            showPoints = UserData.loggedInPoints;
            labelTotalPoints.Text = showPoints.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            showPoints -= 10;
            Data.WritePointsToDB(UserData.loggedInId, -10);
            labelTotalPoints.Text = showPoints.ToString();
        }
    }
}
