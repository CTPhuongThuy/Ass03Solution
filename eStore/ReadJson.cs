using DataAccess.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace eStore
{
    public static class ReadJson
    {
        public static IConfiguration Configuration;

        public static Member GetAdmin()
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
            var adminDefault = config.GetSection("AdminAccount").Get<Member>();
            return adminDefault;
        }

    }
}
