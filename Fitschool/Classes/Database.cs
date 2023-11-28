using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Fitschool
{
    public class DataManagement
    {
        private static readonly string connectionAddress = "server=192.168.154.75;database=fitschool;uid=Max;password=Password01;";

        public static string ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            string result = "";
            int maxRetries = 3; // Maximum aantal keer dat je opnieuw verbinding kan proberen te maken met de database
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
                        // niet doorgaan met de query
                        break;
                    }
                    retryCount++;
                }
            }
            return result;
        }

        public static string IdToName(int id) // Ingevoerd ID naar naam
        {
            // Naam word opgevraagd.
            string name = ExecuteQuery("SELECT naam FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id));

            // Naam wordt teruggestuurd.
            return name;
        }

        public static int IdToAge(int id) // Ingevoerd ID naar leeftijd
        {
            // Leeftijd wordt opgevraagd.
            string age = ExecuteQuery("SELECT leeftijd FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id));

            // Leeftijd wordt omgezet naar een integer.
            if (!int.TryParse(age, out int ageInt))
            {
                MessageBox.Show("Er is een fout opgetreden bij het omzetten van de leeftijd naar een geheel getal. De leeftijd is ingesteld op 0.",
                                                   "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            // Leeftijd wordt teruggestuurd.
            return ageInt;
        }

        public static int IdToPoints(int id) // ID naar aantal verzamelde punten.
        {
            // Het aantal punten uit de database halen.
            if (!int.TryParse(ExecuteQuery("SELECT punten_totaal FROM gebruikers WHERE gebruiker_id = @id", new MySqlParameter("@id", id)), out int points))
            {
                // Output van database kan niet worden omgezet naar een integer.
                MessageBox.Show("Er is een fout opgetreden bij het omzetten van punten naar een geheel getal. De punten zijn ingesteld op 0.",
                                "Error parsing output", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            // Wanneer punten om kunnen worden gezet, deze teruggeven.
            return points;
        }

        public static void AddUser(string naam, int leeftijd, string email)
        {
            // Query uitvoeren om de gebruiker toe te voegen en de laatst ingevoegde ID ophalen
            string query =
                @"
                    INSERT INTO gebruikers (gebruiker_id, naam, leeftijd, email_ouder)
                    SELECT COALESCE(MIN(gebruiker_id) + 1, 1), @naam, @leeftijd, @email
                    FROM gebruikers
                    WHERE NOT EXISTS (SELECT 1 FROM gebruikers t2 WHERE t2.gebruiker_id = gebruikers.gebruiker_id + 1);
                    SELECT LAST_INSERT_ID() AS LastInsertID;
                ";


            object result = Convert.ToInt32(ExecuteQuery(query, new MySqlParameter("@naam", naam), new MySqlParameter("@leeftijd", leeftijd), new MySqlParameter("@email", email)));
            int lastInsertID = Convert.ToInt32(result);

            if (lastInsertID > 0)
            {
                MessageBox.Show($"Gebruiker succesvol toegevoegd. ID: {lastInsertID}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (lastInsertID == 0)
            {
                MessageBox.Show($"Gebruiker succesvol toegevoegd. ID kon niet worden opgevraagd.", "Succes??", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Er is een fout opgetreden bij het toevoegen van de gebruiker.", "Fout " + lastInsertID, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RemoveUser(int id)
        {
            // Query uitvoeren om de gebruiker te verwijderen
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
            int newPoints = currentPoints + pointsToChange;

            // Query uitvoeren om de gebruiker toe te voegen
            string stringRowsAffected = ExecuteQuery("UPDATE gebruikers SET punten_totaal = @newPoints WHERE gebruiker_id = @id; SELECT ROW_COUNT() AS RowsAffected;", new MySqlParameter("@newPoints", newPoints), new MySqlParameter("@id", id));
            int rowsAffected = Convert.ToInt32(stringRowsAffected);

            if (rowsAffected > 0)
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