using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Fitschool
{
    public class DataManagement
    {
        private static readonly string connectionAddress = "server=192.168.154.75;database=fitschool;uid=Max;password=Password01;";

        public static int maxId = 0;


        public static string ExecuteQuery(string query, params MySqlParameter[] parameters)
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

                    // Execute the query
                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result += reader[0].ToString();
                    }

                    // If the query execution is successful, break out of the retry loop
                    break;
                }
                catch (Exception ex)
                {
                    // Handle exceptions as needed
                    Debug.WriteLine($"Error executing query: {ex.Message}");

                    DialogResult option;
                    if (retryCount >= maxRetries - 1)
                    {
                        Debug.WriteLine("Maximum retries reached. Exiting.");
                        option = MessageBox.Show("Maximaal aantal pogingen bereikt. Klik op 'Ja' om de applicatie af te sluiten, klik op 'Nee' om door te gaan, dit kan fouten opleveren.", "Fout: " + ex.Message, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (option == DialogResult.Yes)
                        {
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        option = MessageBox.Show("Fout bij ophalen van gegevens. Is de VPN ingeschakeld?\nAls u annuleert, kunnen er fouten optreden.", "Fout", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }

                    if (option != DialogResult.Retry)
                    {
                        // do not retry
                        break;
                    }
                    retryCount++;
                }
            }
            return result;
        }

        public static string IdToName(int id)
        {
            string name = ExecuteQuery("SELECT naam FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id));

            return name;
        }

        public static int IdToAge(int id)
        {
            string age = ExecuteQuery("SELECT leeftijd FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id));

            // Try to convert the age to an integer
            if (!int.TryParse(age, out int ageInt))
            {
                MessageBox.Show("Er is een fout opgetreden bij het omzetten van de leeftijd naar een geheel getal. De leeftijd is ingesteld op 0.",
                                                   "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return ageInt;
        }

        public static int IdToPoints(int id) // ID to the total amount of points in the database
        {
            if (!int.TryParse(ExecuteQuery("SELECT punten_totaal FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id)), out int points))
            {
                // failed to convert points to an integer
                MessageBox.Show("Er is een fout opgetreden bij het omzetten van punten naar een geheel getal. De punten zijn ingesteld op 0.",
                                "Error parsing output", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            // when the conversion is successful, return the points
            return points;
        }

        public static void RemoveUser(int id)
        {
            // query to remove a user from the database
            int rowsAffected = 1;
            ExecuteQuery($"DELETE FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id));

            if (rowsAffected > 0)
            {
                MessageBox.Show($"Gebruiker succesvol verwijderd. ID: {id}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Er is een fout opgetreden bij het verwijderen van de gebruiker.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void WritePointsToDB(int id, int pointsToChange)
        {
            int currentPoints = IdToPoints(id);
            int newPoints = currentPoints + pointsToChange; // calculate the new amount of points

            // Execute the query and get the amount of rows affected
            string stringRowsAffected = ExecuteQuery("UPDATE gebruikers SET punten_totaal = @newPoints WHERE gebruiker_id = @id; SELECT ROW_COUNT() AS RowsAffected;", new MySqlParameter("@newPoints", newPoints), new MySqlParameter("@id", id));
            int rowsAffected = Convert.ToInt32(stringRowsAffected);

            if (rowsAffected > 0) //check if the query was successful
            {
                Debug.WriteLine("Punten succesvol toegevoegd.");
            }
            else
            {
                Debug.WriteLine("Punten toevoegen is mislukt.");
            }
        }
    }
}