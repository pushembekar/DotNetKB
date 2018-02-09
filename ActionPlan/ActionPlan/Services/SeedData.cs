using ActionPlan.Data;
using ActionPlan.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionPlan.Services
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider services)
        {
            var env = services.GetRequiredService<IHostingEnvironment>();

            if (env.IsProduction())
                return;

            using (var context = new POAMDbContext(services.GetRequiredService<DbContextOptions<POAMDbContext>>()))
            {
                var authSystems = new List<AuthSystem>();
                if (!context.AuthSystems.Any())
                {
                    authSystems.Add(new AuthSystem { Name = @"REGIS" });
                    authSystems.Add(new AuthSystem { Name = @"REDMACS" });
                    context.AuthSystems.AddRange(authSystems);
                    context.SaveChanges();
                }

                var riskLevels = new List<RiskLevel>();
                if(!context.RiskLevels.Any())
                {
                    riskLevels.Add(new RiskLevel { ID = 1, Name = "VL", Description = "Very Low" });
                    riskLevels.Add(new RiskLevel { ID = 2, Name = "L", Description = "Low" });
                    riskLevels.Add(new RiskLevel { ID = 3, Name = "M", Description = "Medium" });
                    riskLevels.Add(new RiskLevel { ID = 4, Name = "H", Description = "High" });
                    riskLevels.Add(new RiskLevel { ID = 5, Name = "VH", Description = "Very High" });
                    context.RiskLevels.AddRange(riskLevels);
                    context.SaveChanges();
                }

                var statuses = new List<Status>();
                if(!context.Statuses.Any())
                {
                    statuses.Add(new Status { ID = 1, Name = "Planned/Pending" });
                    statuses.Add(new Status { ID = 2, Name = "Canceled" });
                    statuses.Add(new Status { ID = 3, Name = "Completed" });
                    statuses.Add(new Status { ID = 4, Name = "In Progress" });
                    statuses.Add(new Status { ID = 5, Name = "Delayed" });
                    statuses.Add(new Status { ID = 6, Name = "Existing Risk Acceptance" });
                    statuses.Add(new Status { ID = 7, Name = "Risk Accpetance" });
                    context.Statuses.AddRange(statuses);
                    context.SaveChanges();
                }

                if (!context.POAMs.Any())
                {
                    var poam = new POAM
                    {
                        AuthSystem = authSystems.SingleOrDefault(item => item.Name == "REGIS"),
                        CreateDate = DateTime.Now,
                        CSAMPOAMID = "55475",
                        DelayReason = new DelayReason { Name = "Unknown" },
                        Number = 1,
                        Recommendation = @"Lorem Ipsum doler set umet",
                        RiskLevel = riskLevels.SingleOrDefault(item => item.Name == "H"),
                        Status = statuses.SingleOrDefault(item => item.Name == "Delayed"),
                        Weakness = new Weakness { OriginalRecommendation = "Do it" }
                    };
                    context.POAMs.Add(poam);
                    context.SaveChanges();
                }
            }
        }
    }
}
