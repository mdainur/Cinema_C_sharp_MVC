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
    public class CelebrityProfessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CelebrityProfessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CelebrityProfessions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CelebrityProfession.Include(c => c.Celebrity).Include(c => c.Profession);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CelebrityProfessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celebrityProfession = await _context.CelebrityProfession
                .Include(c => c.Celebrity)
                .Include(c => c.Profession)
                .FirstOrDefaultAsync(m => m.CelebrityProfessionId == id);
            if (celebrityProfession == null)
            {
                return NotFound();
            }

            return View(celebrityProfession);
        }

        // GET: CelebrityProfessions/Create
        public IActionResult Create()
        {
            ViewData["CelebrityId"] = new SelectList(_context.Celebrity, "Id", "Fullname");
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name");
            return View();
        }

        // POST: CelebrityProfessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CelebrityProfessionId,CelebrityId,ProfessionId")] CelebrityProfession celebrityProfession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celebrityProfession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CelebrityId"] = new SelectList(_context.Celebrity, "Id", "Fullname", celebrityProfession.CelebrityId);
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", celebrityProfession.ProfessionId);
            return View(celebrityProfession);
        }

        // GET: CelebrityProfessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celebrityProfession = await _context.CelebrityProfession.FindAsync(id);
            if (celebrityProfession == null)
            {
                return NotFound();
            }
            ViewData["CelebrityId"] = new SelectList(_context.Celebrity, "Id", "Fullname", celebrityProfession.CelebrityId);
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", celebrityProfession.ProfessionId);
            return View(celebrityProfession);
        }

        // POST: CelebrityProfessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CelebrityProfessionId,CelebrityId,ProfessionId")] CelebrityProfession celebrityProfession)
        {
            if (id != celebrityProfession.CelebrityProfessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celebrityProfession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelebrityProfessionExists(celebrityProfession.CelebrityProfessionId))
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
            ViewData["CelebrityId"] = new SelectList(_context.Celebrity, "Id", "Fullname", celebrityProfession.CelebrityId);
            ViewData["ProfessionId"] = new SelectList(_context.Profession, "Id", "Name", celebrityProfession.ProfessionId);
            return View(celebrityProfession);
        }

        // GET: CelebrityProfessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celebrityProfession = await _context.CelebrityProfession
                .Include(c => c.Celebrity)
                .Include(c => c.Profession)
                .FirstOrDefaultAsync(m => m.CelebrityProfessionId == id);
            if (celebrityProfession == null)
            {
                return NotFound();
            }

            return View(celebrityProfession);
        }

        // POST: CelebrityProfessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celebrityProfession = await _context.CelebrityProfession.FindAsync(id);
            _context.CelebrityProfession.Remove(celebrityProfession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelebrityProfessionExists(int id)
        {
            return _context.CelebrityProfession.Any(e => e.CelebrityProfessionId == id);
        }
    }
}
