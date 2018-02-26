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
                // assign the authsystem to POAM
                poam.AuthSystem = authsystem;
                poam.Number = viewmodel.Number;
                poam.CSAMPOAMID = viewmodel.CSAMPOAMID;
                poam.ControlID = viewmodel.ControlID;
                // assign the risklevel to POAM
                poam.RiskLevel = risklevel;

                return poam;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private async Task<RiskLevel> CreateRiskLevel(string idorname)
        {
            if (String.IsNullOrEmpty(idorname)) throw new Exception("Null or Empty AuthSystem in View Model");
            bool result = Int32.TryParse(idorname, out int intID);
            if (result)
            {
                var risklevel = await _context.FindAsync<RiskLevel>(intID);
                return risklevel ?? throw new Exception("AuthSystem not found");
            }
            else
            {
                var strRiskLevel = await _context.RiskLevels.Where(item => item.Name == idorname).FirstOrDefaultAsync();
                return strRiskLevel ?? throw new Exception("AuthSystem not found");
            }
        }

        /// <summary>
        /// Returns the AuthSystem object based on the criteria provided
        /// </summary>
        /// <param name="idorname">ID or name of the AuthSystem</param>
        /// <returns>AuthSystem object</returns>
        private async Task<AuthSystem> CrateAuthSystem(string idorname)
        {
            if (String.IsNullOrEmpty(idorname)) throw new Exception("Null or Empty AuthSystem in View Model");
            bool result = Int32.TryParse(idorname, out int intID);
            if (result)
            {
                var authsystem = await _context.FindAsync<AuthSystem>(intID);
                return authsystem ?? throw new Exception("AuthSystem not found");
            }
            else
            {
                var strAuthSystem = await _context.AuthSystems.Where(item => item.Name == idorname).FirstOrDefaultAsync();
                return strAuthSystem ?? throw new Exception("AuthSystem not found");
            }
            
        }
    }
}
