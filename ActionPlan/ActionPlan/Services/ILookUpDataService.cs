using ActionPlan.Data;
using ActionPlan.Entities;
using System.Collections.Generic;

namespace ActionPlan.Services
{
    /// <summary>
    /// Provides the contractual agreement for the POAM lookup data
    /// </summary>
    public interface ILookUpDataService
    {
        /// <summary>
        /// Return all the systems for which POAMs can be created/edited
        /// </summary>
        /// <returns></returns>
        IEnumerable<AuthSystem> GetAuthSystems();

        /// <summary>
        /// Returns all the Risk levels for which POAMs can be created/edited
        /// </summary>
        /// <returns></returns>
        IEnumerable<RiskLevel> GetRiskLevels();

        /// <summary>
        /// Returns all the statuses for which POAMs can be created/edited
        /// </summary>
        /// <returns></returns>
        IEnumerable<Status> GetStatuses();

        /// <summary>
        /// Returns all the delay reasons for which POAMs can be created/edited
        /// </summary>
        /// <returns></returns>
        IEnumerable<DelayReason> GetDelayReasons();
    }
}
