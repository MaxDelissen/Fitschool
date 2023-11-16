using System.IO.Ports;

namespace Fitschool
{
    public class Arduino
    {
        public readonly static string arduinoPort = "COM5";

        public static string SendCommand(string command)
        {
            SerialPort port = new(arduinoPort, 9600);
            try
            {
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
                    return "Not responding";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Arduino niet verbonden met correcte poort", "Arduino niet gevonden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Not connected";
            }
            finally
            {
                port.Close();
            }
        }
    }
}
    

