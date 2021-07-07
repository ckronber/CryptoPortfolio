using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class UserAdd
    {
        public Guid LogId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal TradeMoney { get; set; }
        public string Currency { get; set; }
        public string PreferredExchange { get; set; }
    }
}
