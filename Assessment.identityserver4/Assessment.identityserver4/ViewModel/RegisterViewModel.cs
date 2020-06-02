using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.ViewModel
{
    public class RegisterViewModel
    {
        public bool isTrue
        { get { return true; } }

        [Required, MaxLength(256)]
        [DisplayName("Email")]
        public string Username { get; set; }

        [Required, MaxLength(256)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(256)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password)), DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }


    }
}
