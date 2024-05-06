namespace App.Domain.Core._2_Configs
{
    public class SiteSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public SqlConfigurations SqlConfigurations { get; set; }
        public SeqConfigurations SeqConfigurations { get; set; }
    }


    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class SqlConfigurations
    {
        public string ConnectionString { get; set; }
    }

    public class SeqConfigurations
    {
        public string UrlAddress { get; set; }
        public string ApiToken { get; set; }
        public string MinimumLevel { get; set; }
    }

}
