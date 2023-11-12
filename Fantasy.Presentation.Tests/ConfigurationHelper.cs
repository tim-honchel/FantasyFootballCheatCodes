﻿using Microsoft.Extensions.Configuration;

namespace Fantasy.Presentation.Tests
{
    public class ConfigurationHelper
    {
        private const string AppSetting = "appsettings.json";
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder().AddJsonFile(AppSetting).Build();
        }
    }
}
