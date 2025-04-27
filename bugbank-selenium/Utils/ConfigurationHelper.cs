using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bugbank_selenium.Utils
{
        public static class ConfigurationHelper
        {
            private static readonly IConfigurationRoot Configuration;

            static ConfigurationHelper()
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory) // Define o diretório base
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Carrega o arquivo
                    .Build();
            }

            public static string GetAppUrl()
            {
                return Configuration["AppUrl"]; 
            }
        }

    }
