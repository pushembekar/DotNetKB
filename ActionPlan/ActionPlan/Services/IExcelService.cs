using ActionPlan.Models.PlanOfActionViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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

        /// <summary>
        /// Creates the view model from the excel
        /// </summary>
        /// <param name="file">File being uploaded</param>
        /// <returns></returns>
        List<POAMViewModel> CreateViewModelFromExcel(IFormFile file);
    }
}
