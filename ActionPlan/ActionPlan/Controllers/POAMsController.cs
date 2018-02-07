using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActionPlan.Data;
using ActionPlan.Models.PlanOfActionModels;

namespace ActionPlan.Controllers
{
    public class POAMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public POAMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: POAMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.POAMs.ToListAsync());
        }

        // GET: POAMs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pOAM = await _context.POAMs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (pOAM == null)
            {
                return NotFound();
            }

            return View(pOAM);
        }

        // GET: POAMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: POAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Number,CSAMPOAMID,ControlID,Recommendation,CreateDate")] POAM pOAM)
        {
            if (ModelState.IsValid)
            {
                pOAM.ID = Guid.NewGuid();
                _context.Add(pOAM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pOAM);
        }

        // GET: POAMs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pOAM = await _context.POAMs.SingleOrDefaultAsync(m => m.ID == id);
            if (pOAM == null)
            {
                return NotFound();
            }
            return View(pOAM);
        }

        // POST: POAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Number,CSAMPOAMID,ControlID,Recommendation,CreateDate")] POAM pOAM)
        {
            if (id != pOAM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pOAM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!POAMExists(pOAM.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pOAM);
        }

        // GET: POAMs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pOAM = await _context.POAMs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (pOAM == null)
            {
                return NotFound();
            }

            return View(pOAM);
        }

        // POST: POAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pOAM = await _context.POAMs.SingleOrDefaultAsync(m => m.ID == id);
            _context.POAMs.Remove(pOAM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool POAMExists(Guid id)
        {
            return _context.POAMs.Any(e => e.ID == id);
        }
    }
}
