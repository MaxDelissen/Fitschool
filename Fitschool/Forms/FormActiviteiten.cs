using System.IO.Ports;

namespace Fitschool.Forms
{
    public partial class FormActiviteiten : Form
    {
        private readonly Form keuzeScherm;
        private readonly User user;
        public FormActiviteiten(Form keuzeScherm, User user)
        {
            InitializeComponent();
            this.keuzeScherm = keuzeScherm;
            this.user = user;
        }

        private void buttonBackActiviteiten_Click(object sender, EventArgs e)
        {
            //var keuzescherm = new Keuzescherm(keuzeScherm, user);
            keuzeScherm.Show();
            this.Close();
        }

        readonly string arduinoPort = Arduino.arduinoPort;

        private void buttonPushUps_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort port = new(arduinoPort, 9600); //open poort
                port.Open();
                port.WriteLine("start"); //stuur commando om programma te starten.
                string readout = string.Empty; //aanmaken var. om output arduino in op te slaan.

                MessageBox.Show("Ga op de grond liggen, boven de sensor.\nDruk dan op OK om te beginnen.");

                Thread.Sleep(1000); //wachten, zodat arduino tijd heeft om te starten, en het kind de tijd geeft om te gaan liggen.
                while (true) //loop om te blijven lezen tot de arduino het commando stuurt dat de activiteit is behaald.
                {
                    port.ReadTimeout = 1000; //een timeout van 1 seconde, om te voorkomen dat het programma blijft wachten / soft crashed.
                    try //try catch om de timeout te vangen.
                    {
                        readout = port.ReadLine(); //lees de output van de arduino.
                    }
                    catch (TimeoutException) { } //vang de timeout, hierna opnieuw proberen te lezen.

                    if (readout == "behaald\r") //arduino stuurt "behaald" als de activiteit is behaald, \r is een carriage return, om de string te vergelijken moet deze ook worden meegegeven.
                    {
                        ActivityComplete(1, 10); //roep de functie aan om de activiteit te voltooien, geef de activiteitID (=1) en het aantal herhalingen (=10) mee.
                        //port.WriteLine("stop"); //stuur commando om de arduino te stoppen.
                        port.Close(); //sluit de poort.
                        break; //stop de loop.
                    }
                }
            }
            catch (Exception ex) //waarschijnlijk een fout met het openen v.d. poort.
            {
                MessageBox.Show("Df is iets misgegaan met het starten van deze oefening,\nZorg ervoor dat de push-up sensor verbonden is, en probeer het opnieuw.", "fout " + ex.Message);
            }
        }

        private void ActivityComplete(int activityID, int aantal)
        {
            var points = activityID switch
            {
                1 => aantal,
                2 => (int)Math.Round(aantal * 1.2),//1.2 als voorbeeld van de mogelijkheden om de conversie aan te passen.
                3 => aantal,
                4 => aantal * 2,
                5 => aantal,
                6 => aantal,
                _ => aantal,
            };
            MessageBox.Show($"Activiteit behaald!\nJe hebt {points} punten verdient!");
            DataManagement.WritePointsToDB(user.Id, points); //Schrijf de punten naar de database.
            user.UpdatePoints(points); //Update de punten in de applicatie.
        }
    }
}