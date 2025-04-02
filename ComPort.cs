using System.IO.Ports;
namespace esp_nokia_time;

public class ComPort
{
    protected static SerialPort _serialPort = new();
    protected static void Init(string comport)
    {
        _serialPort.PortName = comport;
        _serialPort.BaudRate = 115200;
        _serialPort.DataBits = 8;

        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;

    }

    protected static bool Open()
    {   
        _serialPort.Open();
        return _serialPort.IsOpen;
    }

    protected static bool Close()
    {
        _serialPort.Close();
        return _serialPort.IsOpen;
    }

    protected static void Write(string message){
        _serialPort.WriteLine(message);
    }

    protected static void Read()
    {
        _serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        Console.WriteLine(_serialPort.ReadLine());
    }

    private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        _serialPort.DiscardInBuffer();
    }
}
