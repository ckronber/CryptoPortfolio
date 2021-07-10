using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Models
{
    public class CryptoPurchaseDetails
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseAmount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset PurchaseDate { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual CryptoInfo CryptoInfo { get; set; }
    }
}
