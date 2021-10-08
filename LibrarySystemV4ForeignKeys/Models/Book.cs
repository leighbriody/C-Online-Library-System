using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.Models
{
    public class Book
    {

        public int id { get; set; }

        public String bookName { get; set; }

        public String author { get; set; }


        public String description { get; set; }

        public int quantity { get; set; }

        public int overdueFeePerDay { get; set; }

        //for image (we will integrate this to the book table rather than having it on its own)
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        //for displaying the control for image uploading
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        //Testing FK
        public Genre genreType { get; set; }

        public int genreId { get; set; }


        //Methods
        public int decreaseQuantity()
        {
            return this.quantity - 1;
        }


        public int IncreaseQuantity()
        {
            return this.quantity + 1;
        }


        public int test(int bookId)
        {

            this.quantity = this.quantity - 1;

            return this.quantity;
        }

        public static implicit operator Book(int v)
        {
            throw new NotImplementedException();
        }
    }
}
