using System;
using System.ComponentModel.DataAnnotations;


namespace CryptoPortfolio.Data
{
    public class CryptoUser
    {
        [Key]
        public int UserId { get; set; }
        public Guid LogId { get; set; }
        public string PreferredExchange { get; set; }
    }
}
