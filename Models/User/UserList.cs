using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class UserList
    {
        public int UserId { get; set; }
        public Guid LogId { get; set; }
        public string Email { get; set; }
        public decimal TradeMoney { get; set; }
        public string Currency { get; set; }
        public string PreferredExchange { get; set; }
    }
}
