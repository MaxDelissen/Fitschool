using System.IO.Ports;

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

        readonly string arduinoPort = Arduino.arduinoPort;

        private void buttonPushUps_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort port = new(arduinoPort, 9600);
                port.Open();
                port.WriteLine("start");
                while (true)
                {
                    string readout = port.ReadExisting();
                    if (!string.IsNullOrEmpty(readout))
                    {
                        MessageBox.Show(readout);
                        port.Close();
                        break;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
