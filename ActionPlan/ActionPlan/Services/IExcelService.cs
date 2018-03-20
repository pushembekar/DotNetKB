using ActionPlan.Models.PlanOfActionViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActionPlan.Services
{
    /// <summary>
    /// Class that supports the import/export of the excel data
    /// </summary>
    public interface IExcelService
    {
        /// <summary>
        /// Creates the view model from the excel
        /// </summary>
        /// <param name="filename">Location of the excel file</param>
        /// <returns></returns>
        List<POAMViewModel> CreateViewModelFromExcel(string filename);
    }
}
