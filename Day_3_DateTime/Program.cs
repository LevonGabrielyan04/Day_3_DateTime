class Tasks
{
    public static string ReplaceWithDate(string arg)//Task 1
    {
        return arg.Replace("@expDate@",DateTime.Now.AddMonths(1).ToString());
    }
    public static string LastMilisecond(string arg)//Task 2
    {
        return arg.Replace("@expDate@",new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddMilliseconds(-1).ToString("yyyy-MM-dd HH:mm:ss.fff"));
    }

}


class Program
{
    static void Main()
    {

    }
}