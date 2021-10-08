 using LibrarySystemV4ForeignKeys.Data;
using LibrarySystemV4ForeignKeys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Controllers
{
    public class BookController : Controller
    {
        //injections
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        //need to inject the interface repositorys
        private readonly IGenreRepository GRepo;
        private readonly IBookRepository BRepo;
    

        public BookController(IBookRepository bookRepository,  IGenreRepository genreRepository, IWebHostEnvironment hostEnvironment, ApplicationDbContext context)
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
            var applicationDbContext = BRepo.AllBooks;
            return View(applicationDbContext.ToList());
        }

        public IActionResult Index()
        {
            var applicationDbContext = BRepo.AllBooks;
            return View(applicationDbContext.ToList());
        }

        // GET: Book/Details/5
        //[Authorize]
        public IActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var book = BRepo.GetBookById(id);
            //_context.Movies
            //.Include(m => m.Genre)
            //.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        //Create and more will go next
        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.Include(b => b.genreType).FirstOrDefaultAsync(b => b.id == id);
            if (book == null)
            {
                return NotFound();
            }
            //Selecr list with the value of id and display the genre type
            ViewData["GenreId"] = new SelectList(_context.Genres, "id", "genreType");
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,bookName,author,description,quantity,overdueFeePerDay , genreId")] Book book)
        {
            if (id != book.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.id))
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
            ViewData["genreType"] = new SelectList(_context.Genres, "id", "id");
            return View(book);
        }


        //Delete Method

        // GET: Movies/Delete/5
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.genreType)
                .FirstOrDefaultAsync(b => b.id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }


        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Books.FindAsync(id);
            _context.Books.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Create a new book
        // GET: Movies/Create
        public IActionResult Create()
        {
            //Here we are saying the select list of the create method will have value of id and display genre type
            ViewData["GenreId"] = new SelectList(_context.Genres, "id", "genreType");
            return View();
        }



        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,bookName,author,description,quantity , overdueFeePerDay , Title, ImageFile, genreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                /*
                 CODE FOR SAVING A NEW IMAGE TO WWWROOT/IMAGE
                 */
                //this accesses the path of where we will be storing the files
                //we also need to add IWebHostEnvironment to our appdbcontext constructor as that will be used to access it
                string wwwRootPath = _hostEnvironment.WebRootPath;

                //This is to generate a new file name (unique) for the image to avoid duplication before saving to image folder in wwwRoot
                string fileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                //gets the extension as we need to know the file's type
                string extension = Path.GetExtension(book.ImageFile.FileName);

                //now to put the file's name & extension together & assign it to the model
                book.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                //define the path of storage
                //Go to wwRoot, get the image folder, then add the file name to it
                string path = Path.Combine(wwwRootPath + "/image/", fileName); //Example - wwwRoot/image/exampleFile.jpg

                //to save the image
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await book.ImageFile.CopyToAsync(fileStream);
                }

                /*
                 END
                 */
                _context.Add(book);


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["GenreId"] = new SelectList(_context.Genres, book.genreType.genreType);
            return View(book);
        }


        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.id == id);
        }


    }
}
