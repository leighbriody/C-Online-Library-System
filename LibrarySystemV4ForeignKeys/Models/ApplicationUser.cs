using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystemV4ForeignKeys.Models
{
    public class ApplicationUser : IdentityUser
    {

        //Other data we want to capture for our user
        [PersonalData]
        [Column(TypeName="nvarchar(100)")]
        public String FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String LastName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String Phone { get; set; }


    }
}
