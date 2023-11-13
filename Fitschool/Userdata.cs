namespace Fitschool
{
    public class UserData
    {
        DataManagement DataManagement = new();

        public int loggedInId = -1;
        public string loggedInName = string.Empty;
        public int loggedInPoints = 0;

        public void LoginUser(int id)
        {
            loggedInId = id;
            loggedInName = DataManagement.IdToName(id);
            loggedInPoints = DataManagement.IdToPoints(id);
            MessageBox.Show($"{loggedInName}, met ID nummer {loggedInId} heeft {loggedInPoints} punten.");
        }

        public void LogoutUser()
        {
            loggedInId = -1;
            loggedInName = string.Empty;
            loggedInPoints = 0;
        }
    }
}