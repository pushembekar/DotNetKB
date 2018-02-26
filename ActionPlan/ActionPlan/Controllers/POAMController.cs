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
using Microsoft.Extensions.Configuration;
using ActionPlan.Services;

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
        // private variable holding the configuration context
        private readonly IConfiguration _configuration;
        // private variable holding the entity service context
        private readonly IEntityService _entityservice;

        /// <summary>
        /// Contructor expecting DBContext and Automapper config as dependencies
        /// </summary>
        /// <param name="context">POAMDbContext which holds the POAM list</param>
        /// <param name="mapper">Automapper config reference</param>
        /// <param name="configuration">Configuration setttings for the application</param>
        /// <param name="entityservice">Service to deal with application entities</param>
        public POAMController(POAMDbContext context, IMapper mapper, IConfiguration configuration, IEntityService entityservice)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _entityservice = entityservice;
        }

        /// <summary>
        /// Default "Get" method
        /// Returns the list of POAMs in human readable format
        /// </summary>
        /// <returns>List of POAMViewModels representing the POAMs in the system</returns>
        public async Task<IActionResult> Index()
        {
            // read the configuration values... provide default value in case there's an exception
            int @short = _configuration.GetValue<int>("Exerpts:Short", 20);
            int @medium = _configuration.GetValue<int>("Exerpts:Medium", 50);
            int @long = _configuration.GetValue<int>("Exerpts:Long", 100);
            // async call to get the list of existing POAMs
            var poam = await GetPOAMList().AsNoTracking().OrderBy(item => item.Number).ToListAsync();
            // Mapping the domain model to view model
            var viewmodel = _mapper.Map<List<POAM>, List<POAMViewModel>>(poam);
            // Truncate the longer strings
            foreach (var item in viewmodel)
            {
                item.ControlID = TruncateLongField(item.ControlID, @short, out bool controlflag);
                item.IsControlIDTruncated = controlflag;
                item.Risk = TruncateLongField(item.Risk, @medium, out bool riskflag);
                item.IsRiskTruncated = riskflag;
                item.OriginalRecommendation = TruncateLongField(item.OriginalRecommendation, @short, out bool origrecoflag);
                item.IsOriginalRecommendationTruncated = origrecoflag;
                item.Recommendation = TruncateLongField(item.Recommendation, @long, out bool recoflag);
                item.IsRecommendationTruncated = recoflag;
            }
            // return the view for the user
            return View(viewmodel);
        }

        
        /// <summary>
        /// "Get" method for the Details view
        /// Tries to find the detailed information for one particular POAM
        /// If not, displays details for the entier POAM list
        /// </summary>
        /// <param name="ID">either a guid or some identifier to pinpoint a POAM</param>
        /// <returns>Displays the details of either one particular poam or the entire POAM list</returns>
        public async Task<IActionResult> Details(string ID)
        {
            // form the query to get existing poams
            var poam = GetPOAMList().AsNoTracking();
            // check if there is any parameter corresponding to a guid
            if (!String.IsNullOrEmpty(ID))
            {
                // try parsing the string to a Guid
                if (Guid.TryParse(ID, out Guid poamGuid))
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
        /// Provides the 'Get' view for new POAM creation
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Provides the 'Post' view for new POAM creation
        /// </summary>
        /// <param name="poam">The bound poam view model</param>
        /// <returns>Redirect to the index page</returns>
        [HttpPost]
        public IActionResult Create(POAMViewModel poam)
        {
            var entity = _entityservice.CreatePOAMFromViewModel(poam);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Truncates the string to manageable length
        /// </summary>
        /// <param name="excerpt">The original long sentence</param>
        /// <param name="words">number of words to truncate the sentence to</param>
        /// <param name="flag">'out' param depicting if the sentence was truncated or not</param>
        /// <returns>Truncated string</returns>
        private string TruncateLongField(string excerpt, int words, out bool flag)
        {
            // Call the truncate extension method
            var strTruncated = excerpt.Truncate(words);
            // Set the flag to true if the string was actually truncated
            flag = strTruncated.Length < excerpt.Length;
            // return the truncated string
            return strTruncated;
        }

        /// <summary>
        /// Returns the query to list all the poams in the system
        /// </summary>
        /// <returns>IQueryable expression of the query</returns>
        private IQueryable<POAM> GetPOAMList() => _context.POAMs
                    .Include(item => item.AuthSystem)
                    .Include(item => item.DelayReason)
                    .Include(item => item.RiskLevel)
                    .Include(item => item.Status)
                    .Include(item => item.Weakness)
                    .Include(item => item.ResponsiblePOCs);
    }
}