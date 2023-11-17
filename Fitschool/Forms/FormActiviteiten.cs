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
                string readout = string.Empty;
                Thread.Sleep(1000);
                while (true)
                {
                    port.ReadTimeout = 1000;
                    try
                    {
                        readout = port.ReadLine();
                    }
                    catch (Exception) { }

                    if (!string.IsNullOrEmpty(readout) && readout == "behaald\r")
                    {
                        ActivityComplete(1, 10); // 1 = pushups, 10 = aantal
                        port.WriteLine("reset");
                        port.Close();
                        break;
                    }
                }
            } catch (Exception) { }
        }

        private void ActivityComplete(int activityID, int aantal)
        {
            MessageBox.Show("Activiteit behaald!");
            int points;
            switch (activityID)
            {
                case 1:
                    points = aantal;
                    break;
                case 2:
                    points = (int)Math.Round(aantal * 1.2); //1.2 als voorbeeld van de mogelijkheden om de conversie aan te passen.
                    break;
                case 3:
                    points = aantal;
                    break;
                case 4:
                    points = aantal *2;
                    break;
                case 5:
                    points = aantal;
                    break;
                case 6:
                    points = aantal;
                    break;
                default:
                    points = aantal;
                    break;
            }
        }
    }
}
