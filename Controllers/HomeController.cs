using CinemaFinalMVC.Data;
using CinemaFinalMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaFinalMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _context.Genre.ToListAsync();

            //List<MovieGenre> movGenre = await _context.MovieGenre.ToListAsync();
            //var genreResults = _context.MovieGenre.Include(r => r.Movie).Include(r => r.Genre).ToListAsync();
            var movies = await _context.Movie.ToListAsync();
            var years = movies.OrderByDescending(c => c.Premiere.Year);
            ViewBag.years = years;
            ViewBag.genres = genres;
            return View(await _context.Movie.ToListAsync());
        }

        public async Task<IActionResult> ListMoviesByGenre(int? id)
        {
            var genres = await _context.Genre.ToListAsync();
            var movies = await _context.Movie.ToListAsync();
            var years = movies.OrderByDescending(c => c.Premiere.Year);
            ViewBag.years = years;
            ViewBag.genres = genres;

            if (id == null)
            {
                return NotFound();
            }

            var genreResults = await _context.MovieGenre.Where(c => c.Genre.Id == id).Include(r => r.Movie).Include(r => r.Genre).ToListAsync();
            //ViewBag.genres = genreResults;
            var movie = await _context.Movie.FindAsync(id); ;
            if (movie == null)
            {
                return NotFound();
            }

            var genre = await _context.Genre.FindAsync(id); 
            if (genre == null)
            {
                return NotFound();
            }
            ViewBag.genre = genre;
            return View(genreResults);
        }


        // GET: Movies/Details/5
        public async Task<IActionResult> MovieDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var genreResults = await _context.MovieGenre.Where(c => c.Movie.Id == id).Include(r => r.Movie).Include(r => r.Genre).ToListAsync();
            ViewBag.genres = genreResults;
            var movie = await _context.Movie.FindAsync(id); ;
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
