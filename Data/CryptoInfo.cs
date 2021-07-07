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
        [StringLength(3, ErrorMessage = "The Currency ticker cannot exceed 3 characters.")]
        public string Currency { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "The Cryptocurrency Ticker value cannot exceed 6 characters.")]
        public string CryptoName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
        public decimal TotalValue { get; set; }
        public int? PurchaseId { get; set; }
        public virtual CryptoPurchase CryptoPurchase { get; set; }

        // To be added later. This is a stretch goal
        //public int ExchangeId { get; set; }
        //public Exchange Exchange { get; set; }
    }
}
