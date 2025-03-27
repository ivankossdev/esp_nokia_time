namespace esp_nokia_time;

public enum WeekDay{
    Monday = 1, 
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5, 
    Saturday = 6,
    Sunday = 7
}

public class DS3231{
    public static string SetDay(WeekDay weekDay){

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
}