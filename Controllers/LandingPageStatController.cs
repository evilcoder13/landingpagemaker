using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using landingpagemaker.Models;

namespace landingpagemaker.Controllers
{
    public class LandingPageStatController : Controller
    {
        private readonly DataContext _context;

        public LandingPageStatController(DataContext context)
        {
            _context = context;
        }

        // GET: LandingPageStat
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.LandingPageStats.Include(l => l.LandingPage);
            return View(await dataContext.ToListAsync());
        }

        // GET: LandingPageStat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landingPageStat = await _context.LandingPageStats
                .Include(l => l.LandingPage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landingPageStat == null)
            {
                return NotFound();
            }

            return View(landingPageStat);
        }

        // GET: LandingPageStat/Create
        public IActionResult Create()
        {
            ViewData["LandingPageId"] = new SelectList(_context.LandingPages, "Id", "Content");
            return View();
        }

        // POST: LandingPageStat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LandingPageId,TotalVisits,TotalActions,Date")] LandingPageStat landingPageStat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landingPageStat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LandingPageId"] = new SelectList(_context.LandingPages, "Id", "Content", landingPageStat.LandingPageId);
            return View(landingPageStat);
        }

        // GET: LandingPageStat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landingPageStat = await _context.LandingPageStats.FindAsync(id);
            if (landingPageStat == null)
            {
                return NotFound();
            }
            ViewData["LandingPageId"] = new SelectList(_context.LandingPages, "Id", "Content", landingPageStat.LandingPageId);
            return View(landingPageStat);
        }

        // POST: LandingPageStat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LandingPageId,TotalVisits,TotalActions,Date")] LandingPageStat landingPageStat)
        {
            if (id != landingPageStat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landingPageStat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandingPageStatExists(landingPageStat.Id))
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
            ViewData["LandingPageId"] = new SelectList(_context.LandingPages, "Id", "Content", landingPageStat.LandingPageId);
            return View(landingPageStat);
        }

        // GET: LandingPageStat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landingPageStat = await _context.LandingPageStats
                .Include(l => l.LandingPage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landingPageStat == null)
            {
                return NotFound();
            }

            return View(landingPageStat);
        }

        // POST: LandingPageStat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landingPageStat = await _context.LandingPageStats.FindAsync(id);
            if (landingPageStat != null)
            {
                _context.LandingPageStats.Remove(landingPageStat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandingPageStatExists(int id)
        {
            return _context.LandingPageStats.Any(e => e.Id == id);
        }
    }
}
