using System.ComponentModel.DataAnnotations;

 
namespace LoginReg.Models
{
    public abstract class BaseEntity{}
        public class User
        {
            public Reg register { get; set; }
            public Login login { get; set; }
        }
    
        public class Reg : BaseEntity
        {

        
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,40}$",
            ErrorMessage = "Only letters are allowed in the first name.")]
        public string FirstName { get; set; }
 
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,40}$",
            ErrorMessage = "Only letters are allowed in the last name.")]
        public string LastName { get; set; }      
        
        [Required]
        [RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$", 
            ErrorMessage = "Please input a valid email address.")]
        public string Email { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match.")]
        public string PasswordConfirm { get; set; }
        }
     

            
        public class Login : BaseEntity
        {
        [Required]
        [EmailAddress]
        [RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$", 
            ErrorMessage = "Please input a valid email address.")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        }
    
}
