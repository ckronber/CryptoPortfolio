using RestSharp;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class CryptoInfoList
    {
        public int CryptoId { get; set; }
        public string Currency { get; set; }
        public string CryptoName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public virtual decimal CurrentPrice {get; set;}
        public decimal Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalValue { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset? PurchaseDate { get; set; }
    }
}
