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
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            // async call to get the list of existing POAMs
            var poam = await _context.POAMs.ToListAsync();
            // Mapping the domain model to view model
            var viewmodel = _mapper.Map<List<POAM>, List<POAMViewModel>>(poam);
            // return the view for the user
            return View(viewmodel);
        }
    }
}