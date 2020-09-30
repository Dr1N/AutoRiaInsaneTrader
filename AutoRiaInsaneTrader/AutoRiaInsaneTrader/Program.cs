using System;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AutoRiaInsaneTrader
{
    internal static class Program
    {
        private const string configurationFile = "appsettings.json";

        private static void Main()
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;

                var configuration = new ConfigurationBuilder()
                    .AddJsonFile(configurationFile, true, true)
                    .Build();

                var config = new RiaConfig(configuration);

                var bot = new RiaBot(config);

                bot.Run();

                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Critical Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
