using System;
using System.Collections.Specialized;
using System.IO.Ports;
namespace esp_nokia_time;

class Program
{
    static void Main(string[] args)
    {
        ComPort.Search();
        ComPort.Init("/dev/ttyUSB0");

        bool isOpen = ComPort.Open();
        Console.WriteLine($"isOpen {isOpen}");
        Thread.Sleep(8000);

        string cmd = DS3231.SetDay(WeekDay.Thursday);
        ComPort.Write(cmd);
        
        isOpen = ComPort.Close();
        Console.WriteLine($"isOpen {isOpen}");
    }
}
