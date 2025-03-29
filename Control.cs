namespace esp_nokia_time;

public class Control{
    private readonly string comPort;
    private MyTime mt = GetDateTime();
    private static string GetCmdDay(WeekDay weekDay){

        string day = string.Empty; 
        switch (weekDay){
            case WeekDay.Monday: day = "setdy1"; break; 
            case WeekDay.Tuesday: day = "setdy2"; break;
            case WeekDay.Wednesday: day = "setdy3"; break;
            case WeekDay.Thursday: day = "setdy4"; break;
            case WeekDay.Friday: day = "setdy5"; break;
            case WeekDay.Saturday: day = "setdy6"; break;
            case WeekDay.Sunday: day = "setdy7"; break;
        }
        return day;
    }
    private static MyTime GetDateTime(){
        MyTime tm = new();
        string data = DateTime.Now.ToString("s");
        tm.time = data.Split('T')[1];
        tm.date = data.Split('T')[0];
        return tm;
    }
    public Control(string comPort_){
        this.comPort = comPort_;
        ComPort.Init(comPort);
        Console.WriteLine("Init port /dev/ttyUSB0");
    }
    public void SetDate(){
        Console.WriteLine($"date {mt.date}");
    }
    public void SetTime(){
        Console.WriteLine($"date {mt.time}");
    }

    public void SetDay(WeekDay weekDay){
        Console.WriteLine($"Day {GetCmdDay(weekDay)}");
    }
}