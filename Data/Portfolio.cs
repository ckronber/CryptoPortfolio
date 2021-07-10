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
        [ForeignKey("CryptoUser")]
        public int? CryptoUser_UserId { get; set; }
        public virtual CryptoUser CryptoUser {get; set;}
        //[ForeignKey("CryptoPurchase")]
        //public int? PurchaseId { get;set; }
        //public virtual List<CryptoPurchase> CryptoPurchase { get; set; }
    }
}