using Fitschool.Forms;

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
            new DataManagement().ExecuteQuery("UPDATE gebruikers SET punten_totaal = 500 WHERE gebruiker_id = 1;");

            DataManagement.Log("Application Started");

            ApplicationConfiguration.Initialize();

            
            Application.Run(new Form1());
            //Application.Run(new FormMessageBox("Hello World", "A nice message", "Shrek")); //TODO: remove this line and uncomment the line above
        }
    }
}