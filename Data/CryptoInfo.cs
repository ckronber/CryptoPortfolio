﻿using System.ComponentModel.DataAnnotations;
using RestSharp;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace CryptoPortfolio.Data
{
    public class CryptoInfo
    {
        [Key]
        public int CryptoId { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "The Currency ticker cannot exceed 3 characters.")]
        public string Currency { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "The Cryptocurrency Ticker value cannot exceed 6 characters.")]
        public string CryptoName { get; set; }
     
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PurchasePrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public virtual decimal CurrentPrice { get; set; }
        public decimal Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalValue { get; set; }
        public decimal? Gain => CurrentPrice / PurchasePrice;
        public decimal? GainPercent  => Gain * 100;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset? PurchaseDate { get; set; }
 
        [ForeignKey("CryptoPurchase")]
        public int? PurchaseId { get; set; }
        public virtual CryptoPurchase CryptoPurchase { get; set; }
    }
}
