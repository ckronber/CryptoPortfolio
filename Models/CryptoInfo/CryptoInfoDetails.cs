using RestSharp;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Models
{
    public class CryptoInfoDetails
    {
        public int CryptoId { get; set; }
        public string Currency { get; set; }
        public string CryptoName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price => getCryptoPrice(CryptoName, Currency);
        public decimal Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalValue => Price * Amount;

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
