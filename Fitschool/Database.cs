using MySql.Data.MySqlClient;

namespace Fitschool
{
    public class DataManagement
    {
        readonly string connectionAddress = "server=192.168.154.75;database=test;uid=Max;password=Password01;";

        public string IdToName(int id) //functie om naam op te halen.
        {
            string name = RetrieveFromDB(id, "users", "voornaam");
            if (name.Contains("Error"))
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de voornaam. " +
                                "Probeer het later opnieuw. De gebruiker wordt gelogd als 'Unknown'.",
                                "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Unknown";
            }
            return name;
        }

        public string IdToSurName(int id) //functie om naam op te halen.
        {
            string name = RetrieveFromDB(id, "users", "achternaam");
            if (name.Contains("Error"))
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de achternaam. " +
                                "Probeer het later opnieuw. De gebruiker wordt gelogd als 'Unknown'.",
                                "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Unknown";
            }
            return name;
        }

        public int IdToPoints(int id) //functie om punten te op te halen
        {
            if (!int.TryParse(RetrieveFromDB(id, "punten", "punten_waarde"), out int points))
            {
                MessageBox.Show("Failed to convert points to an integer, points has been set to 0", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return points;
        }

        //2 tables, users & punten
        public string RetrieveFromDB(int id, string table, string columm) //functie om data uit de database te vragen, Neemt een student id, en de colom om de data uit te halen.
        {
            MySqlConnection connection = new()
            {
                ConnectionString = connectionAddress
            };

            try
            {
                //verbinding maken met SQL database, wanneer dit niet werkt error vangen, zie onderaan.
                connection.Open();
            }

            catch (Exception ex) //Fout wanneer de opgegeven MySQL database niet kan worden gevonden.
            {
                MessageBox.Show("Fout bij verbinden met MySQL database", "Verbindingsfout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return "Error: Database connection failed" + ex.Message;
            }

            //SQL query, Kan misschien nog beter?
            string query = $"SELECT * FROM {table} WHERE idUsers = @id";

            MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@id", id);
 
            using MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())//controleerd of data is gevonden voor ID;
            {
                MessageBox.Show("Geen gegevens gevonden voor ID " + id, "Geen gegevens voor " + id, MessageBoxButtons.OK, MessageBoxIcon.Question);
                connection.Close();
                return "Error: No data found";
            }

            if (string.IsNullOrEmpty(columm))
            {
                MessageBox.Show("Invalid column name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return "Error: Invalid column name.";
            }

            try
            {
                string value = reader[columm]?.ToString() ?? string.Empty;
                connection.Close();

                return string.IsNullOrEmpty(value) ? "Error: Column was empty." : value;
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or display an error message
                // You can also rethrow the exception if you want to propagate it further
                Console.WriteLine($"An error occurred: {ex.Message}");
                return $"Error: The opgevraagde data was niet gevonden in de database: {ex.Message}";
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