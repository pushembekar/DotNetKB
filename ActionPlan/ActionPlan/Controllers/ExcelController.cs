using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionPlan.Data;
using ActionPlan.Services;
using Microsoft.AspNetCore.Mvc;

namespace ActionPlan.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IEntityService _entityservice;
        private readonly POAMDbContext _context;

        public ExcelController(POAMDbContext context, IEntityService entityservice)
        {
            _context = context;
            _entityservice = entityservice;
        }

        public async Task<IActionResult> Import()
        {
            
            var poams = _entityservice.ReadPOAMsFromExcel(@"REGIS-POAM-Spreadsheet-FY17.xlsx");
            foreach (var item in await poams)
            {
                _context.POAMs.Add(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "POAM");
        }
    }
}