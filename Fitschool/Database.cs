using MySql.Data.MySqlClient;

namespace Fitschool
{
    public class DataManagement
    {
        readonly string connectionAddress = "server=192.168.154.75;database=test;uid=Max;password=Password01;";

        public string IdToName(int id) // Aangrijpend drama: de zoektocht naar een naam.
        {
            // Een intense dialoog met de database, op zoek naar de voornaam van het personage met de opgegeven ID.
            string name = RetrieveFromDB(id, "users", "voornaam");

            // Een onverwachte wending! Een dramatische ontmoeting met een foutbericht.
            if (name.Contains("Error"))
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de voornaam. " +
                                "Probeer het later opnieuw. De gebruiker wordt gelogd als 'Onbekend'.",
                                "Drama in de Database", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Het hoofdpersonage wordt gelogd als 'Onbekend'.
                return "Onbekend";
            }

            // De climax! De langverwachte naam wordt onthuld en het publiek houdt de adem in.
            return name;
        }
        
        public string IdToSurName(int id) // Een zinderend vervolg: de zoektocht naar een achternaam.
        {
            // Het tweede bedrijf begint: een dramatische interactie met de database, op zoek naar de achternaam van het personage met de opgegeven ID.
            string surName = RetrieveFromDB(id, "users", "achternaam");

            // Een onverwachte wending! Een schokkende ontmoeting met een foutbericht.
            if (surName.Contains("Error"))
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van de achternaam. " +
                                "Probeer het later opnieuw. De gebruiker wordt gelogd als 'Onbekend'.",
                                "Drama in de Database", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Het hoofdpersonage wordt gelogd als 'Onbekend'.
                return "Onbekend";
            }

            // De climax bereikt zijn hoogtepunt! De langverwachte achternaam wordt onthuld en het publiek is in spanning.
            return surName;
        }

        public int IdToPoints(int id) // Het epische slotstuk: de queeste naar punten.
        {
            // De spannende introductie: een poging om de punten van het personage met de opgegeven ID op te halen.
            if (!int.TryParse(RetrieveFromDB(id, "punten", "punten_waarde"), out int points))
            {
                // Een dramatische wending! Een mislukte poging om punten om te zetten naar een geheel getal.
                MessageBox.Show("Er is een fout opgetreden bij het omzetten van punten naar een geheel getal. De punten zijn ingesteld op 0.",
                                "Parsing Drama", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Het publiek houdt de adem in, wetende dat de punten zijn vastgesteld op 0.
                return 0;
            }

            // Het indrukwekkende slot: de triomfantelijke onthulling van het aantal punten dat het personage heeft vergaard.
            return points;
        }


        //2 tables, users & punten
        // Het grote toneelstuk: De queeste naar data uit de mysterieuze database, waarin twee tafels, 'users' en 'punten', een cruciale rol spelen.
        public string RetrieveFromDB(int id, string table, string columm) // Een epische functie die data uit de diepten van de database opvraagt. Neemt een student-ID en de kolom om de gegevens uit te halen.
        {
            // Het opdoemen van de magische poort: Een nieuwe verbinding met de MySQL-database wordt gesmeed.
            MySqlConnection connection = new()
            {
                ConnectionString = connectionAddress
            };

            try
            {
                // Het betreden van het mystieke rijk: De verbinding wordt geopend om toegang te krijgen tot de geheimen van de database.
                connection.Open();
            }

            catch (Exception ex) // Het noodlot slaat toe: Een fout wordt onthuld wanneer de geheime database onvindbaar blijkt.
            {
                MessageBox.Show("Fout bij verbinden met MySQL database", "Verbindingsfout", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return $"Error: De magische connectie met de database is verbroken: {ex.Message}";
            }

            // De verlichte scripten: Een betoverende SQL-query wordt gecreëerd, met de hoop op betoverende resultaten.
            string query = $"SELECT * FROM {table} WHERE idUsers = @id";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            // Het lezen van de rollen: De data wordt onthuld, met bated breath wordt gewacht op het schouwspel.
            using MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read()) // Het grote mysterie: Wordt er data gevonden voor het opgegeven ID?
            {
                MessageBox.Show($"Geen gegevens gevonden voor ID {id}", $"Geen gegevens voor {id}", MessageBoxButtons.OK, MessageBoxIcon.Question);

                // Het tragische einde: Geen data gevonden, het doek valt.
                connection.Close();
                return "Error: Geen data gevonden";
            }

            if (string.IsNullOrEmpty(columm))
            {
                // Het duistere geheim: Een ongeldige kolomnaam wordt ontdekt.
                MessageBox.Show("Ongeldige kolomnaam.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();

                // Het einde is nabij: Een ongeldige kolomnaam wordt het toneelstuk onwaardig geacht.
                return "Error: Ongeldige kolomnaam.";
            }

            try
            {
                // Het hoogtepunt: De opgevraagde waarde wordt onthuld, een meeslepende climax in het grote toneelstuk.
                string value = reader[columm]?.ToString() ?? string.Empty;
                connection.Close();

                // Het oordeel: Is de kolom leeg of heeft deze een duister geheim?
                return string.IsNullOrEmpty(value) ? "Error: Kolom is leeg." : value;
            }
            catch (Exception ex)
            {
                // Het noodlot slaat toe: Een onverwachte wending, een technisch drama ontvouwt zich.
                Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");

                // Het bitterzoete einde: De opgevraagde data blijkt onvindbaar in de database.
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