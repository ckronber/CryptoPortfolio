﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CryptoInfo
{
    public class CryptoInfoList
    {
        public string Currency { get; set; }
        public string CryptoName { get; set; }
        public virtual decimal Price { get; set; }
    }
}
