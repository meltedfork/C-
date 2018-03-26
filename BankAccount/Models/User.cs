using System;
using System.Collections.Generic;

namespace BankAccount.Models
{
    public abstract class BaseEntity{}
    public class User : BaseEntity
    {
        
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}    