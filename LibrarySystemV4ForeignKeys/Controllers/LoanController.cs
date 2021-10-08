using LibrarySystemV4ForeignKeys.Data;
using LibrarySystemV4ForeignKeys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Controllers
{
    public class LoanController : Controller
    {

        private readonly ApplicationDbContext _context;
        //need to inject the interface repositorys
        private readonly IGenreRepository GRepo;
        private readonly IBookRepository BRepo;
        private readonly ILoanRepository LRepo;
        private readonly IUserRepository URepo;

        //Methods 
        public LoanController(ILoanRepository loanRepository, IBookRepository bookRepository, IUserRepository userRepository ,  IGenreRepository genreRepository, ApplicationDbContext context)
        {
            _context = context;
            GRepo = genreRepository;
            BRepo = bookRepository;
            LRepo = loanRepository;
        }


        // GET: All Books Available For Loan

       
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

        public IActionResult SuccessfullLoan()
        {
         
            return View();
        }

        //Take Loan Method

        //Take Book On Loan
        [Authorize]
        public async Task<IActionResult> TakeLoan(int? bookId , String username)
        {
            //Should this methi


            //Get the book for the id provided
            Book book = await _context.Books.FindAsync(bookId);

            //Get the current date they are taking the loaan
            DateTime dateTaken = DateTime.Now;

            //For the due date add 1 month to current date
            DateTime dueDate = dateTaken.AddMonths(1);

            //Date returned
            //When they take the loan we want the date returned to be null as they have not returned it yet

            //Cant figure out how to set it as null so for the time being dateReturned default value will be = 00/00/0000 00:00:00
            

            //Create the loan object
            Loan testLoan = new Loan { bookId = (int)bookId, username = username  , dateTaken = dateTaken, dueDate = dueDate };

            //Add the loan object
            //We need to verify if the loan was added
            var laonAdded = _context.Add(testLoan);

            //Now if successfull we need to show user success message otherwise show error message
            //[CODE TO BE ADDED HERE ]

            await _context.SaveChangesAsync();

            //Now we need to check if the loan has gone trough then we need to decrese the quantity of the book by 
            //Some validation will of course need to be added
            //Go to take loan 
            //If quantity is available take loan and decrease quantity by 1
            //esle let the user know quantity is not available

            //Decreasing quantity of book here [VALIDATION TO BE ADDED]
            book.quantity = book.decreaseQuantity();
            _context.Update(book);
            await _context.SaveChangesAsync();

         
            return RedirectToAction(nameof(SuccessfullLoan));

        }

        //Loan Confirmed
        // POST: Movies/Delete/5
        [HttpPost, ActionName("TakeLoan")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoanConfiremd(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        //VIEW MY LOANS METHOD
        public  IActionResult MyLoans(String username)
        {
            
            if(username == null)
            {
                return NotFound();
            }

            var allUsersLoans = LRepo.AllUsersLoans(username);

            //System.InvalidOperationException: 'Lambda expression used inside Include is not valid.'
            return View(allUsersLoans.ToList());
        }

        //Return a loan action
        //What is the best return type for this method ?
        //For now we will use IActionResult
        //What would it be best for this method to return 
        //Maybe a boolean if it was returned successfully ? ? 
        public async Task<IActionResult> ReturnLoan(int? loanId)
        {
            //If the loanId passed is null we must throw the not fouind
            if (loanId == null)
            {
                return NotFound();
            }

            //Otherwise we can continue with our logic


            DateTime currentTime = DateTime.Now;
            //The loan id is passed in as a paramater
            //Set thaat loan with the loand id date returned to date time .now 

            //Get the loan
            var loan = await _context.Loans.FirstOrDefaultAsync(Loan => Loan.loanId == loanId);
            loan.dateReturned = currentTime;
            _context.Update(loan);
            await _context.SaveChangesAsync();
            //Set the date returned

            //We should then incremenr the quantity
            

            //Get the book for the id provided
            Book book = await _context.Books.FindAsync(loan.bookId);


            book.quantity = book.IncreaseQuantity();
            _context.Update(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        //THESE WILL BE ADMIN FUNCTIONLITY BELOW THEREFORE THEY WILL NEED AUTHRORISE TAG

        //All Loans
        public IActionResult AllLoans()
        {
            var applicationDbContext = LRepo.AllLoans;
            return View(applicationDbContext.ToList());
        }

        //Outstanding Loans
        //These will be all the loans where they have not yet been returned
        public IActionResult OutstandingLoans()
        {
            var applicationDbContext = LRepo.AllOutstandingLoans;
            return View(applicationDbContext.ToList());
        }

        //Returned Loans
        //These will be all the loans where they have  been returned
        public IActionResult AllReturnedLoans()
        {
            var applicationDbContext = LRepo.AllReturnedLoans;
            return View(applicationDbContext.ToList());
        }

        //Overdue Loans
        //These will be all the loans where they have not been returned and are overdue
        public IActionResult AllOverdueLoans()
        {
            var applicationDbContext = LRepo.AllOverdueLoans;
            return View(applicationDbContext.ToList());
        }


        //Late Return Loans
        //These will be all the loans where they have been returned late
        public IActionResult AllLateReturnLoans()
        {
            var applicationDbContext = LRepo.AllLateReturnLoans;
            return View(applicationDbContext.ToList());
        }

        //On time loan returns
        //These will be all the loans where they have been returned late
        public IActionResult AllOnTimeReturnLoans()
        {
            var applicationDbContext = LRepo.AllOnTimeReturnLoans;
            return View(applicationDbContext.ToList());
        }



    }
}
