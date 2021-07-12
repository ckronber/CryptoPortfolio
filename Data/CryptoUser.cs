using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoPortfolio.Data
{
    public class CryptoUser
    {
        [Key]
        public int UserId { get; set; }
        public Guid LogId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress,Index(IsUnique = true), StringLength(50)]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TradeMoney { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "The Cryptocurrency Ticker value cannot exceed 3 characters.")]
        public string Currency { get; set; }
        public string PreferredExchange { get; set; }
    }
}
