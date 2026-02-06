using System.Diagnostics;
using System.IO.Ports;
namespace esp_nokia_time;

public class ComPort
{
    protected static SerialPort _serialPort = new();
    protected static void Init(string comport, int baudRate)
    {
        _serialPort.PortName = comport;
        _serialPort.BaudRate = baudRate;
        _serialPort.DataBits = 8;
        _serialPort.DtrEnable = true;

        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;

    }

    /// <summary>
    /// Открывает порт для чтения или записи данных
    /// </summary>
    /// <returns></returns>
    protected static bool Open()
    {   
        _serialPort.Open();
        return _serialPort.IsOpen;
    }

    /// <summary>
    /// Закрывает порт 
    /// </summary>
    /// <returns></returns>
    protected static bool Close()
    {
        _serialPort.Close();
        return _serialPort.IsOpen;
    }

    /// <summary>
    /// Закрывает порт 
    /// </summary>
    /// <param name="message"></param>
    protected static void Write(string message){
        _serialPort.WriteLine(message);
    }

    protected static void ReadLine()
    {
        try
        {
            string message = _serialPort.ReadLine();
            Console.WriteLine(message);
        }
        catch (TimeoutException) { }
    }
}
