using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MOS.Domain.Helpers
{
    public static class ConfigManager
    {
        public readonly static IConfigurationRoot ConfigRoot;
        static ConfigManager()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"));
            ConfigRoot = builder.Build();
        }
    }
}
