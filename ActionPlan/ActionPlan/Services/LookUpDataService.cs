using System.Collections.Generic;
using ActionPlan.Data;
using ActionPlan.Entities;

namespace ActionPlan.Services
{
    public class LookUpDataService : ILookUpDataService
    {
        private readonly POAMDbContext _context;

        public LookUpDataService(POAMDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AuthSystem> GetAllAuthSystems()
        {
            return _context.AuthSystems;
        }
    }
}
