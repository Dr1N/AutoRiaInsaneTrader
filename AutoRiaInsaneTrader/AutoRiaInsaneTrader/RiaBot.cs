using System;
using AutoRiaInsaneTrader.Contracts;

namespace AutoRiaInsaneTrader
{
    internal class RiaBot : IRiaBot
    {
        private readonly IConfig config;

        public RiaBot(IConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}