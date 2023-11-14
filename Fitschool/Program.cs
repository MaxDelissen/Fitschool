namespace Fitschool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var connectioncheck = DataManagement.ExecuteQuery("SELECT COUNT(*) AS TotalRecords FROM users;");
            if (string.IsNullOrEmpty(connectioncheck))
            {
                MessageBox.Show("Initial database connection failed. Please check your internet connection, and VPN settings and try again.\nApplication will exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}