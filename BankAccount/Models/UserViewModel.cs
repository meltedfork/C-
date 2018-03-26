using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BankAccount.Models
{
    public class UserView
        {
            public RegisterUser register { get; set; }
            public LoginUser login { get; set; }
        }

    public class RegisterUser : BaseEntity
    {
       
        [Required]
        [MinLength(2)]   
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed in the first name.")]
        public string UserFirstName { get; set; }
 
        
        [Required]
        [MinLength(2)]   
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed in the last name.")]
        public string UserLastName { get; set; }
        
        
        [Required]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$", 
            ErrorMessage = "Please input a valid email address.")]
        public string Email { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match.")]
        public string PasswordConfirm { get; set; }
    }

    public class LoginUser : BaseEntity
    {

        [Required]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$", 
            ErrorMessage = "Please input a valid email address.")]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}