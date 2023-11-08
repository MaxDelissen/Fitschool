using MySqlConnector;

namespace Fitschool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataManagement Data = new DataManagement();

        private void RequestDataButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Data.IdToName(IDValue.Value));
        }
    }
}