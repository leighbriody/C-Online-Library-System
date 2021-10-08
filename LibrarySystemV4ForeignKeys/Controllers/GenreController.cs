using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystemV4ForeignKeys.Data;
using LibrarySystemV4ForeignKeys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemV4ForeignKeys.Controllers
{
    public class GenreController : Controller
    {

        //injections
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        //need to inject the interface repositorys
        private readonly IGenreRepository GRepo;
        private readonly IBookRepository BRepo;
        private readonly IUserRepository URepo;

        public GenreController(IBookRepository bookRepository,  IUserRepository userRepository , IGenreRepository genreRepository, IWebHostEnvironment hostEnvironment, ApplicationDbContext context)
        {
            _context = context;
            GRepo = genreRepository;
            BRepo = bookRepository;
            this._hostEnvironment = hostEnvironment;
        }



        // GET: Books
        [AllowAnonymous]
        public IActionResult IndexAnon()
        {
            var applicationDbContext = GRepo.AllGenres;
            return View(applicationDbContext.ToList());
        }

        public IActionResult Index()
        {
            var applicationDbContext = GRepo.AllGenres;
            return View(applicationDbContext.ToList());
        }


        // GET: Genre/Create
        public IActionResult Create()
        {
            
            return View();
        }



        // POST: Genre/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("genreType")] Genre genre)
        {
            if (ModelState.IsValid)
            {
          
                _context.Add(genre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

          
            return View(genre);
        }


        //Delete Method

        // GET: Genres/Delete/
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.id == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }


        // POST: Genres/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
