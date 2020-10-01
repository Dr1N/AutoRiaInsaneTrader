using AutoRiaInsaneTrader.Contracts;
using Microsoft.Extensions.Configuration;

namespace AutoRiaInsaneTrader
{
    internal class RiaConfig : IConfig
    {
        public RiaConfig(IConfigurationRoot config)
        {
            PspId = config.GetValue<string>("PSP_ID");
            Jwt = config.GetValue<string>("jwt");
            PhpLoginSessId = config.GetValue<string>("PHPLOGINSESSID");
            PhpSessId = config.GetValue<string>("PHPSESSID");
        }

        public string ConnectionString { get; }

        public string RuCaptchaApiKey { get; }

        public string PspId { get; }

        public string Jwt { get; }

        public string PhpLoginSessId { get; }

        public string PhpSessId { get; }
    }
}
