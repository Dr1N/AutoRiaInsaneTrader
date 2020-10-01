using System;
using System.Diagnostics.CodeAnalysis;

namespace AutoRiaInsaneTrader.Domain
{
    internal class RiaMessage : IEquatable<RiaMessage>
    {
        public string Url { get; set; }

        public string Message { get; set; }

        public DateTime Sended { get; set; }

        public bool Equals([AllowNull] RiaMessage other)
        {
            throw new NotImplementedException();
        }
    }
}
