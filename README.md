# Crypto Portfoloio

CryptoPurchase is a WebMVC where you can add all of your crypto purchases and has updated prices for each of the cryptocurrencies that you add even if they are on different exchanges.

[Crypto Portfolio](https://cryptoportfoliowebmvc.azurewebsites.net)

## Steps to Add CryptoCurrencies to a Portfolio
1. Register as a new user
2. Once you  have registered with an email, you will be directed towared the user information page
3. After you have entered this information you will be directed to the home page.
4. First add a Portfolio
5. Next add a Purchase with the portfolio Id
6. Next add cryptocurrencies to the purchsase created previously and add as many cryptocurrencies in this purchase
7. Now you can view the currencies in Purchase details and CrypotoInfoList and details

## Screenshots

![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

  
## Api Example with Json Deserialization

```csharp
string webstring = "https://min-api.cryptocompare.com/data/price?fsym=";

webstring += cryptoTicker + "&tsyms=" + CurrencyTicker;

var client = new RestClient(webstring);
client.Timeout = -1;
var request = new RestRequest(Method.GET);
IRestResponse response = client.Execute(request);

CryptoRead readCrypto = JsonSerializer.Deserialize<CryptoRead>(response.Content);
```
## CryptoCompare API Reference

#### Get Single CryptoCurrency

```http
  GET https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `fsym`    | `string` |  CryptoCurrency Ticker     |
| `tsyms`   | `string` |  Currency Ticker           |


  
## Lessons Learned

- Make sure to know everything about Entity Framework
- Postman is great to use for incorporating other Apis
- Projects usually take more time than you think they will

  
## Planning Documents
 - [Db Diagram](https://dbdiagram.io/d/60ede4994ed9be1c05cb4619)
 - [Planning Google Docs Document](https://docs.google.com/document/d/1yWl6uiD4cFZYBNSpcVk9DFET8Ghd718Bl_GFlchiYxk/edit?usp=sharing)
 - [Trello Board](https://trello.com/b/8xELOVls/cryptocurrency-portfolio)
  
## Authors

[@ChrisKronberg](https://www.github.com/ckronber)
