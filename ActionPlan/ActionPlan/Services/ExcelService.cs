using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ActionPlan.Models.PlanOfActionViewModels;
using OfficeOpenXml;

namespace ActionPlan.Services
{
    /// <summary>
    /// Class encapsulating all items needed for excel read/write
    /// </summary>
    public class ExcelService : IExcelService
    {
        // Variable to hold the fileservice
        private readonly IFileService _fileservice;

        /// <summary>
        /// Contructor for the class
        /// </summary>
        /// <param name="fileservice"></param>
        public ExcelService(IFileService fileservice)
        {
            _fileservice = fileservice;
        }

        /// <summary>
        /// Creates the view model from the excel file provided
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <returns>POAMViewModel object</returns>
        public List<POAMViewModel> CreateViewModelFromExcel(string filename)
        {
            // check if the file exists
            var fullname = _fileservice.GetFullFileName(filename);
            // read the file
            var file = new FileInfo(fullname);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                var headings = GetHeadings(worksheet);
                // fill the view model after validations
                var poams = GetViewModel(worksheet, GetSystemName(fullname));
                // return the view model
                return poams;
            }
        }

        /// <summary>
        /// Get the name of the system from the filename
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string GetSystemName(string filename)
        {
            var splitfilename = Path.GetFileName(filename);
            return splitfilename.Split('-', StringSplitOptions.None)[0];
        }

        /// <summary>
        /// Get the headings and the index locations of the excel file
        /// </summary>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        private Dictionary<string, int> GetHeadings(ExcelWorksheet worksheet)
        {
            if (worksheet == null) throw new ArgumentNullException();
            var headings = new Dictionary<string, int>();

            for (int i = 1; i < worksheet.Dimension.Columns; i++)
            {
                var text = (worksheet.Cells[1, i].Value == null) ? string.Empty : worksheet.Cells[1, i].Value.ToString().Trim();
                if (string.IsNullOrEmpty(text))
                    break;

                headings.Add(text, i);
            }

            return headings;
        }

