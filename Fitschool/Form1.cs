namespace Fitschool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        readonly DataManagement DataManagement = new();
        readonly UserData UserData = new();

        private void RequestDataButton_Click(object sender, EventArgs e)
        {
            UserData.LoginUser(Convert.ToInt32(IDValue.Value));
        }

        private void ShopKnop_Click(object sender, EventArgs e)
        {
            FormShop formShop = new FormShop(UserData);
            formShop.ShowDialog();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            string naam = NameBox.Text;
            int leeftijd = Convert.ToInt32(LeeftijdSelector.Value);
            DataManagement.AddUser(naam, leeftijd);
        }

        private void AddPointsButton_Click(object sender, EventArgs e)
        {
            DataManagement.WritePointsToDB(UserData.loggedInId, 10);
        }
    }
}