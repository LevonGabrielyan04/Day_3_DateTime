using System;
using System.Data.SqlTypes;

static class Tasks
{
    public static string ReplaceWithDate(string arg)//Task 1
    {
        return arg.Replace("@expDate@", DateTime.Now.AddMonths(1).ToString());
    }
    public static string LastMilisecond(string arg)//Task 2
    {
        return arg.Replace("@expDate@", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddMilliseconds(-1).ToString("yyyy-MM-dd HH:mm:ss.fff"));
    }
    public static int CalaculateDays(DateTime dateTime1, DateTime dateTime2)//Task 3
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(Math.Abs(((DateTimeOffset)dateTime1).ToUnixTimeSeconds() - ((DateTimeOffset)dateTime2).ToUnixTimeSeconds()));
        return timeSpan.Days;
    }
    public static string GetWeekday(this DateTime date, int lang)//Task 4
    {
       string[] daysOfWeek = new string[]{ "Monday", "Tuersday",
      "Wednesday", "Thirsday", "Friday", "Saturday","Sunday" };
        switch (lang)
        {
            case 0:
                return date.DayOfWeek.ToString();
            case 1:
                string[] daysOfWeekRus = new string[]{ "понедельник", "вторник", "среда",
      "четверг", "пятница", "суббота", "воскресенье" };
                return daysOfWeekRus[Array.IndexOf(daysOfWeek, date.DayOfWeek.ToString())];
            case 2:
                string[] daysOfWeekArm = new string[]{ "Erkushabti", "Ereqshabti",
      "Choreqshabti", "Hingshabti", "Urbat", "Shabat","Kiraki" };
                return daysOfWeekArm[Array.IndexOf(daysOfWeek, date.DayOfWeek.ToString())];
            default:
                throw new Exception("Language should be 0,1 or 2");
        }
    }

}

class ussd //Task 5
{
    //*208*2000*1#
    int Code;
    int[] Actions = new int[2];
    public ussd(string s)
    {
        string[] split = s.Split('*');
        Code = int.Parse(split[1]);
        Actions[0] = int.Parse(split[2]);
        Actions[1] = int.Parse(split[3].Remove(split[3].Length - 1));
        Console.WriteLine(Code +" " + Actions[0] + " " + Actions[1]);
    }
}

class Program
{
    static void Main()
    {
        //Task 1
        //Console.WriteLine(Tasks.ReplaceWithDate("Dzer sakagnayin planum nerarvats patetnery veraaktivacel en yev gortsum en minchev @expDate@. Patetneri mnacordy stugelu hamar ugharkeq *208#."));

        //Task 2
        //Console.WriteLine(Tasks.LastMilisecond("\"Dzer sakagnayin planum nerarvats patetnery veraaktivacel en yev gortsum en minchev @expDate@. Patetneri mnacordy stugelu hamar ugharkeq *209#.\""));

        //Task3
        //Console.WriteLine(Tasks.CalaculateDays(DateTime.Now,DateTime.Now.AddYears(1)));

        //Task 4
        //Console.WriteLine(Tasks.GetWeekday(DateTime.Now,2));

        //Task 5
        //ussd ussd = new ussd("*208*2000*1#");
    }
}