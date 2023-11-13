namespace Fitschool
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            string naam = NameBox.Text;
            int leeftijd = Convert.ToInt32(LeeftijdSelector.Value);
            DataManagement.AddUser(naam, leeftijd);
        }
    }
}
