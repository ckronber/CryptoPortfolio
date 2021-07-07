using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class CryptoPortfolioEdit
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public List<string> TopCrypto { get; set; }
        public string BullBear { get; set; }
        public virtual CryptoUser CryptoUser { get; set; }
        public virtual List<CryptoPurchase> CryptoPurchase { get; set; }
    }
}
