namespace esp_nokia_time;

public static class Commands{
    static MyDateTime tm = new();
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

    public static MyDateTime GetDateTime(){
         
        string dateTime = DateTime.Now.ToString("s");

        string[] data = dateTime.Split('T');
        tm.time = data[1];
        tm.fullDate = data[0];
        
        string[] fullDate = tm.fullDate.Split('-');  
        tm.date = fullDate[2];
        tm.month = fullDate[1];
        tm.year = fullDate[0];
        return tm;
    }

    public static string SetTime(){
        return $"settm{tm.time.Replace(":", "")}"; 
    }

    public static string SetDay(){
        DateOnly now = DateOnly.Parse(tm.fullDate);
        return GetCmdDay(now.DayOfWeek.ToString());
    }

    public static string SetDate(){
        return $"setdt{tm.date}"; 
    }

    public static string SetMonth(){
        return $"setmn{tm.month}";
    }

    public static string SetYear(){
        return $"setyr{tm.year[2..]}";
    }
}