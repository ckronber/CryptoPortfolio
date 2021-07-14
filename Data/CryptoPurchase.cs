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

        public decimal TotalCryptoValue { get; set; }

        public decimal getTotalCryptoValue()
        {
            decimal PriceVal = 0;

            foreach (CryptoInfo val in CryptoInfo)
            {
                PriceVal += val.TotalValue;
            }
            return PriceVal;
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset DateAdded { get; set; }

        [ForeignKey("Portfolio")]
        public int? PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public int CryptoId { get; set; }
        public virtual List<CryptoInfo> CryptoInfo{ get; set; }
    }
}
