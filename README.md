# bitrix24-csharp-sdk
A C# library for the Bitrix24 REST API

## Инициализация клиента
На данный момент клиент поддерживает только один способ авторизации: входящий вебхук.
Инициализировать его можно следующим образом:
```C#
ILogger<Bitrix24Client> logger = ...
var client = new Bitrix24Client("<ссылка на входящий вебхук>", logger);
var bitrix24 = new Bitrix24(client);
```

## Возможности и структура клиента
На данный момент клиент поддерживает частично работу с сделками, лидами, контактами, компаниями и пользователями.

Для всех этих сущностей реализовано создание, изменение, удаление, вывод списка, получение по идентификатору и получение списка полей.

Вывод списка поддерживает сортировку, фильтрацию и выборку указанных полей.
В фильтрации реализовано сопоставление по знаку равенства. Остальные(больше, меньше, Like-подобная операция) - в стадии разработки.

Создание и удаление поддерживают все операции кроме изменения и удаления телефонов и почт.

Для удобства пользования библиотекой некоторые свойства в модели битрикса приведены к более удобному для использования формату.
Для примера тип ```char``` с возможными значениями ```Y``` и ```N``` приведен к типу bool. 
Причем это преобразование работает как при чтении, так и при записи сущностей в API.

Чтобы было легче ориентироваться в библиотеке и искать нужную сущность, в библиотеке по возможности сохранена та структура, которая есть в документации к REST API битрикс24.
Ниже представлена текущая структура клиента:
```
Bitrix24.Crm
            .Deals
                .Add(...)
                .Add<TEntity>(...)
                .Update(...)
                .Update<TEntity>(...)
                .Get(...)
                .Get<TEntity>(...)
                .Delete(...)
                .List(...)
                .List<TEntity>(...)
                .First(...)
                .First<TEntity>(...)
            .Leads
                ...
            .Contacts
                ...
            .Companies
                ...
            .Timeline
                .Comments
                    .Add(...)
Bitrix24.Users
            .Add(...)
            .Add<TEntity>(...)
            .Update(...)
            .Update<TEntity>(...)
            .Get(...)
            .Get<TEntity>(...)
            .Delete(...)
            .Search(...)
            .Search<TEntity>(...)
            .First(...)
            .First<TEntity>(...)
```

## Пример получения сделки из API
```C#
int dealId = 1;
GetResponse response = await bitrix24.Crm.Deals.Get(dealId, x=>x.Id, x=>x.CompanyId);
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
GetResponse response = await bitrix24.Crm.Deals.Get<CustomDeal>(dealId, x=>x.Id, x=>x.CustomField);
Deal deal = response.Result;
```

## Пример удаления сделки
```C#
int dealId = 1;
DeleteResponse response = await bitrix24.Crm.Deals.Delete(dealId);
bool isDeleted = response.Result;
```

## Пример создания сделки
```C#
AddResponse response = await bitrix24.Crm.Deals.Add(x=>x
   .SetField(x=>x.CompanyId, 1)
   .AddEmails(x=>x
      .SetField("work@test.ru", EmailType.Рабочий)
      .SetField("other@test.ru", EmailType.Другой))
   .AddEmails(x => x
     .SetField("+79222444333", EmailType.Рабочий)
     .SetField("+79222444333", EmailType.Другой)));
     
int dealId = response.Result;
```

И вариант с пользовательскими полями:
```C#
public class CustomDeal: Deal
{
    [JsonProperty("UF_CRM_1642491608176")]
    public string CustomField { get; set; }
}

...

AddResponse response = await bitrix24.Crm.Deals.Add<CustomDeal>(x=>x
   .SetField(x=>x.CustomField, "1"));
     
int dealId = response.Result;
```

## Пример изменения сделки
```C#
int dealId = 1;

AddResponse response = await bitrix24.Crm.Deals.Update(dealId, x=>x
   .SetField(x=>x.CompanyId, 1)
   .AddEmails(x=>x
      .SetField("work@test.ru", EmailType.Рабочий)
      .SetField("other@test.ru", EmailType.Другой))
   .AddEmails(x => x
     .SetField("+79222444333", EmailType.Рабочий)
     .SetField("+79222444333", EmailType.Другой)));
     
int dealId = response.Result;
```

И вариант с пользовательскими полями:
```C#
public class CustomDeal: Deal
{
    [JsonProperty("UF_CRM_1642491608176")]
    public string CustomField { get; set; }
}

...

int dealId = 1;

AddResponse response = await bitrix24.Crm.Deals.Update<CustomDeal>(dealId, x=>x
   .SetField(x=>x.CustomField, "1"));
     
int dealId = response.Result;
```
