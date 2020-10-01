using System;
using System.Collections.Generic;
using AutoRiaInsaneTrader.Contracts;

namespace AutoRiaInsaneTrader
{
    internal class RiaCookieBuilder : ICookieBuilder
    {
        private const string PSP_ID = "PSP_ID";
        private const string PHPLOGINSESSID = "PHPLOGINSESSID";
        private const string PHPSESSID = "PHPSESSID";
        private const string JWT = "jwt";

        private readonly IConfig config;

        public RiaCookieBuilder(IConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public string AuthCookie()
        {
            var cookies = new List<string>
            {
                $"{PSP_ID}={config.PspId}",
                $"{PHPLOGINSESSID}={config.PhpLoginSessId}",
                $"{PHPSESSID}={config.PhpLoginSessId}",
                $"{JWT}={config.Jwt}"
            };

            return string.Join("; ", cookies);
        }
    }
}
