using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using landingpagemaker.Models;
using Microsoft.AspNetCore.Identity;

namespace landingpagemaker.Controllers
{
    public class LandingPageController : Controller
    {
        private readonly DataContext _context;

        public LandingPageController(DataContext context)
        {
            _context = context;
        }

        // GET: LandingPage
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.LandingPages.Include(l => l.PageCategory).Include(l => l.User);
            return View(await dataContext.ToListAsync());
        }

        // GET: LandingPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landingPage = await _context.LandingPages
                .Include(l => l.PageCategory)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landingPage == null)
            {
                return NotFound();
            }

            return View(landingPage);
        }

        // GET: LandingPage/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id");
            return View();
        }

        // POST: LandingPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Content,CategoryId,Status,CreatedOn,UpdatedOn,ExpiredOn,UserId")] LandingPage landingPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landingPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", landingPage.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", landingPage.UserId);
            return View(landingPage);
        }

        // GET: LandingPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landingPage = await _context.LandingPages.FindAsync(id);
            if (landingPage == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", landingPage.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", landingPage.UserId);
            return View(landingPage);
        }

        // POST: LandingPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Content,CategoryId,Status,CreatedOn,UpdatedOn,ExpiredOn,UserId")] LandingPage landingPage)
        {
            if (id != landingPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landingPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandingPageExists(landingPage.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", landingPage.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", landingPage.UserId);
            return View(landingPage);
        }

        // GET: LandingPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landingPage = await _context.LandingPages
                .Include(l => l.PageCategory)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landingPage == null)
            {
                return NotFound();
            }

            return View(landingPage);
        }

        // POST: LandingPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landingPage = await _context.LandingPages.FindAsync(id);
            if (landingPage != null)
            {
                _context.LandingPages.Remove(landingPage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandingPageExists(int id)
        {
            return _context.LandingPages.Any(e => e.Id == id);
        }
    }
}
