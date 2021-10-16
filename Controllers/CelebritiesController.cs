using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaFinalMVC.Data;
using CinemaFinalMVC.Models;

namespace CinemaFinalMVC.Controllers
{
    public class CelebritiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CelebritiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Celebrities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Celebrity.Include(c => c.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Celebrities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celebrity = await _context.Celebrity
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celebrity == null)
            {
                return NotFound();
            }

            return View(celebrity);
        }

        // GET: Celebrities/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name");
            return View();
        }

        // POST: Celebrities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fullname,Birthdate,Gender,CountryId,PictureUrl")] Celebrity celebrity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celebrity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", celebrity.CountryId);
            return View(celebrity);
        }

        // GET: Celebrities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celebrity = await _context.Celebrity.FindAsync(id);
            if (celebrity == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", celebrity.CountryId);
            return View(celebrity);
        }

        // POST: Celebrities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fullname,Birthdate,Gender,CountryId,PictureUrl")] Celebrity celebrity)
        {
            if (id != celebrity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celebrity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelebrityExists(celebrity.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", celebrity.CountryId);
            return View(celebrity);
        }

        // GET: Celebrities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celebrity = await _context.Celebrity
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celebrity == null)
            {
                return NotFound();
            }

            return View(celebrity);
        }

        // POST: Celebrities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celebrity = await _context.Celebrity.FindAsync(id);
            _context.Celebrity.Remove(celebrity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelebrityExists(int id)
        {
            return _context.Celebrity.Any(e => e.Id == id);
        }
    }
}
