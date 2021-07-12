using RestSharp;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System;

namespace CryptoPortfolio.Models
{
    public class CryptoInfoDetails
    {
        public int CryptoId { get; set; }
        public int? PurchaseId { get; set; }
        public string Currency { get; set; }
        public string CryptoName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal CurrentPrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PurchasePrice { get; set; }
        public decimal Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalValue { get; set; }

        public decimal? Gain { 
            get
            {
                if (PurchasePrice > 0)
                    return CurrentPrice / PurchasePrice;
                else
                    return null;
            }
        }
        public decimal? GainPercent => Gain * 100;
    }
}
