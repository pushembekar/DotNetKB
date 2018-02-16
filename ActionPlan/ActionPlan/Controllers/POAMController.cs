using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionPlan.Data;
using ActionPlan.Entities;
using ActionPlan.Extensions;
using ActionPlan.Models.PlanOfActionViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActionPlan.Controllers
{
    /// <summary>
    /// Controller that drives the POAM\ views
    /// </summary>
    public class POAMController : Controller
    {
        // private variable holding the data context
        private readonly POAMDbContext _context;
        // private variable holding the automapper context
        private readonly IMapper _mapper;

        [BindProperty]
        public bool IsRecommendationTruncated { get; private set; }

        /// <summary>
        /// Contructor expecting DBContext and Automapper config as dependencies
        /// </summary>
        /// <param name="context">POAMDbContext which holds the POAM list</param>
        /// <param name="mapper">Automapper config reference</param>
        public POAMController(POAMDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Default "Get" method
        /// Returns the list of POAMs in human readable format
        /// </summary>
        /// <returns>List of POAMViewModels representing the POAMs in the system</returns>
        public async Task<IActionResult> Index()
        {
            // async call to get the list of existing POAMs
            var poam = await _context.POAMs
                            .Include(item => item.AuthSystem)
                            .Include(item => item.DelayReason)
                            .Include(item => item.RiskLevel)
                            .Include(item => item.Status)
                            .Include(item => item.Weakness)
                            .Include(item => item.ResponsiblePOCs)
                            .AsNoTracking()
                            .ToListAsync();
            // Mapping the domain model to view model
            var viewmodel = _mapper.Map<List<POAM>, List<POAMViewModel>>(poam);
            // Truncate the longer strings
            foreach (var item in viewmodel)
            {
                item.Recommendation = TruncateLongField(item.Recommendation);
            }
            // return the view for the user
            return View(viewmodel);
        }

        
        /// <summary>
        /// "Get" method for the Details view
        /// Tries to find the detailed information for one particular POAM
        /// If not, displays details for the entier POAM list
        /// </summary>
        /// <param name="poamID">either a guid or some identifier to pinpoint a POAM</param>
        /// <returns>Displays the details of either one particular poam or the entire POAM list</returns>
        public async Task<IActionResult> Details(string poamID)
        {
            // form the query to get existing poams
            var poam = _context.POAMs
                    .Include(item => item.AuthSystem)
                            .Include(item => item.DelayReason)
                            .Include(item => item.RiskLevel)
                            .Include(item => item.Status)
                            .Include(item => item.Weakness)
                            .Include(item => item.ResponsiblePOCs)
                            .AsNoTracking();
                            
            // check if there is any parameter corresponding to a guid
            if (!String.IsNullOrEmpty(poamID))
            {
                // try parsing the string to a Guid
                if (Guid.TryParse(poamID, out Guid poamGuid))
                    poam = poam.Where(item => item.ID == poamGuid);
            }
            // execute the query
            var poamlist = await poam.ToListAsync();
            // Mapping the domain model to view model
            var viewmodel = _mapper.Map<List<POAM>, List<POAMViewModel>>(poamlist);
            // return the view for the user
            return View(viewmodel);
        }

        /// <summary>
        /// Truncates the string to manageable length
        /// </summary>
        /// <param name="recommendation"></param>
        /// <returns>Truncated string</returns>
        private string TruncateLongField(string recommendation)
        {
            // Call the truncate extension method
            var strTruncated = recommendation.Truncate(100);
            // Set the flag to true if the string was actually truncated
            IsRecommendationTruncated = strTruncated.Length < recommendation.Length;
            // return the truncated string
            return strTruncated;
        }

    }
}