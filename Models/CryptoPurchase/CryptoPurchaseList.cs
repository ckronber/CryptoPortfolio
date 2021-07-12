using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoPortfolio.Data;

namespace CryptoPortfolio.Models
{ 

    public class CryptoPurchaseList
    {
        public int PurchaseId { get; set; }
        public decimal TotalCryptoValue { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset DateAdded { get; set; }
        public int? PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual List<CryptoInfo> CryptoInfo { get; set; }
    }
}
