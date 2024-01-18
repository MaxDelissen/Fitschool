using Fitschool.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Text;

namespace Fitschool
{
    public class DataManagement
    {
        private static string connectionAddress = "Server=192.168.154.75;Database=fitschool;Uid=Max;Pwd=Password01;";


        public static string LogFilePath;
        public static string LogDirectory = "Logs";
        static DataManagement()
        {
            Directory.CreateDirectory(LogDirectory);

            // Create the log file path within the directory
            LogFilePath = Path.Combine(LogDirectory, $"log_{DateTime.Now:yyyy-MM-dd}.txt");

            CheckConnection();
        }

        public static void Log(string message)
        {
            Debug.WriteLine(message);

            try
            {
                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

        private static void CheckConnection()
        {
            MySqlConnection connection = new(connectionAddress);
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                Log("Connection failed");
                DialogResult option = MessageBox.Show("Er is geen verbinding met de database. Wat wilt u doen?", "Fout", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                switch (option)
                {
                    case DialogResult.Abort:
                        Log("Application closed due to connection error");
                        Environment.Exit(0);
                        break;
                    case DialogResult.Retry:
                        CheckConnection();
                        break;
                    case DialogResult.Ignore:
                        break;
                }
            }
        }


#pragma warning disable CS8600, CS8603 // Converting null literal or possible null value to non-nullable type, intended behaviour, its fine trust me bro :)
        public string ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            string result = "";
            int maxRetries = 3; // maximum number of retries trying to connect to the database
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    using MySqlConnection connection = new(connectionAddress);
                    connection.Open();

                    using MySqlCommand command = new(query, connection);

                    // Add parameters if provided
                    command.Parameters.AddRange(parameters);

                    List<string> results = new List<string>(); // Create a list to hold the results

                    // Execute the query
                    using MySqlDataReader reader = command.ExecuteReader();
                    {
                        //int fieldCount = reader.FieldCount; // Get the number of fields returned by the query

                        while (reader.Read())
                        {
                            if (reader.FieldCount == 1)
                            {
                                // Single output query
                                result = reader[0].ToString();
                            }
                            else
                            {
                                // Multiple output query
                                StringBuilder rowResult = new StringBuilder();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    rowResult.Append(reader[i].ToString());
                                    if (i < reader.FieldCount - 1)
                                    {
                                        rowResult.Append(","); // Add a comma between values
                                    }
                                }
                                //results.Add(rowResult.ToString());
                                result = rowResult.ToString();
                            }
                        }
                    }
                    //string[] resultArray = results.ToArray();                                             ///not needed?
                    //result = string.Join("-", resultArray); // Join the results with a newline character

                    // If the query execution is successful, break out of the retry loop
                    Log($"Query ({query}) executed successfully");
                    break;
                }
                catch (Exception ex)
                {
                    // Handle exceptions as needed
                    Log($"Error executing query ({query}): {ex.Message}");

                    DialogResult option;
                    if (retryCount >= maxRetries - 1)
                    {
                        Log("Maximum retries reached. User has choice to exit.");
                        option = MessageBox.Show("Maximaal aantal pogingen bereikt. Klik op 'Ja' om de applicatie af te sluiten, klik op 'Nee' om door te gaan, dit kan fouten opleveren.", "Fout: " + ex.Message, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (option == DialogResult.Yes)
                        {
                            Log("Application closed due to connection error");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        option = MessageBox.Show("Fout bij ophalen van gegevens. Is de VPN ingeschakeld?\nAls u annuleert, kunnen er fouten optreden.", "Fout", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        Log("Problem with connection, user chooses: " + option.ToString());
                    }

                    if (option != DialogResult.Retry)
                    {
                        break;
                    }
                    retryCount++;
                }
            }
            return result;
        }
#pragma warning restore CS8600, CS8603 // Converting null literal or possible null value to non-nullable type.

        public void RemoveUser(int id) //TODO: move to FormUserManagement, DataManagement only responsible for direct database interaction
        {
            // query to remove a loggedInUser from the database
            int rowsAffected = 1;
            ExecuteQuery($"DELETE FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id));

            if (rowsAffected > 0)
            {
                new FormMessageBox($"Gebruiker succesvol verwijderd. ID: {id}", "Succes");
                Log($"User with ID {id} removed");
            }
            else
            {
                new FormMessageBox("Er is een fout opgetreden bij het verwijderen van de gebruiker.", "Fout");
                Log($"Failed to remove loggedInUser with ID {id}");
            }
        }

        public void WritePointsToDB(int id, int pointsToChange)
        {
            int currentPoints = 0;
            try
            {
                currentPoints = int.Parse(ExecuteQuery("SELECT punten_totaal FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id))); // get the current amount of points
            }
            catch (Exception ex)
            {
                Log("Failed to get current points: " + ex.Message);
            }
            int newPoints = currentPoints + pointsToChange; // calculate the new amount of points

            // Execute the query and get the amount of rows affected
            Log($"Updating points for loggedInUser with ID {id} to {newPoints}, difference: {pointsToChange}");
            string stringRowsAffected = ExecuteQuery("UPDATE gebruikers SET punten_totaal = @newPoints WHERE gebruiker_id = @id; SELECT ROW_COUNT() AS RowsAffected;", new MySqlParameter("@newPoints", newPoints), new MySqlParameter("@id", id));
            int rowsAffected = Convert.ToInt32(stringRowsAffected);

            if (rowsAffected > 0) //check if the query was successful
            {
                Log("Punten succesvol gewijzigd.");
            }
            else
            {
                Log("Punten toevoegen is mislukt.");
            }
        }
    }
}