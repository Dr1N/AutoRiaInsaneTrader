using System;
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
        private readonly IRiaParser parser;
        private readonly ICookieBuilder cookieBuilder;

        public RiaBot(IConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.parser = new RiaParser(); // TODO: inject
            this.cookieBuilder = new RiaCookieBuilder(config); // TODO: inject
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
            request.Headers.Add("Cookie", cookieBuilder.AuthCookie());

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
            var title = document.QuerySelector("h1.bold");

            return title != null;
        }
    }
}