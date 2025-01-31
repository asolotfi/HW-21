using Microsoft.Extensions.Configuration;

namespace HW_20.Infrastructure.Configuration
{
    public class Configuration
    {
        public static string ConfigurationString { get; set; }

        public Configuration(IConfiguration configuration)
        {
            ConfigurationString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}

