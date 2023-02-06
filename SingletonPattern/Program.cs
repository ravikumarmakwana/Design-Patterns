public class Program
{
    public static void Main(string[] args)
    {
        var employeeLogger = Logger.GetInstance;
        employeeLogger.LogMessage("Employee Logger");

        var adminLogger = Logger.GetInstance;
        adminLogger.LogMessage("Admin Logger");

        ////var subL1 = new Logger.SubLogger();
        ////var subL2 = new Logger.SubLogger();

        var employeeCaching = CachingService.GetInstace;
        employeeCaching.Cache("Employee Caching");

        var adminCaching = CachingService.GetInstace;
        adminCaching.Cache("Admin Caching");
    }
}

public sealed class Logger
{
    // Eager Loading
    private static readonly Logger _instance = new Logger();
    private static int _count;

    public static Logger GetInstance
    {
        get { return _instance; }
    }

    private Logger()
    {
        Console.WriteLine($"{++_count} instance created!");
    }

    public void LogMessage(string message)
    {
        Console.WriteLine(message);
    }

    // Due to following code class must be sealed
    //public class SubLogger : Logger
    //{
    //    public void SubLog()
    //    {
    //        Console.WriteLine("Sub Logger");
    //    }
    //}
}

public sealed class CachingService
{
    private static CachingService _instace;
    private static int _count;
    private static Object obj = new object();

    private CachingService()
    {
        Console.WriteLine($"{++_count} instance created!");
    }

    public static CachingService GetInstace
    {
        get
        {
            // Thread Safety
            // Lazy loading
            if (_instace == null)
            {
                lock (obj)
                {
                    if (_instace == null)
                    {
                        _instace = new CachingService();
                    }
                }
            }
            return _instace;
        }
    }

    public void Cache(string message)
    {
        Console.WriteLine(message);
    }
}