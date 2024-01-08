using MySql.Data.MySqlClient;

namespace Fitschool
{
    public class User
    {
        public int Id { get; private set; } = -1;
        public string Name { get; private set; } = string.Empty;
        public int Points { get; private set; } = -1;
        public int Grade { get; private set; } = -1;
        public string EmailParents { get; private set; } = string.Empty;

        // Constructor
        public User(int userId)
        {
            DataManagement.Log($"Creating loggedInUser object for loggedInUser with ID {userId}");
            Id = userId;

            DataManagement DB = new();
            string userData = DB.ExecuteQuery("SELECT naam, punten_totaal, groep, email_ouder FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", Id));
            string[] userDataSplit = userData.Split(',');
            Name = userDataSplit[0];
            Points = int.Parse(userDataSplit[1]);
            Grade = int.Parse(userDataSplit[2]);
            EmailParents = userDataSplit[3];
            //MessageBox.Show($"{loggedInName}, met ID nummer {loggedInId} heeft {loggedInPoints} punten.");
        }

        public User() //Computer User, mainly for the TicTacToe game
        {
            Name = "Computer";
            Points = 0;
            Grade = 0;
            EmailParents = "NVT";
        }

        public void LogoutUser()
        {
            Id = -1;
            Name = string.Empty;
            Points = 0;
        }

        public int UpdatePoints(int amountToChange)
        {
            Points += amountToChange;
            new DataManagement().WritePointsToDB(Id, amountToChange);
            return Points;
        }
    }
}