using CryptoPortfolio.Models;
using CryptoPortfolio.Data;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CryptoPortfolio.Services
{
    public class CryptoInfoService
    {
        public bool CreateCryptoInfo(CryptoInfoCreate model)
        {
            var entity = new CryptoInfo()
            {
                CryptoName = model.CryptoName,
                Currency = model.Currency,
                PurchaseId = model.PurchaseId,
                Amount = model.Amount,
                Price = getCryptoPrice(model.CryptoName,model.Currency),
                TotalValue = getCryptoPrice(model.CryptoName, model.Currency)*model.Amount
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CryptoInfos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CryptoInfoList> GetCryptoInfo()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CryptoInfos.Select(e => new CryptoInfoList
                {
                    CryptoId = e.CryptoId,
                    CryptoName = e.CryptoName,
                    Currency = e.Currency,
                    Amount = e.Amount,
                    Price = e.Price,
                    TotalValue = e.TotalValue
                });

                return query.ToList();
            }
        }

        public CryptoInfoDetails GetCryptoInfoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CryptoInfos.Single(e => e.CryptoId == id);

                return
                    new CryptoInfoDetails
                    {
                        PurchaseId = query.PurchaseId,
                        CryptoId = query.CryptoId,
                        CryptoName = query.CryptoName,
                        Amount = query.Amount,
                        Currency = query.Currency,
                        Price = getCryptoPrice(query.CryptoName,query.Currency),
                        TotalValue = getCryptoPrice(query.CryptoName,query.Currency)*query.Amount
                    };
            }
        }

        public bool UpdateCryptoInfo(CryptoInfoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CryptoInfos.Single(e => e.CryptoId == model.CryptoId);

                entity.CryptoName = model.CryptoName;
                entity.Currency = model.Currency;
                entity.Amount = model.Amount;
                entity.PurchaseId = model.PurchaseId;
                entity.Price = getCryptoPrice(model.CryptoName, model.Currency);
                entity.TotalValue = getCryptoPrice(model.CryptoName, model.Currency) * model.Amount;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCryptoInfo(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CryptoInfos.Single(e => e.CryptoId == id);

                ctx.CryptoInfos.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public virtual decimal getCryptoPrice(string cryptoTicker, string CurrencyTicker)
        {
            string webstring = "https://min-api.cryptocompare.com/data/price?fsym=";

            webstring += cryptoTicker + "&tsyms=" + CurrencyTicker;

            var client = new RestClient(webstring);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            CryptoRead readCrypto = JsonSerializer.Deserialize<CryptoRead>(response.Content);

            return readCrypto.USD;
        }
    }

    public class CryptoRead
    {
        [JsonPropertyName("USD")]
        public decimal USD { get; set; }
        [JsonPropertyName("JPY")]
        public decimal JPY { get; set; }
        [JsonPropertyName("EUR")]
        public decimal EUR { get; set; }
        [JsonPropertyName("CNY")]
        public decimal CNY { get; set; }
        [JsonPropertyName("KRW")]
        public decimal KRW { get; set; }
        [JsonPropertyName("INR")]
        public decimal INR { get; set; }
        [JsonPropertyName("CAD")]
        public decimal CAD { get; set; }
        [JsonPropertyName("HKD")]
        public decimal HKD { get; set; }
        [JsonPropertyName("AUD")]
        public decimal AUD { get; set; }
    }
}
