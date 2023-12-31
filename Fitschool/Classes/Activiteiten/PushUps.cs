﻿using System.IO.Ports;


namespace Fitschool.Classes.Activiteiten
{
    public class PushUps
    {
        public void Start()
        {
            DataManagement.Log("Initializing Arduino...");
            string status = Arduino.SendCommand("status");
            DataManagement.Log("Status Arduino: " + status);
            if (status != "OK")
            {
                DataManagement.Log("Failed to connect to Arduino, this may result in future errors, continuing...");
                MessageBox.Show("Er is een fout opgetreden bij het verbinden met uw aangesloten tracker. De applicatie zal nog wel werken, maar de tracker niet.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string arduinoPort = Arduino.arduinoPort;
            try
            {
                SerialPort port = new(arduinoPort, 9600); //open poort
                port.Open();
                port.WriteLine("start"); //stuur commando om programma te starten.
                string readout = string.Empty;

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
                        port.Close();
                        return;
                    }
                }
            }
            catch (Exception ex) //waarschijnlijk een fout met het openen v.d. poort.
            {
                MessageBox.Show("Df is iets misgegaan met het starten van deze oefening,\nZorg ervoor dat de push-up sensor verbonden is, en probeer het opnieuw.", "fout " + ex.Message);
            }
        }
    }
}
