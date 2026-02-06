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
        return $"set{tm.time.Replace(":", "")}1"; 
    }
}