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
        IEnumerable<AuthSystem> GetAllAuthSystems();
    }
}
