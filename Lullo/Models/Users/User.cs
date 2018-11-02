using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lullo.Models
{
    [Table("users")]

    public class User
    {
        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(225, ErrorMessage = "Must be a password with at least 5 Characters", MinimumLength = 5)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(225, ErrorMessage = "Must be a password with at least 5 Characters", MinimumLength = 5)]
        [Compare("Password")]
        public string ValidatePassword { get; set; }

        public Boolean IsAdmin { get; set; }

        
    }
}