using AutoRiaInsaneTrader.Contracts;
using Microsoft.Extensions.Configuration;

namespace AutoRiaInsaneTrader
{
    internal class RiaConfig : IConfig
    {
        public RiaConfig(IConfigurationRoot config)
        {
            // TODO: set params
        }

        public string ConnectionString { get; private set; }

        public string RuCaptchaApiKey { get; private set; }
    }
}
