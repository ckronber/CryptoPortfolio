﻿using CryptoPortfolio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class CryptoPortfolioEdit
    {
        public int PortfolioId { get; set; }
        public int CryptoUser_UserId { get; set; }
        public string Name { get; set; }
        public string BullBear { get; set; }
    }
}
