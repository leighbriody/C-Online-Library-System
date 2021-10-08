using LibrarySystemV4ForeignKeys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemV4ForeignKeys.ViewModels
{
    public class ShoppingCartViewModel
    {

        public ShoppingCart ShoppingCart { get; set; }

        public decimal ShoppingCartTotal { get; set; }
    }
}
