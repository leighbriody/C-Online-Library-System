using LibrarySystemV4ForeignKeys.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Models
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public LoanRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       

        public IEnumerable<Loan> AllUsersLoans(String theUsername)

        {
            //Return all loans matching the username
            //Also want to include the book object as we will have to display the book name
            return _appDbContext.Loans.Include(l => l.book).Where(loan=> loan.username == theUsername);
        }


        public IEnumerable<Loan> AllLoans
        {
            get
            {
                //Make sure to include bbook when its returned as we will want to display the book name and
                //possibly other data related to the object
                return _appDbContext.Loans.Include(b => b.book);
            }
        }

        //All outstanding loans - this will return every loan in the database which has not yet been returned
        public IEnumerable<Loan> AllOutstandingLoans
        {
            get
            {
                //Make sure to include bbook when its returned as we will want to display the book name and
                //possibly other data related to the object
                return _appDbContext.Loans.Include(b => b.book).Where(loan => loan.dateReturned == null);
            }
        }


        //All returned loans - this will return every loan in the database which has not yet been returned
        public IEnumerable<Loan> AllReturnedLoans
        {
            get
            {
                //Make sure to include bbook when its returned as we will want to display the book name and
                //possibly other data related to the object
                return _appDbContext.Loans.Include(b => b.book).Where(loan => loan.dateReturned != null);
         
            }
        }

        //All overdue loans - this will return every loan which is not returned and overdue
        public IEnumerable<Loan> AllOverdueLoans 
        {
            get
            {
                //Get thhe current date time as we will be comparing it 
                DateTime currentTime = DateTime.Now;

                //Return all loans that have not been returned and the due date is less than the current date
                return _appDbContext.Loans.Include(b => b.book).Where(loan => loan.dateReturned == null && loan.dueDate < currentTime);
            }
        }


        //All late returned loans - this will return every loan which has been returned late
        public IEnumerable<Loan> AllLateReturnLoans
        {
            get
            {
                //Get thhe current date time as we will be comparing it 
                DateTime currentTime = DateTime.Now;

                //Return all loans that have not been returned and the due date is less than the current date
                return _appDbContext.Loans.Include(b => b.book).Where(loan => loan.dateReturned != null && loan.dueDate < currentTime);
            }
        }

        //All late on time return  loans - this will return every loan which has been returned on time
        public IEnumerable<Loan> AllOnTimeReturnLoans
        {
            get
            {
                //Get thhe current date time as we will be comparing it 
                DateTime currentTime = DateTime.Now;

                //Return all loans that have not been returned and the due date is less than the current date
                return _appDbContext.Loans.Include(b => b.book).Where(loan => loan.dateReturned != null && loan.dueDate > loan.dateReturned);
            }
        }

    }
}
