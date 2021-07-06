using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class CryptoInfoCreate
    {
        public int? PurchaseId { get; set; }
        public string Currency { get; set; }
        public string CryptoName { get; set; }
        public decimal Amount { get; set; }
    }
}
