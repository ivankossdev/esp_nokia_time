namespace esp_nokia_time;

/// <summary>
/// Класс для формирования команд управления часами
/// </summary>
public static class Commands{
    static MyDateTime tm = new();

    /// <summary>
    /// Преобразует день недели в команду
    /// для настройки дня недели в часах
    /// </summary>
    /// <param name="weekDay"></param>
    /// <returns></returns>
    private static string SetCmdDay(string weekDay){

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

    /// <summary>
    /// Получает системое время, год, месяц 
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Преобразует системное время в команду 
    /// для установки времени в часах
    /// </summary>
    /// <returns></returns>
    public static string GetSystemTime(){
        return $"set{tm.time.Replace(":", "")}1"; 
    }

    /// <summary>
    /// Преобразует год, месяц, число в команду для
    /// установки даты в часах
    /// </summary>
    /// <returns></returns>
    public static string GetSystemDate()
    {
        return $"set{tm.year[2..]}{tm.month}{tm.date}2"; 
    }
}