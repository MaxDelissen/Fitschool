using System.IO.Ports;

namespace Fitschool.Forms
{
    public partial class FormActiviteiten : Form
    {
        private readonly Form keuzeScherm;
        public readonly User user;
        public FormActiviteiten(Form keuzeScherm, User user)
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.keuzeScherm = keuzeScherm;
            this.user = user;
        }

        private void buttonBackActiviteiten_Click(object sender, EventArgs e)
        {
            keuzeScherm.Show();
            this.Close();
        }

        public enum Activity
        {
            PushUps,
            TicTacToe,
            Math,
            Language
        }


        private void buttonPushUps_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonTTT_Click(object sender, EventArgs e)
        {
            
        }
    }
}