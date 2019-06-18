using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreSqlDb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Text;

/*
using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.StaticFiles;
using System.Threading;

*/
namespace DotNetCoreSqlDb {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            // Add framework services.
            services.AddMvc ();

     /*To ogólnie lepsze, bo nie ma co przy testowaniu bawić się "prawdziwą bazą danych, ale przy moich tesatch jednak się pobawimy */
            // if (Environment.GetEnvironmentVariable ("ASPNETCORE_ENVIRONMENT") == "Production")
            //     services.AddDbContext<MyDatabaseContext> (options =>
            //         options.UseSqlServer (Configuration.GetConnectionString ("MyDbConnection")));
            // else
            //     services.AddDbContext<MyDatabaseContext> (options =>
            //         options.UseSqlite ("Data Source=localdatabase.db"));
services.AddDbContext<MyDatabaseContext> (options =>
                    options.UseSqlServer (Configuration.GetConnectionString ("MyDbConnection")));
            // Automatically perform database migration
            services.BuildServiceProvider ().GetService<MyDatabaseContext> ().Database.Migrate ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) 
        {
            loggerFactory.AddConsole (Configuration.GetSection ("Logging"));
            loggerFactory.AddDebug ();
            loggerFactory.AddAzureWebAppDiagnostics ();

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseBrowserLink ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }
			 
            app.UseFileServer();
            app.UseStaticFiles ();
            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Klient}/{action=Index}/{id?}");
            });
        }
    }
}