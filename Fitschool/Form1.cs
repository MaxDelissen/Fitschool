namespace Fitschool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataManagement Data = new DataManagement();

        int loggedInId = -1;
        string loggedInName = string.Empty;
        int loggedInPoints = 0;


        private void RequestDataButton_Click(object sender, EventArgs e)
        {
            loggedInId = Convert.ToInt32(IDValue.Value);
            loggedInName = Data.IdToName(loggedInId);
            loggedInPoints = Convert.ToInt32(Data.RetrieveFromDB(loggedInId, "points"));
        }
    }
}