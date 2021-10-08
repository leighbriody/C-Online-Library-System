using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystemV4ForeignKeys.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemV4ForeignKeys.Models
{
    public interface IBookRepository
    {

        IEnumerable<Book> AllBooks { get; }

        Book GetBookById(int Id);

       
    }
}
