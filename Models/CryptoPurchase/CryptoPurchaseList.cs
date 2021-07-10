﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoPortfolio.Data;

namespace CryptoPortfolio.Models
{ 

    public class CryptoPurchaseList
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseAmount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset PurchaseDate { get; set; }
        public virtual Portfolio Portfolio { get; set; }
    }
}
