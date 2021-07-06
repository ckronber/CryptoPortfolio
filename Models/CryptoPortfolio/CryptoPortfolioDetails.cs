using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class CryptoPortfolioDetails
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public CryptoUser User { get; set; }
        public List<string> TopCrypto { get; set; }
        public string BullBear { get; set; }
        public List<CryptoPurchase> CryptoPurchase { get; set; }
    }
}
