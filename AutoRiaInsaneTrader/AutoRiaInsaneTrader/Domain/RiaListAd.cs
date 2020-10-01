using System;

namespace AutoRiaInsaneTrader.Domain
{
    internal class RiaListAd
    {
        public string Url { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public int Price { get; set; }

        public int Odo { get; set; }

        public int Engine { get; set; }

        public string Transmission { get; set; }

        public string Number { get; set; }

        public string Vin { get; set; }

        public string City { get; set; }

        public DateTime Parsed { get; set; }
    }
}
