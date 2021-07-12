using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoPortfolio.Models
{
    public class UserList
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
