# bitrix24-csharp-sdk
A C# library for the Bitrix24 REST API

# Инициализация клиента
На данный момент клиент поддерживает только 1 способ авторизации: входящий вебхук.
Инициализировать его можно следующим образом:
```C#
ILogger<Bitrix24Client> logger = ...
var client = new Bitrix24Client("<ссылка на входящий вебхук>", logger);
var bitrix24 = new Bitrix24(client);
```

# Пример получения сделки из API
```C#
int dealId = 1;
GetResponse response = bitrix24.Crm.Deals.Get(dealId, x=>x.Id, x=>x.CompanyId);
Deal deal = response.Result;
```

Если Вам требуется получить сделку с пользовательскими полями, то это можно сделать так:
```C#
public class CustomDeal: Deal
{
    [JsonProperty("UF_CRM_1642491608176")]
    public string CustomField { get; set; }
}

...

int dealId = 1;
GetResponse response = bitrix24.Crm.Deals.Get<CustomDeal>(dealId, x=>x.Id, x=>x.CustomField);
Deal deal = response.Result;
```
