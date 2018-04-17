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

            

            using (var context = new POAMDbContext(services.GetRequiredService<DbContextOptions<POAMDbContext>>()))
            {
                var authSystems = new List<AuthSystem>();
                if (!context.AuthSystems.Any())
                {
                    authSystems.Add(new AuthSystem { Name = @"REGIS" });
                    authSystems.Add(new AuthSystem { Name = @"REDMACS" });
                    authSystems.Add(new AuthSystem { Name = @"Terremark" });
                    context.AuthSystems.AddRange(authSystems);
                    context.SaveChanges();
                }

                var riskLevels = new List<RiskLevel>();
                if (!context.RiskLevels.Any())
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
                if (!context.Statuses.Any())
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

                var delayReasons = new List<DelayReason>();
                if (!context.DelayReasons.Any())
                {
                    delayReasons.Add(new DelayReason { ID = 1, Name = "Weakness/Priority changed" });
                    delayReasons.Add(new DelayReason { ID = 2, Name = "Original completetion time underestimated" });
                    delayReasons.Add(new DelayReason { ID = 3, Name = "Funds not allocated/Insufficient funding" });
                    delayReasons.Add(new DelayReason { ID = 4, Name = "Assigned funds withdrawn" });
                    delayReasons.Add(new DelayReason { ID = 5, Name = "Dependency on other task(s)" });
                    delayReasons.Add(new DelayReason { ID = 6, Name = "Contractor delay" });
                    delayReasons.Add(new DelayReason { ID = 7, Name = "Procurement delay" });
                    delayReasons.Add(new DelayReason { ID = 8, Name = "Personnel shortage" });
                    delayReasons.Add(new DelayReason { ID = 9, Name = "Technology delay/dependency" });
                    delayReasons.Add(new DelayReason { ID = 10, Name = "Policy delay/dependency" });
                    delayReasons.Add(new DelayReason { ID = 11, Name = "Moratorium on development" });
                    delayReasons.Add(new DelayReason { ID = 12, Name = "Other" });
                    delayReasons.Add(new DelayReason { ID = 13, Name = "Not Applicable" });
                    context.DelayReasons.AddRange(delayReasons);
                    context.SaveChanges();
                }

                var responsiblepocs = new List<ResponsiblePOC>();
                if (!context.ResponsiblePOCs.Any())
                {
                    responsiblepocs.Add(new ResponsiblePOC { ID = new Guid(), Name = "Lai Lee-Birman", Description = "System Owner" });
                    responsiblepocs.Add(new ResponsiblePOC { ID = new Guid(), Name = "SOC", Description = "Security Office" });
                    responsiblepocs.Add(new ResponsiblePOC { ID = new Guid(), Name = "Jeremy Holmes", Description = "Information Steward" });
                    context.ResponsiblePOCs.AddRange(responsiblepocs);
                    context.SaveChanges();
                }

                if (env.IsProduction())
                    return;

                if (!context.POAMs.Any())
                {
                    var weakness = new Weakness();
                    if (!context.Weaknesses.Any())
                    {
                        //weakness.ID = 1;
                        weakness.OriginalRecommendation = @"REGIS is not currently PIV-enabled.";
                        weakness.Risk = @"Risk: Lack of PIV implementation leaves the system more 
                                vulnerable to unauthorized access, making financial data that is transmitted through 
                                REGIS more vulnerable to unauthorized disclosure and modification.";
                    }

                    string recommendation = @"The Assessment Team recommends raising the Risk Level of this POAM from 
                                            Moderate to High as the scheduled completion date for PIV compliance was September 30, 2015.
                                            The Assessment Team recommends removing IA-7 from this POAM, as REGIS does not have any 
                                            cryptographic modules within its authorization boundary.The System Owner and developers 
                                            have determined that MyAccess is not an option for PIV implementation; the team is 
                                            researching the use of Integrated Windows Authentication (IWA) for PIV-enabled access.
                                            This POAM is delayed due to the System Owner working with the developers to determine 
                                            if IWA is a suitable option to implement PIV authentication; it was determined 
                                            that MyAccess was not a viable solution.";

                    var poam = new POAM
                    {
                        ActualFinishDate = null,
                        ActualStartDate = null,
                        AuthSystem = authSystems.SingleOrDefault(item => item.Name == "REGIS"),
                        ControlID = @"IA-2(1), IA-2(2), IA-2(8), IA-2(12), IA-5(2), IA-5(11), IA-7",
                        CostJustification = @"Minimum Organizational Cost",
                        CreateDate = DateTime.Now,
                        CSAMPOAMID = "55475",
                        DelayReason = delayReasons.FirstOrDefault(item => item.Name.StartsWith("Technology", StringComparison.OrdinalIgnoreCase)),
                        Number = 1,
                        PlannedFinishDate = new DateTime(2018, 5, 1),
                        PlannedStartDate = new DateTime(2017, 5, 1),
                        Recommendation = recommendation,
                        ResourcesRequired = 100.0M,
                        ResponsiblePOCs = responsiblepocs.Where(item => item.Name == "Lai Lee-Birman" || item.Name == "SOC").ToList(),
                        RiskLevel = riskLevels.SingleOrDefault(item => item.Name == "H"),
                        ScheduledCompletionDate = new DateTime(2016, 9, 1),
                        Status = statuses.SingleOrDefault(item => item.Name == "Delayed"),
                        Weakness = weakness
                    };
                    context.POAMs.Add(poam);

                    weakness = new Weakness();
                    if (!context.Weaknesses.Any())
                    {
                        //weakness.ID = 2;
                        weakness.OriginalRecommendation = @"RA-2: During the assessment, REGIS information system data types were not validated by the Information Steward.
                                                            PL-2:  The System Characterization was unable to be properly updated with the most accurate system data types. ";
                        weakness.Risk = @"Risk: The risk of not properly categorizing the system makes it difficult to understand the scope of REGIS 
                                            and what the effect might be on the overall security posture of the system which may lead to improper security settings and management.  ";
                    }

                    recommendation = @"The Assessment Team recommends that the REGIS Information Steward provide additional information on the types of data that are stored 
                                        and transmitted by the system, in order to correctly verify the Security Categorization. Data types should be mapped to Information 
                                        Types in accordance with SP 800-60, Volume II, to verify the accuracy of the current FIPS 199 and overall FIPS 200 level of Moderate.
                                        The System Characterization should be reviewed and updated as necessary to document all changes that have been made to the system.
                                        This POAM is delayed because the REGIS Information Steward did not verify that the list of data types listed in the SCD are comprehensive, 
                                        to include all data types that REGIS stores, transmits and processes. ";

                    poam = new POAM
                    {
                        ActualFinishDate = null,
                        ActualStartDate = new DateTime(2016, 9, 1),
                        AuthSystem = authSystems.SingleOrDefault(item => item.Name == "REGIS"),
                        ControlID = @"PL-2, RA-2",
                        CostJustification = @"Minimum Organizational Cost",
                        CreateDate = DateTime.Now,
                        CSAMPOAMID = "60028",
                        DelayReason = delayReasons.FirstOrDefault(item => item.Name.StartsWith("Other", StringComparison.OrdinalIgnoreCase)),
                        Number = 2,
                        PlannedFinishDate = new DateTime(2018, 5, 1),
                        PlannedStartDate = new DateTime(2017, 5, 1),
                        Recommendation = recommendation,
                        ResourcesRequired = 100.0M,
                        ResponsiblePOCs = responsiblepocs.Where(item => item.Name.Contains("Jeremy")).ToList(),
                        RiskLevel = riskLevels.SingleOrDefault(item => item.Name == "H"),
                        ScheduledCompletionDate = new DateTime(2016, 9, 1),
                        Status = statuses.SingleOrDefault(item => item.Name == "Delayed"),
                        Weakness = weakness
                    };
                    context.POAMs.Add(poam);
                    context.SaveChanges();
                }
            }
        }
    }
}
