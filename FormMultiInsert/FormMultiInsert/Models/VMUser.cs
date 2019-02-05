using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FormMultiInsert.Models
{
    public class VMUser
    {
        [Required(ErrorMessage = "This Field is mandatory")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This Field is mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This Field is mandatory")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="This Field is mandatory")]
        public string EmailAddress { get; set; }
        public Nullable<bool> IsAdmin { get; set; }

    }
}