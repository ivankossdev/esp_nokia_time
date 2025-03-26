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
        ComPort.OpenPort();
        ComPort.ReadPort();
    }
}
