using System.Diagnostics;

namespace Fitschool
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            string connectioncheck = DataManagement.ExecuteQuery("SELECT MAX(gebruiker_id) AS highest FROM gebruikers;");
            if (string.IsNullOrEmpty(connectioncheck))
            {
                MessageBox.Show("Initiële databaseverbinding is mislukt.\nDeze is verplicht voor het opstarten van fitschool.\n\nControleer alstublieft uw internetverbinding en VPN-instellingen en probeer het opnieuw.\n\nDe applicatie wordt nu afgesloten.", "Full Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Environment.Exit(1);
            }
            else
            {
                DataManagement.maxId = int.Parse(connectioncheck);
            }

            Debug.WriteLine("Application Started");

            MessageBox.Show("Status Arduino: " + Arduino.SendCommand("status"));

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}