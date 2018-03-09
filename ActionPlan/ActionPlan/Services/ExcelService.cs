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

        public Task<List<POAMViewModel>> CreateViewModelFromExcel(string filename)
        {
            // check if the file exists

            var fullname = GetFullFileName(filename);
            // read the file
            var file = new FileInfo(fullname);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                var text = worksheet.Cells[1, 7].Value.ToString();
            }
            // fill the view model after validations
            // return the view model

            throw new NotImplementedException();
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
    }
}
