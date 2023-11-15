using System.IO.Ports;

namespace Fitschool
{
    public class Arduino
    {
        public readonly static string arduinoPort = "COM5";

        /*werkt niet
        public static string FindArduinoPort()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string currentPort in ports)
            {
                try
                {
                    SerialPort testPort = new(currentPort, 9600);
                    testPort.Open();
                    testPort.WriteLine("status"); // Stuur test commando naar Arduino
                    string response = testPort.ReadLine();
                    testPort.Close();

                    if (response.Contains("OK"))
                    {
                        MessageBox.Show("Arduino gevonden op poort " + currentPort, "Arduino gevonden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return currentPort; // Arduino gevonden
                    }
                }
                catch (UnauthorizedAccessException) {}
                catch (IOException) {}
                catch (TimeoutException) {}
            }
            MessageBox.Show("Geen Arduino gevonden", "Arduino niet gevonden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return string.Empty; // Geen poort gevonden
        }*/
    
        public static string SendCommand(string command)
        {
            SerialPort port = new(arduinoPort, 9600);
            port.Open();
            port.ReadTimeout = 1000;
            port.WriteLine(command);
            Thread.Sleep(500);
            string readout;
            try
            {
                readout = port.ReadLine();
                return readout;
            } 
            catch (TimeoutException)
            {
                MessageBox.Show("Arduino reageert niet", "Arduino niet gevonden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return  string.Empty;
            }
            finally
            {
                port.Close();
            }
        }
    }
}
