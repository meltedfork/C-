using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int WeddingId { get; set; }
        public int UserId { get; set; }
        public string WedOneName { get; set; }
        public string WedTwoName { get; set; }
       
        public DateTime WeddingDate { get; set; }

        public User User { get; set; }

        public List<Guest> Guests { get; set; }
 
        public Wedding()
        {
            Guests = new List<Guest>();
        }
    }
}