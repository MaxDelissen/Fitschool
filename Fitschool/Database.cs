using MySql.Data.MySqlClient;

namespace Fitschool
{
    public class DataManagement
    {
        readonly string connectionAddress = "server=192.168.154.75;database=fitschool;uid=Max;password=Password01;";

        public string IdToName(int id) // Ingevoerd ID naar naam
        {
            // Naam word opgevraagd.
            string name = RetrieveFromDB(id, "users", "name");

            // Error met opvragen naam
            if (name.Contains("Error"))
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de voornaam. " +
                                "Probeer het later opnieuw. De gebruiker wordt gelogd als 'Onbekend'.",
                                "Drama in de Database", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // De naam wordt gelogd als 'Onbekend'.
                return "Onbekend";
            }

            // Naam wordt teruggestuurd.
            return name;
        }
        
        /// !! Niet meer gebruikt, Voor & Achternaam zitten nu in één kolom. !!
        /*public string IdToSurName(int id) // ID naar achternaam
        {
            // Opvragen achternaam uit DB
            string surName = RetrieveFromDB(id, "users", "achternaam");

            // Error met opvragen
            if (surName.Contains("Error"))
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de achternaam. " +
                                "Probeer het later opnieuw. De gebruiker wordt gelogd als 'Onbekend'.",
                                "Drama in de Database", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // De naam wordt gelogd als 'Onbekend'.
                return "Onbekend";
            }

            // Achternaam terugsturen
            return surName;
        }*/

        public int IdToPoints(int id) // ID naar aantal verzamelde punten.
        {
            // Het aantal punten uit de database halen.
            if (!int.TryParse(RetrieveFromDB(id, "users", "points"), out int points))
            {
                // Output van database kan niet worden omgezet naar een integer.
                MessageBox.Show("Er is een fout opgetreden bij het omzetten van punten naar een geheel getal. De punten zijn ingesteld op 0.",
                                "Parsing Drama", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Na deze fout punten op 0 zetten.
                return 0;
            }

            // Wanneer punten om kunnen worden gezet, deze teruggeven.
            return points;
        }


        //2 tables, users & punten in de DB
        public string RetrieveFromDB(int id, string table, string columm) // Een epische functie die data uit de diepten van de database opvraagt. Neemt een student-ID en de kolom om de gegevens uit te halen.
        {
            // Aanmaken connectie naar Database.
            MySqlConnection connection = new()
            {
                ConnectionString = connectionAddress
            };

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
            string query = $"SELECT * FROM {table} WHERE id = @id";

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
                MessageBox.Show("Ongeldige kolomnaam.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }


        public void WritePointsToDB(int id, int pointsToAdd)
        {
            int currentPoints = IdToPoints(id);
            int newPoints = currentPoints + pointsToAdd;

            //todo: finish method
        }

    }
}