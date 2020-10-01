namespace AutoRiaInsaneTrader.Contracts
{
    internal interface IConfig
    {
        public string ConnectionString { get; }

        public string RuCaptchaApiKey { get; }

        public string PspId { get; }

        public string Jwt { get; }

        public string PhpLoginSessId { get; }

        public string PhpSessId { get; }
    }
}
