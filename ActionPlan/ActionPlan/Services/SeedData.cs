using ActionPlan.Data;
using ActionPlan.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionPlan.Services
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider services, IHostingEnvironment env)
        {
            if (env.IsProduction())
                return;

            var context = services.GetRequiredService<POAMDbContext>();

            if (!context.AuthSystems.Any())
            {
                context.AuthSystems.AddRange(
                    new AuthSystem
                    {
                        Name = @"REGIS"
                    },
                    new AuthSystem
                    {
                        Name = @"REDMACS"
                    });
            }

            if (!context.POAMs.Any())
            {
                var poam = new POAM
                {
                    AuthSystem = new AuthSystem { Name = "REGIS" },
                    CreateDate = DateTime.Now,
                    DelayReason = new DelayReason { Name = "Unknown" },
                    Recommendation = @"Lorem Ipsum doler set umet",
                    RiskLevel = new RiskLevel { Name = "VH" },
                    Status = new Status { Name = "Planned/Pending" },
                    Weakness = new Weakness { OriginalRecommendation = "Do it" }
                };
            }
            context.SaveChanges();

        }
    }
}
