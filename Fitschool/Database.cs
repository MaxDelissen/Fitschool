using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace Fitschool
{
    public class DataManagement
    {
        static readonly string connectionAddress = "server=192.168.154.75;database=fitschool;uid=Max;password=Password01;";

        // Aanmaken connectie naar Database.
        readonly MySqlConnection connection = new()
        {
            ConnectionString = connectionAddress
        };

        public void StartConnection() //opend de connectie wanneer de applicatie start, 
                                      //dit zorgt ervoor dat het programma al een keer verbinding heeft gemaakt, 
                                      //waardoor de laadtijd voor inloggen lager wordt.
        {
            try   { connection.Open(); }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij verbinden met MySQL database, Staat de VPN aan?", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally { connection.Close(); }
        }

        public string IdToName(int id) // Ingevoerd ID naar naam
        {
            // Naam word opgevraagd.
            string name = RetrieveFromDB(id, "name");

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
        
        public int IdToPoints(int id) // ID naar aantal verzamelde punten.
        {
            // Het aantal punten uit de database halen.
            if (!int.TryParse(RetrieveFromDB(id, "points"), out int points))
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
        }

        public void AddUser(string naam, int leeftijd)
        {
            try
            {
                // Verbinding maken met de Database
                connection.Open();
            }
            catch (Exception ex) // Verbindingsfout, mogelijk staat de VPN of het Netlab uit.
            {
                MessageBox.Show("Fout bij verbinden met MySQL database, Staat de VPN aan?", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            try
            {
                // SQL-query voor het toevoegen van een gebruiker
                string query = $"INSERT INTO users (name, age) VALUES ('{naam}', {leeftijd})";

                // MySqlCommand object aanmaken
                MySqlCommand command = new(query, connection);

                // Query uitvoeren om de gebruiker toe te voegen
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Gebruiker succesvol toegevoegd.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Er is een fout opgetreden bij het toevoegen van de gebruiker.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het uitvoeren van de query: {ex.Message}");
            }
            finally
            {
                // Verbinding sluiten, ongeacht het resultaat
                connection.Close();
            }
        }

        public void WritePointsToDB(int id, int pointsToChange)
        {
            int currentPoints = IdToPoints(id);
            int newPoints = currentPoints + pointsToChange;

            try
            {
                // Verbinding maken met de Database
                connection.Open();
            }
            catch (Exception ex) // Verbindingsfout, mogelijk staat de VPN of het Netlab uit.
            {
                MessageBox.Show("Fout bij verbinden met MySQL database, Staat de VPN aan?", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            try
            {
                // SQL-query voor het toevoegen van een gebruiker
                string query = $"UPDATE users SET points = {newPoints} WHERE userID = {id}";

                // MySqlCommand object aanmaken
                MySqlCommand command = new(query, connection);

                // Query uitvoeren om de gebruiker toe te voegen
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Punten succesvol toegevoegd.");
                }
                else
                {
                    Console.WriteLine("Punten toevoegen is mislukt.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het uitvoeren van de query: {ex.Message}");
            }
            finally
            {
                // Verbinding sluiten, ongeacht het resultaat
                connection.Close();
            }
        }
    }
}