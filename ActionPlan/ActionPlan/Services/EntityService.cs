using System;
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

        /// <summary>
        /// Service constructor. Takes the POAMDbContext as dependency
        /// </summary>
        /// <param name="context"></param>
        public EntityService(POAMDbContext context)
        {
            _context = context;
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
                var authsystem = await CrateAuthSystem(viewmodel.AuthSystem);
                var risklevel = await CreateRiskLevel(viewmodel.RiskLevel);
                var status = await CreateStatus(viewmodel.Status);
                var delayreason = await CreateDelayReason(viewmodel.DelayReason);
                // assign the authsystem to POAM
                poam.AuthSystem = authsystem;
                poam.Number = viewmodel.Number;
                poam.CSAMPOAMID = viewmodel.CSAMPOAMID;
                poam.ControlID = viewmodel.ControlID;
                // assign the risklevel to POAM
                poam.RiskLevel = risklevel;
                // assign the status to POAM
                poam.Status = status;
                // assign the delay reason to POAM
                poam.DelayReason = delayreason;

                return poam;
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
                var strDelayReason = await _context.Statuses.Where(item => item.Name == idorname).FirstOrDefaultAsync();
                // if the object cannot be found; throw an exception; otherwise send the object back
                return strDelayReason ?? throw new Exception("Delay Reason not found");
            }
        }

    }
}
