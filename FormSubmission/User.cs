using System.ComponentModel.DataAnnotations;

 
namespace FormSubmission.Models
{
    public abstract class BaseEntity{}

    public class User : BaseEntity
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{4,40}$",
            ErrorMessage = "Only letters are allowed in the first name.")]
        public string firstname { get; set; }
 
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{4,40}$",
            ErrorMessage = "Only letters are allowed in the last name.")]
        public string lastname { get; set; }      

        [Required]
        [Range(0, 110)]
        public int age { get; set; }
        
        [Required]
        [EmailAddress]
        public string email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
