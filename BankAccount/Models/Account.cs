using System;
using System.Collections.Generic;

namespace BankAccount.Models
{
    public abstract class BaseEntity{}
    public class Account : BaseEntity
    {
       public int AccountId { get; set; }
       public int UserId { get; set; }
       public double Transaction { get; set; }
       public DateTime TransDate { get; set; }

    }
}       