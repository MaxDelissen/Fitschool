namespace Fitschool.Forms
{
    public partial class FormActiviteiten : Form
    {
        private Form mainForm;
        public FormActiviteiten(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void buttonBackActiviteiten_Click(object sender, EventArgs e)
        {
            var keuzescherm = new Keuzescherm(mainForm);
            keuzescherm.Show();
            this.Close();
        }

        private void buttonPushUps_Click(object sender, EventArgs e)
        {

        }
    }
}
