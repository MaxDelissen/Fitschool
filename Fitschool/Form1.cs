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

        private void Form1_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionAdress))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM YourTableName WHERE ID = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", 12); // ID 12 als voorbeeld, dit moet dadelijk van het pasje komen.

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
                catch (Exception)
                {
                    MessageBox.Show("Fout bij verbinden met MySQL database");
                }
                
            }
        }
    }
}