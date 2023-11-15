using Fitschool.Forms;

namespace Fitschool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RequestDataButton_Click(object sender, EventArgs e) // == login knop
        {
            UserData.LoginUser(Convert.ToInt32(IDValue.Value));
            Keuzescherm keuzescherm = new Keuzescherm(this);
            keuzescherm.Show();
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