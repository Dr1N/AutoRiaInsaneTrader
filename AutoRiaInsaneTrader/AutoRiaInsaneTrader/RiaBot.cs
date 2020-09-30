using System;
using AutoRiaInsaneTrader.Contracts;

namespace AutoRiaInsaneTrader
{
    internal class RiaBot : IRiaBot
    {
        private readonly RiaConfig riaConfig;

        public RiaBot(RiaConfig riaConfig)
        {
            this.riaConfig = riaConfig ?? throw new ArgumentNullException(nameof(riaConfig));
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}