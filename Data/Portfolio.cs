using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoPortfolio.Data
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string BullBear { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]

        public decimal TotalPortfolioValue {
            get
            {
                decimal PriceVal = 0;

                foreach (CryptoPurchase val in CryptoPurchase)
                {
                    PriceVal += val.TotalCryptoValue;
                }
                return PriceVal;
            }
        }

        [ForeignKey("CryptoUser")]
        public int? CryptoUser_UserId { get; set; }
        public virtual CryptoUser CryptoUser { get; set; }

        [ForeignKey("CryptoPurchase")]
        public int?  PurchaseId {get;set;}
        public virtual List<CryptoPurchase> CryptoPurchase { get; set; }
    }
}