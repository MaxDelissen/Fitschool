using MySql;
using MySql.Data.MySqlClient;

public class DataManagement
{
    string connectionAdress = "server=192.168.154.75;database=test;uid=Max;password=Password01;";

    public string IdToName(int id) //functie om naam op te halen.
    {
        string name = RetrieveFromDB(id, "naam");
        if (name.Contains("Error"))
        {
            return "Error Requesting Name";
        }
        return name;
    }

    public int IdToPoints(int id) //functie om punten te op te halen
    {
        int points;
        if (!(Int32.TryParse(RetrieveFromDB(id, "points"), out points)))
        {
            MessageBox.Show("Failed to convert points to an integer, points has been set to 0", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return 0;
        }
        
        return points;
    }

    public string RetrieveFromDB(int id, string columm) //functie om data uit de database te vragen, Neemt een student id, en de colom om de data uit te halen.
    {
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = connectionAdress;

        try
        {
            //verbinding maken met SQL database, wanneer dit niet werkt error vangen, zie onderaan.
            connection.Open();

            //SQL query, Kan misschien nog beter?
            string query = "SELECT * FROM YourTableName WHERE ID = @id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())//controleerd of data is gevonden voor ID;
                    {
                        if (string.IsNullOrEmpty(columm))
                        {
                            MessageBox.Show("Invalid column name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connection.Close();
                            return "Error: Invalid column name.";
                        }

                        string value = reader[columm].ToString();
                        connection.Close();
                        if (value != null)
                        {
                            return value;
                        }
                        else
                        {
                            return "Error: Column was empty.";
                        }
                    }
                    else //== geen data gevonden voor het opgevraagde id, mogelijk geen id.
                    {
                        MessageBox.Show("Geen gegevens gevonden voor ID " + id, "Geen gegevens voor " + id, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        connection.Close();
                        return ("Error: No data found");
                    }
                }
        }
        catch (Exception expetion) //Fout wanneer de opgegeven MySQL database niet kan worden gevonden.
        {
            MessageBox.Show("Fout bij verbinden met MySQL database", "Verbindingsfout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return ("Error: Database connection failed" + expetion);
        }

        
    }

    public void WritePointsToDB(int id, int pointsToAdd)
    {
        int currentPoints = IdToPoints(id);
        int newPoints = currentPoints + pointsToAdd;

        //todo: finish method
    }

}
