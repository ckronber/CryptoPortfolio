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

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalCryptoValue
        {
            get
            {
                decimal PriceVal = 0;

                foreach (CryptoInfo val in CryptoInfo)
                {
                    PriceVal += val.TotalValue;
                }
                return PriceVal;
            }
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset DateAdded { get; set; }
        public int? PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual List<CryptoInfo> CryptoInfo { get; set; }
    }
}
