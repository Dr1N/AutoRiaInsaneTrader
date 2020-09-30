using Microsoft.Extensions.Configuration;

namespace AutoRiaInsaneTrader
{
    internal class RiaConfig
    {
        public RiaConfig(IConfigurationRoot config)
        {
            // TODO: set params
        }

        public string RuCaptchaApiKey { get; set; }
    }
}
