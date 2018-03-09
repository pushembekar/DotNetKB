using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionPlan.Data;
using ActionPlan.Entities;
using ActionPlan.Models.PlanOfActionViewModels;
using Microsoft.EntityFrameworkCore;

namespace ActionPlan.Services
{
    /// <summary>
    /// Entity service... implements the IEntity interface
    /// </summary>
    public class EntityService : IEntityService
    {
        // private variable to hold the db context
        private readonly POAMDbContext _context;
        // private variable to hold the excel service
        private readonly IExcelService _excelService;

        /// <summary>
        /// Service constructor. Takes the POAMDbContext as dependency
        /// </summary>
        /// <param name="context"></param>
        public EntityService(POAMDbContext context, IExcelService excelService)
        {
            _context = context;
            _excelService = excelService;
        }

        /// <summary>
        /// Returns a fully filled POAM entity object
        /// </summary>
        /// <param name="viewmodel">View model object</param>
        /// <returns>POAM object</returns>
        public async Task<POAM> CreatePOAMFromViewModel(POAMViewModel viewmodel)
        {
            try
            {
                var poam = new POAM();
                // Create the AuthSystem object
                var authsystem = CrateAuthSystem(viewmodel.AuthSystem);
                var risklevel = CreateRiskLevel(viewmodel.RiskLevel);
                var status = CreateStatus(viewmodel.Status);
                var delayreason = CreateDelayReason(viewmodel.DelayReason);
                var weakness = CrateWeakness(viewmodel.OriginalRecommendation, viewmodel.Risk);
                var pocs = CreateResponsiblePOCs(viewmodel.ResponsiblePOCs);
                // assign some fields synchronously
                poam.Number = viewmodel.Number;
                poam.CSAMPOAMID = viewmodel.CSAMPOAMID;
                poam.ControlID = viewmodel.ControlID;
                poam.Recommendation = viewmodel.Recommendation;
                poam.ResourcesRequired = viewmodel.ResourcesRequired;
                poam.CostJustification = viewmodel.CostJustification;
                poam.ScheduledCompletionDate = viewmodel.ScheduledCompletionDate;
                poam.PlannedStartDate = viewmodel.PlannedStartDate;
                poam.PlannedFinishDate = viewmodel.PlannedFinishDate;
                poam.ActualStartDate = viewmodel.ActualStartDate;
                poam.ActualFinishDate = viewmodel.ActualFinishDate;
                // assign the authsystem to POAM
                poam.AuthSystem = await authsystem;
                // assign the risklevel to POAM
                poam.RiskLevel = await risklevel;
                // assign the status to POAM
                poam.Status = await status;
                // assign the delay reason to POAM
                poam.DelayReason = await delayreason;
                // assign the weakness of the POAM
                poam.Weakness = await weakness;
                // assign the pocs to the POAM
                poam.ResponsiblePOCs = await pocs;

                return poam;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool IsExcelFileReadable(string filename)
        {
            try
            {
                _excelService.CreateViewModelFromExcel(filename);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Returns the AuthSystem object based on the criteria provided
        /// </summary>
        /// <param name="idorname">ID or name of the AuthSystem</param>
        /// <returns>AuthSystem object</returns>
        private async Task<AuthSystem> CrateAuthSystem(string idorname)
        {
            // check if the input variable is null or empty; throw exception if it is
            if (String.IsNullOrEmpty(idorname)) throw new Exception("Null or Empty AuthSystem in View Model");
            // Try to parse the input param to an "ID" property; see if it is a primary key
            bool result = Int32.TryParse(idorname, out int intID);
            if (result)
            {
                // Find the object using the primary key
                var authsystem = await _context.FindAsync<AuthSystem>(intID);
                // if the object cannot be found; throw an exception; otherwise send the object back
                return authsystem ?? throw new Exception("AuthSystem not found");
            }
            else
            {
                // Try to see if the object can be found via the "Name" property
                var strAuthSystem = await _context.AuthSystems.Where(item => item.Name == idorname).FirstOrDefaultAsync();
                // if the object cannot be found; throw an exception; otherwise send the object back
                return strAuthSystem ?? throw new Exception("AuthSystem not found");
            }
            
        }

        /// <summary>
        /// Returns the Risk Level object based on the criteria provided
        /// </summary>
        /// <param name="idorname">ID or name of the Risk Level</param>
        /// <returns>Risk Level object</returns>
        private async Task<RiskLevel> CreateRiskLevel(string idorname)
        {
            // check if the input variable is null or empty; throw exception if it is
            if (String.IsNullOrEmpty(idorname)) throw new Exception("Null or Empty Risk level in View Model");
            // Try to parse the input param to an "ID" property; see if it is a primary key
            bool result = Int32.TryParse(idorname, out int intID);
            if (result)
            {
                // Find the object using the primary key
                var risklevel = await _context.FindAsync<RiskLevel>(intID);
                // if the object cannot be found; throw an exception; otherwise send the object back
                return risklevel ?? throw new Exception("Risk level not found");
            }
            else
            {
                // Try to see if the object can be found via the "Name" property
                var strRiskLevel = await _context.RiskLevels.Where(item => item.Name == idorname).FirstOrDefaultAsync();
                // if the object cannot be found; throw an exception; otherwise send the object back
                return strRiskLevel ?? throw new Exception("Risk level not found");
            }
        }

        /// <summary>
        /// Returns the Status object based on the criteria provided
        /// </summary>
        /// <param name="idorname">ID or name of the Status</param>
        /// <returns>Status object</returns>
        private async Task<Status> CreateStatus(string idorname)
        {
            // check if the input variable is null or empty; throw exception if it is
            if (String.IsNullOrEmpty(idorname)) throw new Exception("Null or Empty Status in View Model");
            // Try to parse the input param to an "ID" property; see if it is a primary key
            bool result = Int32.TryParse(idorname, out int intID);
            if (result)
            {
                // Find the object using the primary key
                var status = await _context.FindAsync<Status>(intID);
                // if the object cannot be found; throw an exception; otherwise send the object back
                return status ?? throw new Exception("Status not found");
            }
            else
            {
                // Try to see if the object can be found via the "Name" property
                var strStatus = await _context.Statuses.Where(item => item.Name == idorname).FirstOrDefaultAsync();
                // if the object cannot be found; throw an exception; otherwise send the object back
                return strStatus ?? throw new Exception("Status not found");
            }
        }

        /// <summary>
        /// Returns the Delay Reason object based on the criteria provided
        /// </summary>
        /// <param name="idorname">ID or name of the Status</param>
        /// <returns>Delay Reason object</returns>
        private async Task<DelayReason> CreateDelayReason(string idorname)
        {
            // check if the input variable is null or empty; throw exception if it is
            if (String.IsNullOrEmpty(idorname)) throw new Exception("Null or Empty Delay Reason in View Model");
            // Try to parse the input param to an "ID" property; see if it is a primary key
            bool result = Int32.TryParse(idorname, out int intID);
            if (result)
            {
                // Find the object using the primary key
                var delayreason = await _context.FindAsync<DelayReason>(intID);
                // if the object cannot be found; throw an exception; otherwise send the object back
                return delayreason ?? throw new Exception("Delay Reason not found");
            }
            else
            {
                // Try to see if the object can be found via the "Name" property
                var strDelayReason = await _context.DelayReasons.Where(item => item.Name == idorname).FirstOrDefaultAsync();
                // if the object cannot be found; throw an exception; otherwise send the object back
                return strDelayReason ?? throw new Exception("Delay Reason not found");
            }
        }

        /// <summary>
        /// Finds or adds new weakness for the POAM
        /// </summary>
        /// <param name="originalRecommendation">Original Recommendation of the POAM</param>
        /// <param name="risk">The Risk of the POAM</param>
        /// <returns>The weakness object</returns>
        private async Task<Weakness> CrateWeakness(string originalRecommendation, string risk)
        {
            Weakness weakness = null;
            //Find if the weakness exists
            weakness = await _context.Weaknesses.Where(item => item.OriginalRecommendation == originalRecommendation && item.Risk == risk).FirstOrDefaultAsync();
            // if the weakness does not exist, create a new weakness
            if (weakness == null)
            {
                weakness = new Weakness
                {
                    Risk = risk,
                    OriginalRecommendation = originalRecommendation
                };
                // Add the object to the database
                _context.Weaknesses.Add(weakness);
                // Save the object. This will get the ID field populated as well
                await _context.SaveChangesAsync();
            }
            return weakness ?? throw new Exception(@"Weakness not found and/or could not be created");
        }

        private async Task<List<ResponsiblePOC>> CreateResponsiblePOCs(string names, string description = null)
        {
            // split the names on commas
            var lstNames = names.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var pocs = new List<ResponsiblePOC>();
            // loop through the names to find if the POC exists
            foreach (var name in lstNames)
            {
                ResponsiblePOC poc = null;
                // find if the poc exists
                poc = await _context.ResponsiblePOCs.Where(item => item.Name == name).FirstOrDefaultAsync();
                // if the POC does not exist, create a new one
                if (poc == null)
                {
                    poc = new ResponsiblePOC
                    {
                        Name = name,
                        Description = description
                    };
                    // Add the object to the database
                    _context.ResponsiblePOCs.Add(poc);
                    // Save the object. This will get the ID field populated as well
                    await _context.SaveChangesAsync();
                }
                // Add the poc to the list
                pocs.Add(poc);
            }
            // check if the object being passed has any items in it. Throw exception otherwise
            if (pocs.Count() == 0) throw new Exception("No POCs found or created");

            return pocs;
        }

        
    }
}
