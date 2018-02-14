using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionPlan.Data;
using ActionPlan.Entities;
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
            // return the view for the user
            return View(viewmodel);
        }


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
            return View(viewmodel[0]);
        }
    }
}