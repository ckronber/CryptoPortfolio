﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public Guid LogId { get; set; }
        public string PreferredExchange { get; set; }
    }
}
