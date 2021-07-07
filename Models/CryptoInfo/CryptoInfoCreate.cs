using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Models
{
    public class CryptoInfoCreate
    {
        public int? PurchaseId { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "The Fiat Currency Ticker value cannot exceed 3 characters.")]
        public string Currency { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "The Cryptocurrency Ticker value cannot exceed 6 characters.")]
        public string CryptoName { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
