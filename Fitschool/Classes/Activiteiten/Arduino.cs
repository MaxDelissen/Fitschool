using System.IO.Ports;

namespace Fitschool.Classes.Activiteiten
{
    public class Arduino
    {
        public readonly static string arduinoPort = "COM5";

        public static string SendCommand(string command)
        {
            string errorMessage = "Arduino niet correct verbonden, verbind aub met: " + arduinoPort;

            try
            {
                using (SerialPort port = new SerialPort(arduinoPort, 9600))
                {
                    port.Open();
                    port.WriteLine(command);

                    string readout = string.Empty;
                    port.ReadTimeout = 1000;

                    try
                    {
                        readout = port.ReadLine();
                    }
                    catch (TimeoutException)
                    {
                        // Handle timeout if needed
                    }

                    port.Close();

                    if (!string.IsNullOrEmpty(readout))
                    {
                        return readout;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                errorMessage = "Unauthorized Access: Check if another program is using " + arduinoPort;
            }
            catch (Exception ex)
            {
                errorMessage = "Error communicating with Arduino: " + ex.Message;
            }

            return errorMessage;
        }
    }
}
