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
        ComPort.Open();
        Thread.Sleep(15000);
        for(int i = 1; i <=7; i++){
            ComPort.Write($"setdy{i}");
            System.Console.WriteLine($"setdy{i}");
            Thread.Sleep(3000);
        }
        ComPort.Close();
    }
}
