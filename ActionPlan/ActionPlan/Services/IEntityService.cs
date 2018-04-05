using ActionPlan.Entities;
using ActionPlan.Models.PlanOfActionViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<POAM> CreatePOAMFromViewModel(POAMViewModel viewmodel);

        Task<bool> IsExcelFileReadable(string filename);

        Task<List<POAM>> ReadPOAMsFromExcel(string filename);

        Task<List<POAM>> ReadPOAMsFromExcel(IFormFile file);
    }
}
