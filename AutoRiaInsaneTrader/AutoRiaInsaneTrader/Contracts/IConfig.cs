namespace AutoRiaInsaneTrader.Contracts
{
    interface IConfig
    {
        public string ConnectionString { get; }

        public string RuCaptchaApiKey { get; }
    }
}
