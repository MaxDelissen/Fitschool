using System.IO.Ports;
using System.Text.RegularExpressions;

namespace Fitschool
{
    public class Arduino
    {
        public readonly static string arduinoPort = "COM5";

        public static string SendCommand(string command)
        {
            try
            {
                SerialPort port = new(arduinoPort, 9600);
                port.Open();
                port.WriteLine(command);
                string readout = string.Empty;
                while (true)
                {
                    port.ReadTimeout = 1000;
                    try
                    {
                        readout = port.ReadLine();
                    }
                    catch (Exception) { }

                    if (!string.IsNullOrEmpty(readout))
                    {
                        port.Close();
                        return readout;
                    }
                }
            }
            catch (Exception)
            {
                return "Arduino niet correct verbonden, verbind aub met: " + arduinoPort;
            }
        }
    }
}
    

