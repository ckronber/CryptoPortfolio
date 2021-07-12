using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoPortfolio.Data
{
    public class CryptoPurchase
    {
        [Key]
        public int PurchaseId { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalPurchasePrice { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset DateAdded { get; set; }

        [ForeignKey("Portfolio")]
        public int? PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual List<CryptoInfo> CryptoInfo{ get; set; }
    }
}
