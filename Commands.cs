namespace esp_nokia_time;

public class Commands{
    private MyTime mt = GetDateTime();
    private static string GetCmdDay(string weekDay){

        string day = string.Empty; 
        switch (weekDay){
            case "Monday": day = "setdy1"; break; 
            case "Tuesday": day = "setdy2"; break;
            case "Wednesday": day = "setdy3"; break;
            case "Thursday": day = "setdy4"; break;
            case "Friday": day = "setdy5"; break;
            case "Saturday": day = "setdy6"; break;
            case "Sunday": day = "setdy7"; break;
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
    public string SetDate(){
        return $"date {mt.date}";
    }
    public string SetTime(){
        return $"settm{mt.time.Replace(":", "")}"; 
    }

    public string SetDay(){
        DateOnly now = DateOnly.Parse(mt.date);
        return GetCmdDay(now.DayOfWeek.ToString());
    }
}