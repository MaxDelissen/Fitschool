using MySqlConnector;


namespace Fitschool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionAdress = "Server=myServerAddress;Database=myDatabase;User=myUsername;Password=myPassword;";

        private void RequestDataButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IdToName(IDValue.Value));
        }

        private string IdToName(decimal id)
        {
            string name = RetrieveFromDB(Convert.ToInt32(id), "naam");
            return name;
        }

        private string RetrieveFromDB(int id, string columm) //functie om data uit de database te vragen, Neemt een student id, en de colom om de data uit te halen.
        {
            using (MySqlConnection connection = new MySqlConnection(connectionAdress))
            {
                try
                {
                    //verbinding maken met SQL database, wanneer dit niet werkt error vangen, zie onderaan.
                    connection.Open();

                    //SQL query, Kan misschien nog beter?
                    string query = "SELECT * FROM YourTableName WHERE ID = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())//controleerd of data is gevonden voor ID;
                            {
                                if (string.IsNullOrEmpty(columm))
                                {
                                    MessageBox.Show("Invalid column name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    connection.Close();
                                    return "Invalid column name.";
                                }

                                string value = reader[columm].ToString();
                                connection.Close();
                                if (value != null)
                                {
                                    return value;
                                }
                                else
                                {
                                    return "Column was empty.";
                                }
                            }
                            else //== geen data gevonden voor het opgevraagde id, mogelijk geen id.
                            {
                                MessageBox.Show("Geen gegevens gevonden voor ID " + id, "Geen gegevens voor "+id, MessageBoxButtons.OK, MessageBoxIcon.Question);
                                connection.Close();
                                return ("No data found");
                            }
                        }
                    }
                }
                catch (Exception) //Fout wanneer de opgegeven MySQL database niet kan worden gevonden.
                {
                    MessageBox.Show("Fout bij verbinden met MySQL database", "Verbindingsfout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return ("Database connection failed");
                }

            }
        }
    }
}