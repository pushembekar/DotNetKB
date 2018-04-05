using System.Threading.Tasks;
using ActionPlan.Data;
using ActionPlan.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionPlan.Controllers
{
    /// <summary>
    /// Controller for the excel upload and other file transfer related activities
    /// </summary>
    public class ExcelController : Controller
    {
        // Variable to hold the entity service reference
        private readonly IEntityService _entityservice;
        // Variable to hold the DB context
        private readonly POAMDbContext _context;

        /// <summary>
        /// Constructor for the controller
        /// </summary>
        /// <param name="context">DB context</param>
        /// <param name="entityservice">Entity service</param>
        public ExcelController(POAMDbContext context, IEntityService entityservice)
        {
            _context = context;
            _entityservice = entityservice;
        }

        /// <summary>
        /// The excel import method
        /// </summary>
        /// <param name="fileupload">File being uploaded</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Import(IFormFile fileupload)
        {
            // get the poam list from the uploaded worksheet
            var poams = _entityservice.ReadPOAMsFromExcel(fileupload);
            // add the poam list to persistent storage
            foreach (var item in await poams)
            {
                _context.POAMs.Add(item);
                await _context.SaveChangesAsync();
            }
            // Redirect back to the index page
            return RedirectToAction("Index", "POAM");
        }
    }
}