using LibrarySystemV4ForeignKeys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Models
{
    public class GenreRepository : IGenreRepository
    {

        private readonly ApplicationDbContext _appDbContext;

        public GenreRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Genre> AllGenres => _appDbContext.Genres;
    }
}
