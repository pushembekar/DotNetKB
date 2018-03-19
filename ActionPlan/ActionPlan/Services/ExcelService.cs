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
                var poams = GetViewModel(worksheet);
                // return the view model
                return poams;
            }
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

        private List<POAMViewModel> GetViewModel(ExcelWorksheet worksheet)
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
                    viewmodel.AuthSystem = "REGIS";
                    viewmodel.ControlID = worksheet.Cells[i, 3].Value == null ? string.Empty : worksheet.Cells[i, 3].Value.ToString();
                    viewmodel.CostJustification = worksheet.Cells[i, 11].Value == null ? string.Empty : worksheet.Cells[i, 11].Value.ToString();
                    viewmodel.CSAMPOAMID = worksheet.Cells[i, 2].Value == null ? string.Empty : worksheet.Cells[i, 2].Value.ToString();
                    viewmodel.DelayReason = GetValueFromCell(worksheet.Cells[i, 6], false);
                    viewmodel.ID = Guid.NewGuid();
                    viewmodel.Number = worksheet.Cells[i, 1].Value == null ? default(int) : Convert.ToInt32(worksheet.Cells[i, 1].Value.ToString());
                    viewmodel.OriginalRecommendation = worksheet.Cells[i, 7].Value == null ? string.Empty : worksheet.Cells[i, 7].Value.ToString();
                    viewmodel.PlannedFinishDate = GetDateFromCell(worksheet.Cells[i, 14]);
                    viewmodel.PlannedStartDate = GetDateFromCell(worksheet.Cells[i, 13]);
                    viewmodel.ResourcesRequired = 100.0M;
                    viewmodel.ResponsiblePOCs = worksheet.Cells[i, 9].Value == null ? string.Empty : worksheet.Cells[i, 9].Value.ToString();
                    viewmodel.Risk = worksheet.Cells[i, 7].Value == null ? string.Empty : worksheet.Cells[i, 7].Value.ToString();
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

            #region May need this code
            //string fullDate = "01 " + cell.Value.ToString();

            //var lstFullDate = fullDate.Split(' ').Select(p => p.Trim()).ToList();
            //if (lstFullDate.Count() != 3) return default(DateTime?);

            //switch(lstFullDate[1])
            //{
            //    case "Jan":
            //    case "January":
            //        lstFullDate[1] = "01";
            //        break;
            //    case "Feb":
            //    case "February":
            //        lstFullDate[1] = "02";
            //        break;
            //    case "Mar":
            //    case "March":
            //        lstFullDate[1] = "03";
            //        break;
            //    case "Apr":
            //    case "April":
            //        lstFullDate[1] = "04";
            //        break;
            //    case "May":
            //        lstFullDate[1] = "05";
            //        break;
            //    case "Jun":
            //    case "June":
            //        lstFullDate[1] = "06";
            //        break;
            //    case "Jul":
            //    case "July":
            //        lstFullDate[1] = "07";
            //        break;
            //    case "Aug":
            //    case "August":
            //        lstFullDate[1] = "08";
            //        break;
            //    case "Sep":
            //    case "Sept":
            //    case "September":
            //        lstFullDate[1] = "09";
            //        break;
            //    case "Oct":
            //    case "October":
            //        lstFullDate[1] = "10";
            //        break;
            //    case "Nov":
            //    case "November":
            //        lstFullDate[1] = "11";
            //        break;
            //    case "Dec":
            //    case "December":
            //        lstFullDate[1] = "12";
            //        break;
            //    default:
            //        lstFullDate[1] = string.Empty;
            //        break;
            //}

            //fullDate = String.Join(@"/", lstFullDate);


            //return (DateTime.TryParseExact(fullDate, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime poamDate)) ? poamDate : default(DateTime);
            #endregion


            //return (DateTime.TryParse(fullDate, out DateTime poamDate)) ? poamDate : default(DateTime?);
        }


        private string GetValueFromCell(ExcelRangeBase cell, bool preserveformat)
        {
            if (cell.Value == null) return string.Empty;

            return preserveformat ? cell.Value.ToString().Trim() : cell.Value.ToString().Trim().Replace("\n", string.Empty);
        }
    }
}
