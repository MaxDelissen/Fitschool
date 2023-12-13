using MySql.Data.MySqlClient;

namespace Fitschool
{
    public class User
    {
        public int Id { get; private set; } = -1;
        public string Name { get; private set; } = string.Empty;
        public int Points { get; private set; } = -1;
        public string EmailParents { get; private set; } = string.Empty;

        // Constructor
        public User(int userId)
        {
            DataManagement.Log($"Creating user object for user with ID {userId}");
            DataManagement DB = new();
            Id = userId;
            Name = DB.ExecuteQuery("SELECT naam FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", Id));
            Points = int.Parse(DB.ExecuteQuery("SELECT punten_totaal FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", Id)));
            EmailParents = DB.ExecuteQuery("SELECT email_ouder FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", Id));
            //MessageBox.Show($"{loggedInName}, met ID nummer {loggedInId} heeft {loggedInPoints} punten.");
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