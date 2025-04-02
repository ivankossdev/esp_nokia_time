using System.IO.Ports;
namespace esp_nokia_time;

class Control : ComPort
{
    
    public static void Prog()
    {
        Console.WriteLine(Message.searchedDevice);

        string[] ports = SerialPort.GetPortNames();
        if (ports.Length > 0)
        {
            for (int i = 0; i < ports.Length; i++)
            {
                Console.WriteLine($"[ {i} ] {ports[i]}");
            }
        }
        PortChoice(ports);
    }

    private static void PortChoice(string[] ports){
        ConsoleKeyInfo numPort;
        do
        {
            Console.WriteLine(Message.exit);
            Console.WriteLine(Message.enterNumPort);
            numPort = Console.ReadKey();

            int num = Convert.ToInt32(numPort.KeyChar) & 0x0f;
            
            if (num <= ports.Length - 1)
            {
                Console.WriteLine($"[ {num} ] {ports[num]}");
                Init(ports[num]);
                break;
            }
            else if (numPort.Key != ConsoleKey.Escape)
            {
                Console.WriteLine(Message.errorNumPort);
            }
        } while (numPort.Key != ConsoleKey.Escape);
    }

}