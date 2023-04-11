using System.CommandLine;

class Program
{
    public static int Main(string[] args)
    {
        var cityOption = new Option<string>(
            name: "--in",
            description: "The city name");
        
        var rootCommand = new RootCommand("A sample timezone app for snap packages.");
        rootCommand.Add(cityOption);

        rootCommand.SetHandler((cityName) =>
        {
            try
            {
                var time = QueryTimeInCity(cityName?.Replace(" ", "_"));
                Console.WriteLine($"The current time in {cityName} is {time}");
            }
            catch (ApplicationException ex)
            {
                Console.Error.WriteLine($"ERROR: {ex.Message}");
            }
            
        }, cityOption);

        return rootCommand.Invoke(args);
    }

    private static DateTime QueryTimeInCity(string? cityName)
    {
        if (string.IsNullOrEmpty(cityName))
        {
            throw new ApplicationException("Please, insert a city name. Use --help when in doubt.");
        }

        var timezone = TimeZoneInfo.GetSystemTimeZones()
            .FirstOrDefault(t => t.Id.Contains(cityName, StringComparison.InvariantCultureIgnoreCase));

        if (timezone is null)
        {
            throw new ApplicationException("City not found.");
        }

        var time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezone);

        return time;
    }
}