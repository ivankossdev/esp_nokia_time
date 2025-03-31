namespace esp_nokia_time;

public class Commands{
    private MyDateTime mdt;
    public Commands(){
        mdt = GetDateTime();
    }
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

    private static MyDateTime GetDateTime(){
        MyDateTime tm = new(); 
        string data = DateTime.Now.ToString("s");
        tm.time = data.Split('T')[1];
        tm.fullDate = data.Split('T')[0];
        
        string[] fullDate = tm.fullDate.Split('-');  
        tm.date = fullDate[2];
        tm.month = fullDate[1];
        return tm;
    }

    public string SetTime(){
        return $"settm{mdt.time.Replace(":", "")}"; 
    }

    public string SetDay(){
        DateOnly now = DateOnly.Parse(mdt.fullDate);
        return GetCmdDay(now.DayOfWeek.ToString());
    }

    public string SetDate(){
        return $"setdt{mdt.date}"; 
    }

    public string SetMonth(){
        return $"setmn{mdt.month}";
    }
}