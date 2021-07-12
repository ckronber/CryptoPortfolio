using System;
using CryptoPortfolio.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Models
{
    public class CryptoPurchaseCreate
    {
       // [DisplayFormat(DataFormatString = "{0:C}")]
        //public decimal TotalCryptoValue { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset DateAdded  => DateTimeOffset.Now;
        public int? PortfolioId { get; set; }
        //public List<Portfolio> Portfolios { get; set; }
    }
}
