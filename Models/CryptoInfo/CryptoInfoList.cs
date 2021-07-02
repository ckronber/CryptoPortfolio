﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CryptoInfoList
    {
        public int CryptoId { get; set; }
        public string Currency { get; set; }
        public string CryptoName { get; set; }
        public virtual decimal Price { get; set; }
    }
}
