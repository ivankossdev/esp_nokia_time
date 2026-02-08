using System.IO.Ports;
namespace esp_nokia_time;

/// <summary>
/// Класс управления com портом
/// </summary>
class Control : ComPort
{
    static MyDateTime dtm;

    /// <summary>
    /// Основная программа установки времени 
    /// </summary>
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

    /// <summary>
    /// Выбирает найденный порт
    /// </summary>
    /// <param name="ports"></param>
    /// <returns></returns>
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
                Init(ports[num], 9600);

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

    /// <summary>
    /// Отправляет данные для установки времени
    /// </summary>
    private static void SetParams()
    {
        ConsoleKeyInfo pressKey;
        Console.WriteLine(Message.pointsMenu);
        do
        {
            dtm = Commands.GetSystemDateTime();
            pressKey = Console.ReadKey();
            int point = Convert.ToInt32(pressKey.KeyChar);
            bool default_ = false;
            Console.Clear();
            Console.WriteLine($"Нажата кнопка {pressKey.Key} {pressKey.KeyChar}");

            switch (point)
            {
                case 49: Write(Commands.GetSystemTime()); break;
                case 50: Write(Commands.GetSystemDate()); break; 
                case 51: Write("pin on\r\n"); break; 
                case 52: Write("pin off\r\n"); break;

                default: default_ = true; break;
            }
            if (!default_)
            {
                Console.WriteLine(Message.exit);
            }
        } while (pressKey.Key != ConsoleKey.Escape);
        Console.Clear();
    }
}