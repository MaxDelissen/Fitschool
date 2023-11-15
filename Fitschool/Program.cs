using System.Diagnostics;
using System.IO.Ports;

namespace Fitschool
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var connectioncheck = DataManagement.ExecuteQuery("SELECT COUNT(*) AS TotalRecords FROM gebruikers;");
            if (string.IsNullOrEmpty(connectioncheck))
            {
                MessageBox.Show("Initial database connection failed. Please check your internet connection, and VPN settings and try again.\nApplication will exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            Debug.WriteLine("Application Started");

            MessageBox.Show("Status Arduino: " + Arduino.SendCommand("status"));

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}