
# Crypto Portfoloio

CryptoPurchase is a WebMVC where you can add all of your crypto purchases and has updated prices for each of the cryptocurrencies that you add even if they are on different exchanges.


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
## Lessons Learned

- Make sure to know everything about Entity Framework
- Postman is great to use for incorporating other Apis
- Projects usually take more time than you think they will

  
## Planning Documents
 - [Db Diagram](https://dbdiagram.io/d/60ede4994ed9be1c05cb4619)
 - [Planning Google Docs Document](https://docs.google.com/document/d/1yWl6uiD4cFZYBNSpcVk9DFET8Ghd718Bl_GFlchiYxk/edit?usp=sharing)

  
## Authors

- [@ChrisKronberg](https://www.github.com/ckronber)

  
## CryptoCompare API Reference

#### Get all items

```http
  GET /api/items
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key |

#### Get item

```http
  GET /api/items/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### add(num1, num2)

Takes two numbers and returns the sum.

  
