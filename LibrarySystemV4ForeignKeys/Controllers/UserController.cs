using LibrarySystemV4ForeignKeys.Data;
using LibrarySystemV4ForeignKeys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Controllers
{
    public class UserController : Controller
    {
        //injections
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        //need to inject the interface repositorys
        private readonly IGenreRepository GRepo;
        private readonly IBookRepository BRepo;
        private readonly IUserRepository URepo;

        //Constructor
        public UserController(IBookRepository bookRepository, IGenreRepository genreRepository,  IUserRepository userRepository ,    IWebHostEnvironment hostEnvironment, ApplicationDbContext context)
        {
            _context = context;
            GRepo = genreRepository;
            BRepo = bookRepository;
            URepo = userRepository;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Users
        [AllowAnonymous]
        public IActionResult IndexAnon()
        {
            var applicationDbContext = URepo.AllUsers;
            return View(applicationDbContext);
        }

        public IActionResult Index()
        {
            var applicationDbContext = URepo.AllUsers;
            return View(applicationDbContext);
        }

        //Get the user details method
     
        // GET: User/Details/
        //[Authorize]
        public IActionResult Details(String id)
        {


            var user = URepo.GetUserById(id);
           
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        //Delete User
        // GET: Movies/Delete/5
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(String id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Applicationusers.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
