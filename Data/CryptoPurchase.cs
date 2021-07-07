using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CryptoPortfolio.Data
{
    public class CryptoPurchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal Gain { get; set; }
        public decimal GainPercent { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public virtual List<CryptoInfo> CryptoInfo{ get; set; }
    }
}
