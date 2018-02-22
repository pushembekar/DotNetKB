using System.Collections.Generic;
using ActionPlan.Data;
using ActionPlan.Entities;

namespace ActionPlan.Services
{
    public class LookUpDataService : ILookUpDataService
    {
        /// <summary>
        /// Variable to hold the DB context
        /// </summary>
        private readonly POAMDbContext _context;

        /// <summary>
        /// Constructor with the DB context as DI
        /// </summary>
        /// <param name="context">Dependency injection param</param>
        public LookUpDataService(POAMDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Returns all systems for which POAMs can be created/edited
        /// </summary>
        /// <returns>Enumeration of all the systems</returns>
        public IEnumerable<AuthSystem> GetAuthSystems()
        {
            return _context.AuthSystems;
        }

        /// <summary>
        /// Returns all POAM risk levels
        /// </summary>
        /// <returns>Enumeration of risk levels</returns>
        public IEnumerable<RiskLevel> GetRiskLevels()
        {
            return _context.RiskLevels;
        }

        /// <summary>
        /// Returns all POAM statuses
        /// </summary>
        /// <returns>Enumeration of statuses</returns>
        public IEnumerable<Status> GetStatuses()
        {
            return _context.Statuses;
        }

        /// <summary>
        /// Returns all delay reasons
        /// </summary>
        /// <returns>Enumeration of delay reasons</returns>
        public IEnumerable<DelayReason> GetDelayReasons()
        {
            return _context.DelayReasons;
        }

    }
}
