using MySql.Data.MySqlClient;

namespace Fitschool
{
    public class DataManagement
    {
        private static readonly string connectionAddress = "server=192.168.154.75;database=fitschool;uid=Max;password=Password01;";

        public static string ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            string result = "";

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
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                Console.WriteLine($"Error executing query: {ex.Message}");
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
            int lastInsertedId = Convert.ToInt32(ExecuteQuery($"INSERT INTO users (name, age) VALUES (@naam, @leeftijd); SELECT SCOPE_IDENTITY();", new MySqlParameter("@naam", naam), new MySqlParameter("@leeftijd", leeftijd)));

            if (lastInsertedId > 0)
            {
                MessageBox.Show($"Gebruiker succesvol toegevoegd. ID: {lastInsertedId}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Er is een fout opgetreden bij het toevoegen van de gebruiker.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            int rowsAffected = Convert.ToInt32(ExecuteQuery("UPDATE users SET points = @newPoints WHERE userID = @id", new MySqlParameter("@newPoints", newPoints), new MySqlParameter("@id", id)));

            if (rowsAffected > 0)
            {
                Console.WriteLine("Punten succesvol toegevoegd.");
            }
            else
            {
                Console.WriteLine("Punten toevoegen is mislukt.");
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
                Console.WriteLine("Ongeldige kolomnaam.");
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
                Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");

                // Stuurt een error terug.
                return $"Error: De opgevraagde data was niet gevonden in de database: {ex.Message}";
            }
        } */