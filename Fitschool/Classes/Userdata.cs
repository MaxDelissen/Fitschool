namespace Fitschool
{
    public class UserData
    {
        private static int loggedInId = -1;
        private static string loggedInName = string.Empty;
        private static int loggedInPoints = 0;

        public static int LoggedInId => loggedInId;
        public static string LoggedInName => loggedInName;
        public static int LoggedInPoints => loggedInPoints;

        public static void LoginUser(int id)
        {
            loggedInId = id;
            loggedInName = DataManagement.IdToName(id);
            loggedInPoints = DataManagement.IdToPoints(id);
            MessageBox.Show($"{loggedInName}, met ID nummer {loggedInId} heeft {loggedInPoints} punten.");
            Arduino.SendCommand("login");
        }

        public static void LogoutUser()
        {
            loggedInId = -1;
            loggedInName = string.Empty;
            loggedInPoints = 0;
        }
    }
}