﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CryptoPortfolio
    {
        [Key]
        public int PortfolioId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public List<string> TopCrypto { get; set; }
        public string BullBear { get; set; }
        public List<CryptoPurchase> CryptoPurchase { get; set; }
    }
}