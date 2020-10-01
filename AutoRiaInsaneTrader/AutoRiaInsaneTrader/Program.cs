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

                _ = new RiaBot(new RiaConfig(configuration)).Run();

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
