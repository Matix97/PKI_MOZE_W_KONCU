using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DotNetCoreSqlDb {
    public class Program {
        // public static void Main(string[] args)
        // {
        //     BuildWebHost(args).Run();
        //    //  CreateWebHostBuilder(args).Build().Run();
        // }

        // public static IWebHost BuildWebHost(string[] args) =>
        //     WebHost.CreateDefaultBuilder(args)
        //         .UseStartup<Startup>()
        //         .Build();
        public static void Main (string[] args)

        {

            var host = new WebHostBuilder ()
                .UseKestrel ()
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .UseIISIntegration ()
                .UseStartup<Startup> ()
                .Build ();

            host.Run ();

        }
    }
}