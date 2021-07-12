using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Models
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public Guid LogId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TradeMoney { get; set; }
        public string Currency { get; set; }
        public string PreferredExchange { get; set; }

    }
}
