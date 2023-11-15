using Fitschool.Forms;

namespace Fitschool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //readonly UserData UserData = new();

        private void RequestDataButton_Click(object sender, EventArgs e) // == login knop
        {
            var myForm = new Keuzescherm();
            myForm.Show();
            this.Hide();
            UserData.LoginUser(Convert.ToInt32(IDValue.Value));
        }

        private void ShopKnop_Click(object sender, EventArgs e)
        {
            FormShop formShop = new FormShop();
            formShop.ShowDialog();
        }

        private void AddPointsButton_Click(object sender, EventArgs e)
        {
            DataManagement.WritePointsToDB(UserData.LoggedInId, 10);
        }

        private void OpenUserManagementButton_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}