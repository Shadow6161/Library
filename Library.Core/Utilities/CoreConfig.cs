using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Utilities
{
    public static class CoreConfig
    {
        public static  IConfigurationBuilder? _configurationbuilder;
        public static IConfiguration? _configuration;

        public static IConfiguration GetConfiguration() {

            _configurationbuilder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json");
            _configuration = _configurationbuilder.Build();

            return _configuration;
        }

        public static string GetValue(string key) => GetConfiguration().GetValue<string>(key);
        public static string GetConnectionString(string connection) => GetConfiguration().GetConnectionString(connection);
    }
}
