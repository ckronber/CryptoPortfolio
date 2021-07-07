using System.ComponentModel.DataAnnotations;
using RestSharp;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CryptoPortfolio.Data
{
    public class CryptoInfo
    {
        [Key]
        public int CryptoId { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string CryptoName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalValue { get; set; }
        public int PurchaseId { get; set; }
        public virtual CryptoPurchase CryptoPurchase { get; set; }


        // To be added later. This is a stretch goal
        //public int ExchangeId { get; set; }
        //public Exchange Exchange { get; set; }

    }

    
}
