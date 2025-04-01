using System;
using System.Collections.Specialized;
using System.IO.Ports;
namespace esp_nokia_time;

class Program
{
    static void Main(string[] args)
    {
        Commands cmd = new();

        ComPort.Search();
        ComPort.Init("/dev/ttyUSB0");

        bool isOpen = ComPort.Open();
        Console.WriteLine($"isOpen {isOpen}");
        Thread.Sleep(10000);

        ComPort.Write(cmd.SetDate());
        Thread.Sleep(2000);

        ComPort.Write(cmd.SetMonth());
        Thread.Sleep(2000);

        ComPort.Write(cmd.SetYear());
        Thread.Sleep(2000);

        ComPort.Write(cmd.SetDay());
        Thread.Sleep(2000);

        ComPort.Write(cmd.SetTime());
        Thread.Sleep(2000);

        isOpen = ComPort.Close();
        Console.WriteLine($"isOpen {isOpen}");
    }
}
