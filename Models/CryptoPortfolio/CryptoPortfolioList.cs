using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class CryptoPortfolioList
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public string BullBear { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public virtual CryptoUser CryptoUser { get; set; }
        public virtual List<CryptoPurchase> CryptoPurchase { get; set; }
    }
}
