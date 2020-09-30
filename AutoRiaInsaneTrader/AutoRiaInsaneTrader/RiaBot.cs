using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoRiaInsaneTrader.Contracts;

namespace AutoRiaInsaneTrader
{
    internal class RiaBot : IRiaBot
    {
        private const string autoRiaUrl = "https://auto.ria.com/";

        private readonly IConfig config;

        public RiaBot(IConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task Run()
        {
            try
            {
                await Auth().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bot error: {ex.Message}");
                throw;
            }
        }

        private async Task Auth()
        {
            using var http = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, autoRiaUrl);
            using var response = await http.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                foreach (var item in response.Headers)
                {
                    Console.WriteLine($"{item.Key} : {string.Join(" ", item.Value)}");
                }

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Console.WriteLine(content.Length);
            }
        }
    }
}