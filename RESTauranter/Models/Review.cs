using System;
using System.ComponentModel.DataAnnotations;


namespace RESTauranter.Models
{
    public abstract class BaseEntity{}

    public sealed class GreaterThanDateTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object visitDate)
        {
            return visitDate != null && (DateTime)visitDate < DateTime.Today;
        }
    }
    public class Review : BaseEntity
    {
        [Required]
        public int ReviewId {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Your name must be longer than 2 characters.")]
        public string UserName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "The restaurant name must be longer than 2 characters.")]
        public string PlaceName {get; set;}

        [Required]
        [MinLength(10, ErrorMessage = "The review must be longer than 10 characters.")]
        public string ReviewInfo {get; set;}

        [Required]
        [Range(1,5)]
        public int Stars {get; set;}

        [Required]
        [GreaterThanDateTime(ErrorMessage = "The date can not be in the future.")]
        [DataType(DataType.Date)]
        public DateTime VisitDate {get; set;}

    }

}

