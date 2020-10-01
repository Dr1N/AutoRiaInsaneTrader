using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AutoRiaInsaneTrader.Contracts;

namespace AutoRiaInsaneTrader
{
    internal class RiaBot : IRiaBot
    {
        private const string autoRiaUrl = "https://auto.ria.com/";
        private const string autoRiaCabinet = "https://auto.ria.com/cabinet/";

        private readonly IConfig config;

        public RiaBot(IConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task Run()
        {
            try
            {
                await AuthAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bot error: {ex.Message}");
            }
        }

        private async Task AuthAsync()
        {
            using var http = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, autoRiaCabinet);
            request.Headers.Add("Cookie", Cookie());

            using var response = await http.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                foreach (var item in response.Headers)
                {
                    Console.WriteLine($"{item.Key} : {string.Join(" ", item.Value)}");
                }

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var isAuth = await IsAuthAsync(content).ConfigureAwait(false);

                Console.WriteLine($"AUTH: {isAuth}");
            }
        }

        private async Task<bool> IsAuthAsync(string html)
        {
            var browsingContext = BrowsingContext.New(Configuration.Default);
            var document = await browsingContext.OpenAsync(req => req.Content(html)).ConfigureAwait(false);
            const string selector = "h1.bold";
            var title = document.QuerySelector(selector);

            return title != null;
        }

        private string Cookie()
        {
            var list = new List<string>
            {
                $"PSP_ID={config.PspId}",
                $"PHPLOGINSESSID={config.PhpLoginSessId}",
                $"PHPSESSID={config.PhpLoginSessId}",
                $"jwt={config.Jwt}"
            };

            return string.Join("; ", list);
        }
    }
}