using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Models
{
    public interface ILoanRepository
    {
      

        //get loan by id 
        IEnumerable<Loan> AllUsersLoans(String theUsername);

        //Return loan method
        //Given the loan id this method will set the return date to the current time

        //All Loans - returns all loans in the loans table
        IEnumerable<Loan> AllLoans { get; }


        //Outstanding Loans- returns all loans which have not yet been returned
        IEnumerable<Loan> AllOutstandingLoans { get; }

        //Returned Loans- returns all loans which have  been returned
        IEnumerable<Loan> AllReturnedLoans { get; }

        //Overdue Loans- returns all loans which have not been returned , and are outside the due date
        IEnumerable<Loan> AllOverdueLoans { get; }

        //Late Returns 
        IEnumerable<Loan> AllLateReturnLoans { get; }

        //On Time Returns - all loans which have been returned inside the due date  
        IEnumerable<Loan> AllOnTimeReturnLoans { get; }

    }
}
