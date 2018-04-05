using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            // form the full file path + name for the file
            var fullname = GetUploadLocation(filename);

            // return the full path
            if (File.Exists(fullname))
                return fullname;

            // if we cannot find the file, throw back a file not found exception
            throw new FileNotFoundException($"File does not exist at location {filename}");
        }

        public bool EnsureCorrectFileFormat(string filename, string format)
        {
            return Path.GetExtension(filename) == format;
        }

        public string GetUploadLocation(string filename)
        {
            // Get the config value for the upload file location
            var uploadfolder = _configuration.GetValue<string>("UploadFolder");

            // form the full file path + name for the file
            var fullname = Path.Combine(_environment.ContentRootPath, uploadfolder, filename);

            // return full path
            return fullname;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            var filepath = GetUploadLocation(file.FileName);

            if(file.Length > 0)
            {
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    try
                    {
                        await file.CopyToAsync(stream);
                        return filepath;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to upload file", ex);
                    }
                }
            }
            else
            {
                throw new Exception("Zero length file found");
            }
        }
    }
}
