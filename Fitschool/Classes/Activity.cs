using Fitschool.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitschool.Classes
{
    public class Activity
    {
        private FormActiviteiten form;
        FormActiviteiten.Activity chosenActivity;

        private User LoggedInUser;
        private User SecondUser;
        public User Winner { get; private set; }

        public Activity(Activity activity, FormActiviteiten form)
        {
            chosenActivity = activity;
            LoggedInUser = form.user;
            this.form = form;
        }

        public enum Activitys
        {
            PushUps,
            TicTacToe,
            Math,
            Language
        }

        public void StartActivity()
        {
            switch (chosenActivity)
            {
                case FormActiviteiten.Activity.PushUps:
                    PushUps();
                    break;
                case FormActiviteiten.Activity.TicTacToe:
                    TicTacToe();
                    break;
                case FormActiviteiten.Activity.Math:
                    //Math();
                    break;
                case FormActiviteiten.Activity.Language:
                    //Language();
                    break;
            }
        }

        private void PushUps()
        {
            string arduinoPort = Arduino.arduinoPort;
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
                        ActivityComplete(LoggedInUser, FormActiviteiten.Activity.PushUps); //roep de functie aan om de activiteit te voltooien, geef de activiteitID (=1) en het aantal herhalingen (=10) mee.
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

        private void TicTacToe()
        {
            FormTicTacToe formTicTacToe = new(form);
            formTicTacToe.Show();
        }

        private void GetSecondUser()
        {

        }

        private void ActivityComplete(User triumphantUser, FormActiviteiten.Activity completedActivity)
        {
            var points = completedActivity switch
            {
                FormActiviteiten.Activity.PushUps => 10,    //1 point per pushup
                FormActiviteiten.Activity.TicTacToe => 3,   //to be assigned
                FormActiviteiten.Activity.Math => 5,        //to be assigned
                FormActiviteiten.Activity.Language => 5,    //to be assigned
                _ => 0,
            };
            
            MessageBox.Show($"Gefeliciteerd {triumphantUser.Name}, Je hebt voor het doen van deze activiteit {points}💰 verdiend");
            new DataManagement().WritePointsToDB(LoggedInUser.Id, points); //Schrijf de punten naar de database.
            LoggedInUser.UpdatePoints(points); //Update de punten in de applicatie.
        }
    }
}
