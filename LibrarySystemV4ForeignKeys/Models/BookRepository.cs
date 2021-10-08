using LibrarySystemV4ForeignKeys.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Models
{
    public class BookRepository : IBookRepository
    {
        
        private readonly ApplicationDbContext _appDbContext;

        public BookRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IEnumerable<Book> AllBooks
        {
            get
            {
                return _appDbContext.Books.Include(b => b.genreType);
            }
        }


        public Book GetBookById(int Id)
        {
            return _appDbContext.Books.Include(b => b.genreType).FirstOrDefault(b => b.id == Id);

            //_appDbContext.Movies.FirstOrDefault(m => m.Id == Id);
        }


        }



    }

