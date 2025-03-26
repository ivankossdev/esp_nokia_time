using System.IO.Ports;
namespace esp_nokia_time;

public class ComPort
{
    static SerialPort _serialPort = new();
    public static void Search()
    {
        string[] ports = SerialPort.GetPortNames();

        if (ports.Length > 0)
        {
            foreach (string port in ports)
            {
                Console.WriteLine($"Searched device {port}");
            }
        }
        else
        {
            Console.WriteLine("No Ports");
        }
    }

    public static void Init(string comport)
    {
        _serialPort.PortName = comport;
        _serialPort.BaudRate = 115200;
        _serialPort.DataBits = 8;
    }

    public static void OpenPort()
    {
        _serialPort.Open();
    }

    public static void ReadPort()
    {
        _serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        Console.WriteLine(_serialPort.ReadLine());
    }

    private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        Console.WriteLine(_serialPort.ReadLine());
        _serialPort.DiscardInBuffer();
    }
}
