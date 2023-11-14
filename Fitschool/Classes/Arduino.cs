using System.IO.Ports;

namespace Fitschool
{
    public class Arduino
    {
        public readonly static string arduinoPort = FindArduinoPort();

        private static string FindArduinoPort()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string currentPort in ports)
            {
                try
                {
                    SerialPort testPort = new(currentPort, 9600);
                    testPort.Open();
                    testPort.WriteLine("status"); // Stuur test commando naar Arduino
                    Thread.Sleep(100); // Wachten op andwoord van Arduino
                    string response = testPort.ReadExisting();
                    testPort.Close();

                    if (response.Contains("OK"))
                    {
                        return currentPort; // Arduino gevonden
                    }
                }
                catch (UnauthorizedAccessException) { /* Poort in gebruik, toegang geweigerd. */ }
                catch (IOException) { /* Ongeldige poort */ }
                catch (TimeoutException) { /* Arduino heeft niet gereageerd */ }
            }

            return string.Empty; // Geen poort gevonden
        }
    
        public static void SendCommand(string command)
        {
            SerialPort port = new(arduinoPort, 9600);
            port.Open();
            port.WriteLine(command);
            port.Close();
        }

        public static string ReadOut()
        {
            SerialPort port = new(arduinoPort, 9600);
            port.Open();
            string readout = port.ReadLine();
            port.Close();
            return readout;
        }
    }
}