        /// <summary>
        /// Form the view model from the excel worksheet
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="systemname"></param>
        /// <returns></returns>
        private List<POAMViewModel> GetViewModel(ExcelWorksheet worksheet, string systemname)
        {
            if (worksheet == null) throw new ArgumentNullException();
            var poams = new List<POAMViewModel>();

            for (int i = 2; i < worksheet.Dimension.Rows; i++)
            {
                try
                {
                    var viewmodel = new POAMViewModel
                    {
                        Recommendation = worksheet.Cells[i, 8].Value == null ? string.Empty : worksheet.Cells[i, 8].Value.ToString()
                    };
                    if (string.IsNullOrEmpty(viewmodel.Recommendation))
                        break;

                    viewmodel.ID = Guid.NewGuid();
                    viewmodel.AuthSystem = systemname;
                    viewmodel.Number = worksheet.Cells[i, 1].Value == null ? default(int) : Convert.ToInt32(worksheet.Cells[i, 1].Value.ToString());
                    viewmodel.CSAMPOAMID = worksheet.Cells[i, 2].Value == null ? string.Empty : worksheet.Cells[i, 2].Value.ToString();
                    viewmodel.ControlID = worksheet.Cells[i, 3].Value == null ? string.Empty : worksheet.Cells[i, 3].Value.ToString();
                    viewmodel.RiskLevel = worksheet.Cells[i, 4].Value == null ? string.Empty : worksheet.Cells[i, 4].Value.ToString();
                    viewmodel.Status = GetValueFromCell(worksheet.Cells[i, 5], false);
                    viewmodel.DelayReason = GetValueFromCell(worksheet.Cells[i, 6], false);
                    viewmodel.OriginalRecommendation = GetOriginalRecommendation(worksheet.Cells[i, 7]);
                    viewmodel.Risk = GetRisk(worksheet.Cells[i, 7]);

                    viewmodel.ResponsiblePOCs = worksheet.Cells[i, 9].Value == null ? string.Empty : worksheet.Cells[i, 9].Value.ToString();
                    viewmodel.ResourcesRequired = GetCurrencyFromCell(worksheet.Cells[i, 10]);
                    viewmodel.CostJustification = worksheet.Cells[i, 11].Value == null ? string.Empty : worksheet.Cells[i, 11].Value.ToString();
                    viewmodel.ScheduledCompletionDate = GetDateFromCell(worksheet.Cells[i, 12]);
                    viewmodel.PlannedStartDate = GetDateFromCell(worksheet.Cells[i, 13]);
                    viewmodel.PlannedFinishDate = GetDateFromCell(worksheet.Cells[i, 14]);
                    viewmodel.ActualStartDate = GetDateFromCell(worksheet.Cells[i, 15]);
                    viewmodel.ActualFinishDate = GetDateFromCell(worksheet.Cells[i, 16]);

                    poams.Add(viewmodel);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return poams;
        }

        /// <summary>
        /// Form the view model from the excel worksheet
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="headings"></param>
        /// <returns></returns>
        private List<POAMViewModel> GetViewModel(ExcelWorksheet worksheet, Dictionary<string, int> headings)
        {
            if (worksheet == null) throw new ArgumentNullException();
            var poams = new List<POAMViewModel>();

            for (int i = 2; i < worksheet.Dimension.Rows; i++)
            {
                var viewmodel = new POAMViewModel();
                viewmodel.Recommendation = (headings.Any(dict => dict.Key.StartsWith("Recommended") 
                                            && worksheet.Cells[i, headings.Where(keyvalue => keyvalue.Key.StartsWith("Recommended")).Select(item => item.Value).FirstOrDefault()].Value == null) 
                                                    ? string.Empty 
                                                    : worksheet.Cells[i, headings.Where(keyvalue => keyvalue.Key.StartsWith("Recommended")).Select(item => item.Value).FirstOrDefault()].Value.ToString());
                if (string.IsNullOrEmpty(viewmodel.Recommendation))
                    break;

                viewmodel.ActualFinishDate = DateTime.Now;
                viewmodel.ActualStartDate = DateTime.Now;
                viewmodel.AuthSystem = "REGIS";
                viewmodel.ControlID = "1";
                viewmodel.CostJustification = "Minimum Operational Cost";
                viewmodel.CSAMPOAMID = "2";
                viewmodel.DelayReason = "Other";
                viewmodel.ID = Guid.NewGuid();
                viewmodel.Number = 5;
                viewmodel.OriginalRecommendation = "Lorem Ipsum doler";
                viewmodel.PlannedFinishDate = DateTime.Now;
                viewmodel.PlannedStartDate = DateTime.Now;
                viewmodel.ResourcesRequired = 100.0M;
                viewmodel.ResponsiblePOCs = "SOC";
                viewmodel.Risk = "Lorem Ipsum";
                viewmodel.RiskLevel = "H";
                viewmodel.ScheduledCompletionDate = DateTime.Now;
                viewmodel.Status = "Delayed";

                poams.Add(viewmodel);
            }

            

            return poams;
        }

        /// <summary>
        /// Get the date value from the excel cell provided
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private DateTime? GetDateFromCell(ExcelRangeBase cell)
        {
            if (cell.Value == null) return default(DateTime?);

            return Int64.TryParse(cell.Value.ToString(), out long exceldate)
                ? DateTime.FromOADate(exceldate)
                : default(DateTime?);

        }

        /// <summary>
        /// Get the string value for the Excel cell
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="preserveformat"></param>
        /// <returns></returns>
        private string GetValueFromCell(ExcelRangeBase cell, bool preserveformat)
        {
            if (cell.Value == null) return string.Empty;

            return preserveformat ? cell.Value.ToString().Trim() : cell.Value.ToString().Trim().Replace("\n", string.Empty);
        }

        /// <summary>
        /// Get the currency value from the excel cell provided
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private decimal GetCurrencyFromCell(ExcelRangeBase cell, decimal defaultValue = 100.0M)
        {
            if (cell.Value == null) return defaultValue;

            return decimal.TryParse(cell.Value.ToString(), out decimal cost) ? cost : defaultValue;
        }

        /// <summary>
        /// Get the Original recommendation of the POAM
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private string GetOriginalRecommendation(ExcelRangeBase cell)
        {
            if (cell.Value == null) return string.Empty;

            var index = cell.Value.ToString().IndexOf("Risk:");

            return (index > 0) ? cell.Value.ToString().Substring(0, index) : string.Empty;
        }

        /// <summary>
        /// Get the 'Risk' of the poam
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private string GetRisk(ExcelRangeBase cell)
        {
            if (cell.Value == null) return string.Empty;

            var index = cell.Value.ToString().IndexOf("Risk:");

            return (index > 0) ? cell.Value.ToString().Substring(index, cell.Value.ToString().Length-index) : string.Empty;
        }
    }
}
