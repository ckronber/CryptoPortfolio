using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CryptoInfo
{
    public class CryptoInfoEdit
    {
        public string Currency { get; set; }
        public string CryptoName { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalValue { get; set; }
    }
}
