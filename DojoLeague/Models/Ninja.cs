using System;
using System.ComponentModel.DataAnnotations;


namespace DojoLeague.Models
{
    public abstract class BaseEntity {}
    public class Ninja : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,10)]
        public int Level { get; set; }
 
        [Required]
        public string Description { get; set; }

        [Key]
        public string Dojos_Id { get; set; }

        public Dojo dojo { get; set; }

    }
}        