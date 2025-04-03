using System.IO.Ports;
namespace esp_nokia_time;

class Control : ComPort
{
    static MyDateTime dtm;
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
        if (PortChoice(ports))
        {
            try
            {

                Open();
                SetParams();
                Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Порт занят другой программой\n{e}");
            }
        }
    }

    private static bool PortChoice(string[] ports)
    {
        ConsoleKeyInfo pressKey;
        bool state = false;
        do
        {
            Console.WriteLine(Message.exit);
            Console.WriteLine(Message.enterNumPort);
            pressKey = Console.ReadKey();

            int num = Convert.ToInt32(pressKey.KeyChar) & 0x0f;

            if (num <= ports.Length - 1)
            {
                Console.WriteLine($"[ {num} ] {ports[num]}");
                Init(ports[num]);

                state = true;
                break;
            }
            else if (pressKey.Key != ConsoleKey.Escape)
            {
                Console.WriteLine(Message.errorNumPort);
            }
        } while (pressKey.Key != ConsoleKey.Escape);

        return state;
    }

    private static void SetParams()
    {
        ConsoleKeyInfo pressKey;
        Console.WriteLine(Message.pointsMenu);
        do
        {
            dtm = Commands.GetDateTime();
            pressKey = Console.ReadKey();
            int point = Convert.ToInt32(pressKey.KeyChar) & 0x0f;
            bool defoult_ = false;

            switch (point)
            {
                case 1: Console.Clear(); Write(Commands.SetTime()); break;
                case 2: Console.Clear(); Write(Commands.SetDate()); break;
                case 3: Console.Clear(); Write(Commands.SetDay()); break;
                case 4: Console.Clear(); Write(Commands.SetMonth()); break;
                case 5: Console.Clear(); Write(Commands.SetYear()); break;

                default: defoult_ = true; break;
            }
            if (!defoult_)
            {
                Console.WriteLine($"Параметр [ {point} ] синхронизирован.\n\n");
                Console.WriteLine(Message.pointsMenu);
                Console.WriteLine(Message.exit);
            }
            else
            {
                Console.WriteLine(Message.pointsMenu);Console.WriteLine(Message.pointsMenu);
            }
        } while (pressKey.Key != ConsoleKey.Escape);
        Console.Clear();
    }
}