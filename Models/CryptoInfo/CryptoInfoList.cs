using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoPortfolio.Models
{
    public class CryptoInfoList
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
}
