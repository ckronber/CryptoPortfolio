﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CryptoPurchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public CryptoInfo CryptoInfo{ get; set; }
    }
}
