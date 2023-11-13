namespace Fitschool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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

        private void AddPointsButton_Click(object sender, EventArgs e)
        {
            DataManagement.WritePointsToDB(UserData.loggedInId, 10);
        }

        private void OpenUserManagementButton_Click(object sender, EventArgs e)
        {
            FormUserManagement formUserManagement = new();
            formUserManagement.ShowDialog();
        }
    }
}