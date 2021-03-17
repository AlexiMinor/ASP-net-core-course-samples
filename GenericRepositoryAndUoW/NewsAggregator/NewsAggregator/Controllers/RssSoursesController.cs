using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.DAL.Core;
using NewsAggregator.DAL.Core.Entities;

namespace NewsAggregator.Controllers
{
    public class RssSoursesController : Controller
    {
        private readonly NewsAggregatorContext _context;

        public RssSoursesController(NewsAggregatorContext context)
        {
            _context = context;
        }

        // GET: RssSources
        public async Task<IActionResult> Index()
        {
            var model = await _context.RssSources.ToListAsync();

            
            return View(model);
        }

        // GET: RssSources/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sourse = await _context.RssSources
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sourse == null)
            {
                return NotFound();
            }

            return View(sourse);
        }

        // GET: RssSources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RssSources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RssSourse sourse)
        {
            if (ModelState.IsValid)
            {
                sourse.Id = Guid.NewGuid();
                _context.RssSources.Add(sourse);
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index));
            }
            return View(sourse);
        }

        // GET: RssSources/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sourse = await _context.RssSources.FindAsync(id);
            if (sourse == null)
            {
                return NotFound();
            }
            return View(sourse);
        }

        // POST: RssSources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,User,Number,State")] RssSourse sourse)
        {
            if (id != sourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.RssSources.Update(sourse); //AddOrUpdate() - if entity not exist - add
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RssSourceExists(sourse.Id))
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
            return View(sourse);
        }

        // GET: RssSources/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sourse = await _context.RssSources
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sourse == null)
            {
                return NotFound();
            }

            return View(sourse);
        }

        // POST: RssSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sourse = await _context.RssSources.FindAsync(id);
            _context.RssSources.Remove(sourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RssSourceExists(Guid id)
        {
            return _context.RssSources.Any(e => e.Id == id);
        }
    }
}
