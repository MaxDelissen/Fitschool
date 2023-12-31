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
            string connectioncheck = new DataManagement().ExecuteQuery("SELECT punten_totaal FROM gebruikers WHERE gebruiker_id = 1;");
            if (string.IsNullOrEmpty(connectioncheck))
            {
                DataManagement.Log("Failed to connect to database, this may result in future errors, continuing...");
            }
            else
            {
                if (int.Parse(connectioncheck) < 500)
                {
                    DataManagement.Log("Points Timo too low, setting points to 500");
                    new DataManagement().ExecuteQuery("UPDATE gebruikers SET punten_totaal = 500 WHERE gebruiker_id = 1;");
                }
                else
                {
                    DataManagement.Log("Connected to database!");
                }
                DataManagement.Log("Connected to database!");
            }

            DataManagement.Log("Application Started");

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}