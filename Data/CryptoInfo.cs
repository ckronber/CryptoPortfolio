using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Data
{
    public class CryptoInfo
    {
        [Key]
        public int CryptoId { get; set; }
        [Required]
        public string Currency { get; set; }
        public int PurchaseId { get; set; }
        public string CryptoName { get; set; }
        public virtual decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalValue { get; set; }

        // To be added later. This is a stretch goal
        //public int ExchangeId { get; set; }
        //public Exchange Exchange { get; set; }
    }
}
