using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Fitschool
{
    public class DataManagement
    {
        public static string LogFilePath;
        public static string LogDirectory = "Logs";
        static DataManagement()
        {
            Directory.CreateDirectory(LogDirectory);

            // Create the log file path within the directory
            LogFilePath = Path.Combine(LogDirectory, $"log_{DateTime.Now:yyyy-MM-dd}.txt");
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

        private readonly string connectionAddress = "server=192.168.154.75;database=fitschool;uid=Max;password=Password01;";

        public string ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            string result = "";
            int maxRetries = 3;
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    result = ExecuteQueryWithRetry(query, parameters);
                    // If the query execution is successful, break out of the retry loop
                    Log($"Query ({query}) executed successfully");
                    break;
                }
                catch (Exception ex)
                {
                    HandleQueryExecutionError(ex, query, ref retryCount, maxRetries);
                }
            }
            return result;
        }

        private string ExecuteQueryWithRetry(string query, params MySqlParameter[] parameters)
        {
            string result = "";

            using MySqlConnection connection = new MySqlConnection(connectionAddress);
            connection.Open();

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result += reader[0].ToString(); // Adjust this based on the expected result
            }

            return result;
        }

        private void HandleQueryExecutionError(Exception ex, string query, ref int retryCount, int maxRetries)
        {
            Log($"Error executing query ({query}): {ex.Message}");

            if (retryCount >= maxRetries - 1)
            {
                HandleMaxRetryReached(ex);
            }
            else
            {
                HandleRetryOption(ref retryCount);
            }
        }

        private void HandleMaxRetryReached(Exception ex)
        {
            Log("Maximum retries reached. User has choice to exit.");
            DialogResult option = MessageBox.Show("Maximaal aantal pogingen bereikt. Klik op 'Ja' om de applicatie af te sluiten, klik op 'Nee' om door te gaan, dit kan fouten opleveren.", "Fout: " + ex.Message, MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (option == DialogResult.Yes)
            {
                Log("Application closed due to connection error");
                Environment.Exit(0);
            }
        }

        private void HandleRetryOption(ref int retryCount)
        {
            DialogResult option = MessageBox.Show("Fout bij ophalen van gegevens. Is de VPN ingeschakeld?\nAls u annuleert, kunnen er fouten optreden.", "Fout", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            Log("Problem with connection, user chooses: " + option.ToString());

            if (option != DialogResult.Retry)
            {
                retryCount++;
            }
        }

        public void RemoveUser(int id) //TODO: move to FormUserManagement, DataManagement only responsible for direct database interaction
        {
            // query to remove a user from the database
            int rowsAffected = 1;
            ExecuteQuery($"DELETE FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id));

            if (rowsAffected > 0)
            {
                MessageBox.Show($"Gebruiker succesvol verwijderd. ID: {id}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log($"User with ID {id} removed");
            }
            else
            {
                MessageBox.Show("Er is een fout opgetreden bij het verwijderen van de gebruiker.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log($"Failed to remove user with ID {id}");
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
            Log($"Updating points for user with ID {id} to {newPoints}, difference: {pointsToChange}");
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