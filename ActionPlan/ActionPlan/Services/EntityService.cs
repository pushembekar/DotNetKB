using System;
using ActionPlan.Data;
using ActionPlan.Entities;
using ActionPlan.Models.PlanOfActionViewModels;

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
        /// <param name="viewmodel"></param>
        /// <returns></returns>
        public POAM CreatePOAMFromViewModel(POAMViewModel viewmodel)
        {
            throw new NotImplementedException();
        }
    }
}
