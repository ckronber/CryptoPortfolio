using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Models
{
    public class CryptoInfoEdit
    {
        public int CryptoId { get; set; }
        public int? PurchaseId { get; set; }
        [StringLength(3, ErrorMessage = "The Fiat Currency Ticker value cannot exceed 3 characters.")]
        public string Currency { get; set; }
        [StringLength(3, ErrorMessage = "The Crypto Currency Ticker value cannot exceed 3 characters.")]
        public string CryptoName { get; set; }
        public decimal Amount { get; set; }
    }
}
