using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Devart.Data;using Devart.Data.Oracle;using Devart.Data.Oracle.Entity;


namespace WebAppRESTAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OracleMonitor myMonitor = new OracleMonitor();
            myMonitor.IsActive = true;
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
