using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using landingpagemaker.Models;
using Microsoft.AspNetCore.Authorization;

namespace landingpagemaker.Controllers
{
    [Authorize]
    public class LogController : Controller
    {
        private readonly DataContext _context;

        public LogController(DataContext context)
        {
            _context = context;
        }

        // GET: Log
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logs.ToListAsync());
        }

        // GET: Log/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // // GET: Log/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // // POST: Log/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Message,LogType,TimeStamp")] Log log)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(log);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(log);
        // }

        // // GET: Log/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var log = await _context.Logs.FindAsync(id);
        //     if (log == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(log);
        // }

        // // POST: Log/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("Id,Message,LogType,TimeStamp")] Log log)
        // {
        //     if (id != log.Id)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(log);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!LogExists(log.Id))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(log);
        // }

        // // GET: Log/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var log = await _context.Logs
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (log == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(log);
        // }

        // // POST: Log/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var log = await _context.Logs.FindAsync(id);
        //     if (log != null)
        //     {
        //         _context.Logs.Remove(log);
        //     }

        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        private bool LogExists(int id)
        {
            return _context.Logs.Any(e => e.Id == id);
        }
    }
}
