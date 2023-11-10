namespace Fitschool
{
    public class UserData
    {
        DataManagement DataManagement = new();

        public int loggedInId = -1;
        public string loggedInName = string.Empty;
        public int loggedInPoints = 5;

        public void LoginUser(int id)
        {
            loggedInId = id;
            loggedInName = DataManagement.IdToName(id);
            loggedInPoints = DataManagement.IdToPoints(id);
            MessageBox.Show($"{loggedInName}, met ID nummer {loggedInId} heeft {loggedInPoints} punten.");
        }

        public void WritePointsToDB(int id, int pointsToChange)
        {
            DataManagement.WritePointsToDB(id, pointsToChange);
        }
    }
}