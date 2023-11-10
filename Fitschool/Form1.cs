namespace Fitschool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        readonly DataManagement Data = new();

        int loggedInId = -1;
        string loggedInName = string.Empty;
        int loggedInPoints = 0;


        private void RequestDataButton_Click(object sender, EventArgs e)
        {
            loggedInId = Convert.ToInt32(IDValue.Value);
            loggedInName = Data.IdToName(loggedInId);
            loggedInPoints = Data.IdToPoints(loggedInId);
            MessageBox.Show($"{loggedInName}, met ID nummer {loggedInId} heeft {loggedInPoints} punten.");
        }

        private void ShopKnop_Click(object sender, EventArgs e)
        {
            FormShop formShop = new();
            Form1 startForm = new();
            startForm.Visible = false;
            formShop.ShowDialog();
        }
    }
}