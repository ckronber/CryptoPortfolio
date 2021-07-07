using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Models
{
    public class UserList
    {
        public int UserId { get; set; }
        public Guid LogId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public decimal TradeMoney { get; set; }
        public string Currency { get; set; }
        public string PreferredExchange { get; set; }
    }
}
