using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Models
{
    public class Loan
    {

        public Book book { get; set; }
        public int loanId { get; set; }

        public int bookId { get; set; }

        public String username { get; set; }

        [Display(Name = "Date Released")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime dateTaken { get; set; }

        [Display(Name = "Date Released")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime dueDate { get; set; }


        //When the loan has not yet been returned we want date returned to be null
        //However DateTime is not nullable so we must insert ? before it to allow nuuls
        [Display(Name = "Date Released")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? dateReturned { get; set; }
    }
}
