using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Data
{
    public class Portfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string BullBear { get; set; }
        public virtual CryptoUser CryptoUser {get; set;}
        public virtual List<CryptoPurchase> CryptoPurchase { get; set; }
    }
}