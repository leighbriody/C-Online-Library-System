using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Models
{
    public interface IGenreRepository
    {

        IEnumerable<Genre> AllGenres { get; }
    }
}
