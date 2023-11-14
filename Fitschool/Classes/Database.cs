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
                    using MySqlConnection connection = new MySqlConnection(connectionAddress);
                    connection.Open();

                    using MySqlCommand command = new MySqlCommand(query, connection);

                    // Add parameters if provided
                    command.Parameters.AddRange(parameters);

                    // Execute the query
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result += reader[0].ToString();
                        }
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
            string name = ExecuteQuery("SELECT name FROM users WHERE userID = @id", new MySqlParameter("@id", id));

            // Naam wordt teruggestuurd.
            return name;
        }

        public static int IdToAge(int id) // Ingevoerd ID naar leeftijd
        {
            // Leeftijd wordt opgevraagd.
            string age = ExecuteQuery("SELECT age FROM users WHERE userID = @id", new MySqlParameter("@id", id));

            // Leeftijd wordt omgezet naar een integer.
            if (!int.TryParse(age, out int ageInt))
            {
                // Leeftijd kan niet worden omgezet naar een integer.
                MessageBox.Show("Er is een fout opgetreden bij het omzetten van de leeftijd naar een geheel getal. De leeftijd is ingesteld op 0.",
                                                   "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Na deze fout leeftijd op 0 zetten.
                return 0;
            }

            // Leeftijd wordt teruggestuurd.
            return ageInt;
        }

        public static int IdToPoints(int id) // ID naar aantal verzamelde punten.
        {
            // Het aantal punten uit de database halen.
            if (!int.TryParse(ExecuteQuery("SELECT points FROM users WHERE userID = @id", new MySqlParameter("@id", id)), out int points))
            {
                // Output van database kan niet worden omgezet naar een integer.
                MessageBox.Show("Er is een fout opgetreden bij het omzetten van punten naar een geheel getal. De punten zijn ingesteld op 0.",
                                "Error parsing output", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Na deze fout punten op 0 zetten.
                return 0;
            }

            // Wanneer punten om kunnen worden gezet, deze teruggeven.
            return points;
        }

        public static void AddUser(string naam, int leeftijd)
        {
            // Query uitvoeren om de gebruiker toe te voegen en de laatst ingevoegde ID ophalen
            string query =
                @"
                    INSERT INTO users (userID, name, age)
                    SELECT COALESCE(MIN(userID) + 1, 1), @naam, @leeftijd
                    FROM users
                    WHERE NOT EXISTS (SELECT 1 FROM users t2 WHERE t2.userID = users.userID + 1);
                    SELECT LAST_INSERT_ID() AS LastInsertID;
                ";


            object result = Convert.ToInt32(ExecuteQuery(query, new MySqlParameter("@naam", naam), new MySqlParameter("@leeftijd", leeftijd)));
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
                MessageBox.Show("Er is een fout opgetreden bij het toevoegen van de gebruiker.", "Fout " + lastInsertID , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RemoveUser(int id)
        {
            // Query uitvoeren om de gebruiker te verwijderen
            int rowsAffected = Convert.ToInt32(ExecuteQuery($"DELETE FROM users WHERE userID = @id", new MySqlParameter("@id", id)));

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
            string stringRowsAffected = ExecuteQuery("UPDATE users SET points = @newPoints WHERE userID = @id; SELECT ROW_COUNT() AS RowsAffected;", new MySqlParameter("@newPoints", newPoints), new MySqlParameter("@id", id));
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

/* Deprecated
 * 
        //2 tables, users & punten in de DB
        public string RetrieveFromDB(int id, string columm) // Haalt gegevens uit database, neemt een string voor de kolom.
        {
            try
            {
                // Verbinding maken met de Database
                connection.Open();
            }

            catch (Exception ex) // Verbindingsfout, mogelijk staat de VPN of het Netlab uit.
            {
                MessageBox.Show("Fout bij verbinden met MySQL database, Staat de VPN aan?", "Verbindingsfout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return $"Error: Verbindingsfout: {ex.Message}";
            }

            // SQL Query om de opgegeven gegevens uit de DB te halen.
            string query = $"SELECT * FROM users WHERE userID = @id";

            //Stuur SQL query naar DB
            MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@id", id);

            // Uitlezen van de resultaten.
            using MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read()) // Wanneer er geen gegevens terugkomen een error sturen.
            {
                MessageBox.Show($"Geen gegevens gevonden voor ID {id}", $"Geen gegevens voor {id}", MessageBoxButtons.OK, MessageBoxIcon.Question);

                // Geen data gevonden, sluit de connectie met DB
                connection.Close();
                return "Error: Geen data gevonden";
            }

            if (string.IsNullOrEmpty(columm))
            {
                // De ingevoerde kolom bestaat niet.
                Debug.WriteLine("Ongeldige kolomnaam.");
                connection.Close();

                // Kolom bestaat niet, fout terugsturen en connectie sluiten.
                return "Error: Ongeldige kolomnaam.";
            }

            try
            {
                // de string "value" wordt gezet naar de output van de query, wanneer deze leeg is wordt de string ook leeg (ipv null)
                string value = reader[columm]?.ToString() ?? string.Empty;
                connection.Close();

                // Sluit de connectie en stuurt de waarde terug, als deze leeg is geeft een error.
                return string.IsNullOrEmpty(value) ? "Error: Kolom is leeg." : value;
            }
            catch (Exception ex)
            {
                // Een probleem met het lezen van de output, dit zou normaal nooit moeten gebeuren, stuurt error message.
                Debug.WriteLine($"Er is een fout opgetreden: {ex.Message}");

                // Stuurt een error terug.
                return $"Error: De opgevraagde data was niet gevonden in de database: {ex.Message}";
            }
        } */