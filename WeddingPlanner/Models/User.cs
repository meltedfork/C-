using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public abstract class BaseEntity{}
    public class User : BaseEntity
    {
        
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public List<Guest> Guests { get; set; }
 
        public User()
        {
            Guests = new List<Guest>();
        }
    }
}