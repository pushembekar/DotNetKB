using System;
using ActionPlan.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ActionPlan
{
    /// <summary>
    /// Main entry point function for the application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The actual "Main" function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Building default host
            var host = BuildWebHost(args);

            // Creating the scope to seed the database
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, @"An error occurred seeding the DB");
                }
            }

            host.Run();
        }

        /// <summary>
        /// The default web server host build
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
