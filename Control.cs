using System.IO.Ports;
namespace esp_nokia_time;

class Control : ComPort
{

    public static void Programm()
    {
        Console.WriteLine(Message.searchedDevice);

        string[] ports = SerialPort.GetPortNames();
        if (ports.Length > 0)
        {
            for (int i = 0; i < ports.Length; i++)
            {
                Console.WriteLine($"[ {i} ] [ {ports[i]} ]");
            }
        }

        Console.WriteLine(Message.enterNumPort);
        ConsoleKeyInfo numPort = Console.ReadKey();
        int num = Convert.ToInt32(numPort.KeyChar) & 0x0f;
        if (num <= ports.Length - 1)
        {
            Console.WriteLine($"[ {num} ] [ {ports[num]} ]");
            Init(ports[num]);
            bool isOpen = Open();
            Console.WriteLine($"isOpen {isOpen}");
            SynchroTime();
            isOpen = Close();
            Console.WriteLine($"isOpen {isOpen}");
        }
        else
        {
            Console.WriteLine(Message.errorNumPort);
        }
    }

    public static void SynchroTime()
    {
        Thread.Sleep(10000);

        Commands cmd = new();

        Write(cmd.SetDate());
        Thread.Sleep(2000);

        Write(cmd.SetMonth());
        Thread.Sleep(2000);

        Write(cmd.SetYear());
        Thread.Sleep(2000);

        Write(cmd.SetDay());
        Thread.Sleep(2000);

        Write(cmd.SetTime());
        Thread.Sleep(2000);
    }
}