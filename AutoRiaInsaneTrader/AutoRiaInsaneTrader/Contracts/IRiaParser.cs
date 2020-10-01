using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRiaInsaneTrader.Domain;

namespace AutoRiaInsaneTrader.Contracts
{
    internal interface IRiaParser
    {
        Task<IEnumerable<RiaListAd>> GetAdsAsync();
    }
}
