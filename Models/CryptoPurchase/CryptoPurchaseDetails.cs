﻿using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class CryptoPurchaseDetails
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public CryptoInfo CryptoInfo { get; set; }
    }
}
