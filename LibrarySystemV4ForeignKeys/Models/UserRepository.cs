using LibrarySystemV4ForeignKeys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public UserRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ApplicationUser> AllUsers
        {
            get
            {
                return _appDbContext.Applicationusers;
            }
        }


        //Get user by id
        public ApplicationUser GetUserById(String  UserId)
        {
            return _appDbContext.Applicationusers.FirstOrDefault(u => u.Id.Equals(UserId));

            //_appDbContext.Movies.FirstOrDefault(m => m.Id == Id);
        }
    }
}
