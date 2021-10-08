using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystemV4ForeignKeys.Data;
using LibrarySystemV4ForeignKeys.Models;
using LibrarySystemV4ForeignKeys.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemV4ForeignKeys.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly ShoppingCart shoppingCart;
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(IBookRepository bookRepository, ShoppingCart shoppingCart, ApplicationDbContext context)
        {
            this._context = context;
            this.shoppingCart = shoppingCart;
            this.bookRepository = bookRepository;
        }

        //might need a view for the checkout page


        //Take Books On Loan
        //Checkout logic
        [Authorize]
        public async Task<IActionResult> Checkout(string username)
        {
            var items = shoppingCart.GetShoppingCartItems(); // we get the shopping cart items


            //run a loop to add these to our loan
            foreach (var i in items)
            {
                Book b = i.Book; //We want the item (i) to be used to create a new book - i.Book
                                 //now we have our book, we want to add this to our loans

                DateTime dateTaken = DateTime.Now;//Get our current time of taking the loan

                DateTime dueDate = dateTaken.AddMonths(1); //We will give the user 1 month to return the book

                //create a loan object
                Loan loan = new Loan { bookId = b.id, username = username, dateTaken = dateTaken, dueDate = dueDate };

                //Add the Loan object to the db
                var loanAdded = _context.Add(loan);

                //save the changes
                await _context.SaveChangesAsync();

                //now to update the book in our db
                b.quantity = b.decreaseQuantity(); //decrease quantity
                _context.Update(b); //update our book
                await _context.SaveChangesAsync(); //save our changes
            }
            //NOW TO CLEAR OUR CART
            shoppingCart.ClearCart();
            //we clear the cart as the user doesn't want to take a loan of multiple items and then see them again after paying for them 

            //redirect to the current loans 
            return View("SuccessfulLoans");
        }

        // GET: ShoppingCart
        public ViewResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        // GET: ShoppingCart/Details/5
        public RedirectToActionResult AddToShoppingCart(int Id)
        {
            var selectedBook = bookRepository.AllBooks.FirstOrDefault(b => b.id == Id);

            if (selectedBook != null)
            {
                shoppingCart.AddToCart(selectedBook, 1);
            }

            return RedirectToAction("Index");
        }

        // GET: ShoppingCart/Create
        public RedirectToActionResult RemoveFromShoppingCart(int Id)
        {
            var selectedBook = bookRepository.AllBooks.FirstOrDefault(b => b.id == Id);

            if (selectedBook != null)
            {
                shoppingCart.RemoveFromCart(selectedBook);
            }

            return RedirectToAction("Index");
        }
    }
}
