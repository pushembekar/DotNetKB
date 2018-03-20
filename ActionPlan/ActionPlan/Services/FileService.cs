using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ActionPlan.Services
{
    /// <summary>
    /// Service that implements the IFileService interface
    /// Provides services for working with any kind of files within the application
    /// </summary>
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _environment;

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="environment">Environment dependency injection</param>
        /// <param name="configuration">Configuration dependency injection</param>
        public FileService(IHostingEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        /// <summary>
        /// Checks if the file exists and returns the full path to the file if it does
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <returns>Full path of the file</returns>
        public string GetFullFileName(string filename)
        {
            // Check if the file exists at the location
            if (File.Exists(filename))
                return filename;

            // Get the config value for the upload file location
            var uploadfolder = _configuration.GetValue<string>("UploadFolder");

            // form the full file path + name for the file
            var fullname = Path.Combine(_environment.ContentRootPath, uploadfolder, filename);

            // return the full path
            if (File.Exists(fullname))
                return fullname;

            // if we cannot find the file, throw back a file not found exception
            throw new FileNotFoundException($"File does not exist at location {filename}");
        }
    }
}
