using ActionPlan.Entities;
using ActionPlan.Models.PlanOfActionViewModels;

namespace ActionPlan.Services
{
    /// <summary>
    /// Interface defining the contract of what the Entity service will do
    /// </summary>
    public interface IEntityService
    {
        /// <summary>
        /// Returns a fully filled POAM entity object
        /// </summary>
        /// <param name="viewmodel">POAMViewModel object</param>
        /// <returns>POAM object</returns>
        POAM CreatePOAMFromViewModel(POAMViewModel viewmodel);
    }
}
