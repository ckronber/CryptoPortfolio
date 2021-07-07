using System;
using System.ComponentModel.DataAnnotations;


namespace CryptoPortfolio.Data
{
    public class CryptoUser
    {
        [Key]
        public int UserId { get; set; }
        public Guid LogId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal TradeMoney { get; set; }
        public string Currency { get; set; }
        public string PreferredExchange { get; set; }
        public int PortfolioId { get; set; }
        //public virtual Portfolio Portfolio { get; set; }
    }
}
