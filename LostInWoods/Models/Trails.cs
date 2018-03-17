using System.ComponentModel.DataAnnotations;
namespace LostInWoods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Description { get; set; }
 
        [Required]
        public float Length { get; set; }

        [Required]
        public int Elevation { get; set; } 

        [Required]
        public double Longitude { get; set; } 

        [Required]
        public double Latitude { get; set; } 

    }
}
