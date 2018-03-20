using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ActionPlan.Models.PlanOfActionViewModels;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;

namespace ActionPlan.Services
{
    public class ExcelService : IExcelService
    {
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;

        public ExcelService(IHostingEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public async Task<List<POAMViewModel>> CreateViewModelFromExcel(string filename)
        {
            // check if the file exists

            var fullname = GetFullFileName(filename);
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

        private string GetSystemName(string filename)
        {
            var splitfilename = Path.GetFileName(filename);
            return splitfilename.Split('-', StringSplitOptions.None)[0];
        }

        private string GetFullFileName(string filename)
        {
            if (File.Exists(filename))
                return filename;

            var uploadfolder = _configuration.GetValue<string>("UploadFolder");

            var fullname = Path.Combine(_environment.ContentRootPath, uploadfolder, filename);

            if (File.Exists(fullname))
                return fullname;

            throw new FileNotFoundException($"File does not exist at location {filename}");
        }

        //private List<string> GetHeadings(ExcelWorksheet worksheet)
        //{
        //    if (worksheet == null) throw new ArgumentNullException();
        //    var headings = new List<string>();

        //    for (int i = 1; i < worksheet.Dimension.Columns; i++)
        //    {
        //        var text = (worksheet.Cells[1, i].Value == null) ? string.Empty : worksheet.Cells[1, i].Value.ToString();
        //        if (string.IsNullOrEmpty(text))
        //            break;

        //        headings.Add(text);
        //    }

        //    return headings;
        //}

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

        private List<POAMViewModel> GetViewModel(ExcelWorksheet worksheet, string systemname)
        {
            if (worksheet == null) throw new ArgumentNullException();
            var poams = new List<POAMViewModel>();

            for (int i = 2; i < worksheet.Dimension.Rows; i++)
            {
                try
                {
                    var viewmodel = new POAMViewModel();
                    viewmodel.Recommendation = worksheet.Cells[i, 8].Value == null ? string.Empty : worksheet.Cells[i, 8].Value.ToString();
                    if (string.IsNullOrEmpty(viewmodel.Recommendation))
                        break;

                    viewmodel.ActualFinishDate = GetDateFromCell(worksheet.Cells[i, 16]);
                    viewmodel.ActualStartDate = GetDateFromCell(worksheet.Cells[i, 15]);
                    viewmodel.AuthSystem = systemname;
                    viewmodel.ControlID = worksheet.Cells[i, 3].Value == null ? string.Empty : worksheet.Cells[i, 3].Value.ToString();
                    viewmodel.CostJustification = worksheet.Cells[i, 11].Value == null ? string.Empty : worksheet.Cells[i, 11].Value.ToString();
                    viewmodel.CSAMPOAMID = worksheet.Cells[i, 2].Value == null ? string.Empty : worksheet.Cells[i, 2].Value.ToString();
                    viewmodel.DelayReason = GetValueFromCell(worksheet.Cells[i, 6], false);
                    viewmodel.ID = Guid.NewGuid();
                    viewmodel.Number = worksheet.Cells[i, 1].Value == null ? default(int) : Convert.ToInt32(worksheet.Cells[i, 1].Value.ToString());
                    viewmodel.OriginalRecommendation = GetOriginalRecommendation(worksheet.Cells[i, 7]);
                    viewmodel.PlannedFinishDate = GetDateFromCell(worksheet.Cells[i, 14]);
                    viewmodel.PlannedStartDate = GetDateFromCell(worksheet.Cells[i, 13]);
                    viewmodel.ResourcesRequired = GetCurrencyFromCell(worksheet.Cells[i, 10]);
                    viewmodel.ResponsiblePOCs = worksheet.Cells[i, 9].Value == null ? string.Empty : worksheet.Cells[i, 9].Value.ToString();
                    viewmodel.Risk = GetRisk(worksheet.Cells[i, 7]);
                    viewmodel.RiskLevel = worksheet.Cells[i, 4].Value == null ? string.Empty : worksheet.Cells[i, 4].Value.ToString();
                    viewmodel.ScheduledCompletionDate = GetDateFromCell(worksheet.Cells[i, 12]);
                    viewmodel.Status = GetValueFromCell(worksheet.Cells[i, 5], false);

                    poams.Add(viewmodel);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }



            return poams;
        }

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

        private DateTime? GetDateFromCell(ExcelRangeBase cell)
        {
            if (cell.Value == null) return default(DateTime?);

            return Int64.TryParse(cell.Value.ToString(), out long exceldate)
                ? DateTime.FromOADate(exceldate)
                : default(DateTime?);

        }


        private string GetValueFromCell(ExcelRangeBase cell, bool preserveformat)
        {
            if (cell.Value == null) return string.Empty;

            return preserveformat ? cell.Value.ToString().Trim() : cell.Value.ToString().Trim().Replace("\n", string.Empty);
        }

        private decimal GetCurrencyFromCell(ExcelRangeBase cell)
        {
            if (cell.Value == null) return 100.0M;

            return decimal.TryParse(cell.Value.ToString(), out decimal cost) ? cost : 100.0M;
        }

        private string GetOriginalRecommendation(ExcelRangeBase cell)
        {
            if (cell.Value == null) return string.Empty;

            var index = cell.Value.ToString().IndexOf("Risk:");

            return (index > 0) ? cell.Value.ToString().Substring(0, index) : string.Empty;
        }

        private string GetRisk(ExcelRangeBase cell)
        {
            if (cell.Value == null) return string.Empty;

            var index = cell.Value.ToString().IndexOf("Risk:");

            return (index > 0) ? cell.Value.ToString().Substring(index, cell.Value.ToString().Length-index) : string.Empty;
        }
    }
}
