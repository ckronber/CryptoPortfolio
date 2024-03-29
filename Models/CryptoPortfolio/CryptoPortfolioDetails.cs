﻿using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class CryptoPortfolioDetails
    {
        public int PortfolioId { get; set; }
        public int CryptoUser_UserId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalPortfolioValue
        {
            get
            {
                decimal PriceVal = 0;

                foreach (CryptoPurchase val in CryptoPurchase)
                {
                    PriceVal += val.TotalCryptoValue;
                }
                return PriceVal;
            }
        }
        public string BullBear { get; set; }
        public virtual CryptoUser CryptoUser { get; set; }
        public virtual List<CryptoPurchase> CryptoPurchase { get; set; }
    }
}
