namespace Fitschool
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            DataManagement.Log("Starting application...");
            DataManagement.Log("Initial connection check:");
            string connectioncheck = DataManagement.ExecuteQuery("SELECT MAX(gebruiker_id) AS highest FROM gebruikers;");
            if (string.IsNullOrEmpty(connectioncheck))
            {
                DataManagement.Log("Failed to connect to database, this may result in future errors, continuing...");
            }
            else
            {
                DataManagement.maxId = int.Parse(connectioncheck);
                DataManagement.Log("Connected to database!");
            }

            DataManagement.Log("Application Started");

            DataManagement.Log("Initializing Arduino...");
            string status = Arduino.SendCommand("status");
            DataManagement.Log("Status Arduino: " + status);
            if (status != "OK")
            {
                DataManagement.Log("Failed to connect to Arduino, this may result in future errors, continuing...");
                MessageBox.Show("Er is een fout opgetreden bij het verbinden met uw aangesloten tracker. De applicatie zal nog wel werken, maar de tracker niet.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}