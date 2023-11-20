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
                SerialPort port = new(arduinoPort, 9600); //open poort
                port.Open();
                port.WriteLine("start"); //stuur commando om programma te starten.
                string readout = string.Empty; //aanmaken var. om output arduino in op te slaan.
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
                        //port.WriteLine("reset"); //stuur commando om de ardu ino te resetten, Dit is niet meer nodig, omdat de arduino automatisch reset na het voltooien van een activiteit.
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
            MessageBox.Show($"Activiteit behaald!\nJe hebt {points} punten verdient!");
            DataManagement.WritePointsToDB(UserData.LoggedInId, points); //Schrijf de punten naar de database.
            UserData.loggedInPoints += points; //Voeg de punten toe aan de variabele in de applicatie.
        }
    }
}