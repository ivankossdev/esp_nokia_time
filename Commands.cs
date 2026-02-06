namespace esp_nokia_time;

public static class Commands{
    static MyDateTime tm = new();
    private static string GetCmdDay(string weekDay){

        string day = string.Empty; 
        switch (weekDay){
            case "Monday": day = "set13"; break; 
            case "Tuesday": day = "set23"; break;
            case "Wednesday": day = "set33"; break;
            case "Thursday": day = "set43"; break;
            case "Friday": day = "set53"; break;
            case "Saturday": day = "set63"; break;
            case "Sunday": day = "set73"; break;
        }
        return day;
    }

    public static MyDateTime GetSystemDateTime(){
         
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

    public static string GetSystemTime(){
        return $"set{tm.time.Replace(":", "")}1"; 
    }

    public static string GetSystemDate()
    {
        return $"set{tm.year[2..]}{tm.month}{tm.date}2"; 
    }
}