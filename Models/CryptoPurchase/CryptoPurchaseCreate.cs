using System;
using CryptoPortfolio.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Models
{
    public class CryptoPurchaseCreate
    {
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseAmount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset PurchaseDate { get; set; }
        public virtual List<CryptoInfo> CryptoInfo { get; set; }
    }
}
