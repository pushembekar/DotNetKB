using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace ActionPlan.Services
{
    /// <summary>
    /// Interface for working with any kind of file within the application
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// returns the full filename of the file
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <returns>Full path of the file</returns>
        string GetFullFileName(string filename);

        bool EnsureCorrectFileFormat(string filename, string format);

        string GetUploadLocation(string filename);

        Task<string> UploadFile(IFormFile file);
    }
}
