using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRiaInsaneTrader.Contracts;
using AutoRiaInsaneTrader.Domain;

namespace AutoRiaInsaneTrader
{
    internal class RiaParser : IRiaParser
    {
        public Task<IEnumerable<RiaListAd>> GetAdsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
