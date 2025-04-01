using System;
using System.Collections.Specialized;
using System.IO.Ports;
namespace esp_nokia_time;

class Program
{
    static void Main(string[] args)
    {
        Commands cmd = new();
        Console.WriteLine(cmd.SetDate());
        Console.WriteLine(cmd.SetDay());
        Console.WriteLine(cmd.SetMonth());
        Console.WriteLine(cmd.SetYear());
        // ComPort.Search();
        // ComPort.Init("/dev/ttyUSB0");

        // bool isOpen = ComPort.Open();
        // Console.WriteLine($"isOpen {isOpen}");
        // Thread.Sleep(8000);
        // ComPort.Write(cmd.SetDay());
        
        // isOpen = ComPort.Close();
        // Console.WriteLine($"isOpen {isOpen}");
    }
}
