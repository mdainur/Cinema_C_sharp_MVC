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
    public class MovieCelebritiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieCelebritiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieCelebrities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MovieCelebrity.Include(m => m.Celebrity).Include(m => m.Movie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MovieCelebrities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCelebrity = await _context.MovieCelebrity
                .Include(m => m.Celebrity)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieCelebrityId == id);
            if (movieCelebrity == null)
            {
                return NotFound();
            }

            return View(movieCelebrity);
        }

        // GET: MovieCelebrities/Create
        public IActionResult Create()
        {
            ViewData["CelebrityId"] = new SelectList(_context.Celebrity, "Id", "Fullname");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description");
            return View();
        }

        // POST: MovieCelebrities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieCelebrityId,MovieId,CelebrityId")] MovieCelebrity movieCelebrity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieCelebrity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CelebrityId"] = new SelectList(_context.Celebrity, "Id", "Fullname", movieCelebrity.CelebrityId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", movieCelebrity.MovieId);
            return View(movieCelebrity);
        }

        // GET: MovieCelebrities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCelebrity = await _context.MovieCelebrity.FindAsync(id);
            if (movieCelebrity == null)
            {
                return NotFound();
            }
            ViewData["CelebrityId"] = new SelectList(_context.Celebrity, "Id", "Fullname", movieCelebrity.CelebrityId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", movieCelebrity.MovieId);
            return View(movieCelebrity);
        }

        // POST: MovieCelebrities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieCelebrityId,MovieId,CelebrityId")] MovieCelebrity movieCelebrity)
        {
            if (id != movieCelebrity.MovieCelebrityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieCelebrity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCelebrityExists(movieCelebrity.MovieCelebrityId))
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
            ViewData["CelebrityId"] = new SelectList(_context.Celebrity, "Id", "Fullname", movieCelebrity.CelebrityId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Description", movieCelebrity.MovieId);
            return View(movieCelebrity);
        }

        // GET: MovieCelebrities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCelebrity = await _context.MovieCelebrity
                .Include(m => m.Celebrity)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieCelebrityId == id);
            if (movieCelebrity == null)
            {
                return NotFound();
            }

            return View(movieCelebrity);
        }

        // POST: MovieCelebrities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieCelebrity = await _context.MovieCelebrity.FindAsync(id);
            _context.MovieCelebrity.Remove(movieCelebrity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCelebrityExists(int id)
        {
            return _context.MovieCelebrity.Any(e => e.MovieCelebrityId == id);
        }
    }
}
