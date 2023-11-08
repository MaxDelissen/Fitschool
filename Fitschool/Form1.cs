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
                        command.Parameters.AddWithValue("@id", IDValue.Value); //haalt ID nummer op uit form, moet worden vervangen door scanner.

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //voorbeeld: naam is de huidige collom die word opgevraagd.
                                string value = reader["naam"].ToString();

                                MessageBox.Show("Data voor ID 12: " + value);
                            }
                            else
                            {
                                MessageBox.Show("Geen naam gevonden voor ID 12");
                            }
                        }
                    }
                }
                catch (Exception) //Fout wanneer de opgegeven MySQL database niet kan worden gevonden.
                {
                    MessageBox.Show("Fout bij verbinden met MySQL database");
                }

            }
        }
    }
}