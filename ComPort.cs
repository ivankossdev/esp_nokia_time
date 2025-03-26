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

        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;

        List<string> mySettings = [
            _serialPort.PortName,
            _serialPort.BaudRate.ToString(),
            _serialPort.Parity.ToString(),
            _serialPort.DataBits.ToString(),
            _serialPort.StopBits.ToString(),
            _serialPort.Handshake.ToString() ];

        foreach (string s in mySettings)
        {
            System.Console.WriteLine(s);
        }
    }

    public static void Open()
    {
        _serialPort.Open();
    }

    public static void Close()
    {
        _serialPort.Close();
    }

    public static void Write(string message){
        _serialPort.WriteLine(message);
    }

    public static void Read()
    {
        _serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        Console.WriteLine(_serialPort.ReadLine());
    }

    private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        _serialPort.DiscardInBuffer();
    }
}
