# МойСклад C# API client
Реализация C# клиента для МойСклад API
## Поддерживаемые API
* МойСклад Remap API v1.2
## Начало работы c Remap API
### Быстрый старт
```csharp
var credentials = new MoySkladCredentials()
{
    AccessToken = "your-access-token"
    // или
    Username = "your-username",
    Password = "your-password",
};
var api = new MoySkladApi(credentials);
var response = await api.Assortment.GetAllAsync();
```
### Пользовательский HttpClient
```csharp
var httpClient = new HttpClient(new HttpClientHandler()
{
    // gZip обязателен
    AutomaticDecompression = DecompressionMethods.GZip
});
var credentials = new MoySkladCredentials()
{
    AccessToken = "your-access-token"
};
var api = new MoySkladApi(credentials, httpClient);
```
### Фильтрация
```csharp
var query = new AssortmentApiParameterBuilder();

// фильтр '='
query.Parameter(p => p.Name).Should().Be("foo");
// вложенный фильтр '='
query.Parameter(p => p.Alcoholic.Type).Should().Be(123);
// множественный фильтр '='
query.Parameter(p => p.Archived).Should().Be(true).Or.Be(false);
// фильтр '~'
query.Parameter(p => p.Article).Should().Contains("foo");
// фильтр '~='
query.Parameter(p => p.Article).Should().StartsWith("foo");
// фильтр '>=' и '<='
query.Parameter(p => p.Updated).Should()
    .BeGreaterOrEqualTo(DateTime.Parse("2020-07-10 12:00:00"))
    .And
    .BeLessOrEqualTo(DateTime.Parse("2020-07-12 12:00:00"));

// фильтр по пользовательскому полю
query.Parameter("your-custom-attribute-href").Should().Be(123);

var response = await api.Assortment.GetAllAsync(query);
```
### Сортировка
```csharp
query.Order().By(p => p.Name)
    // пользовательское поле
    .And.By("your-custom-property-name");

// по убыванию
query.Order().By(p => p.Name, OrderBy.Desc)
```
### Limit и Offset
````csharp
query.Limit(100);
query.Offset(50);
````
### Контекстный поиск
````csharp
query.Search("foo");
````
### Группировка
````csharp
query.GroupBy(GroupBy.Consignment);
````
### Expand
````csharp
query.Expand().With(p => p.Images)
    .And.With(p => p.Product)
    // вложенный
    .And.With(p => p.SalePrices.Currency)
    .And.With(p => p.BuyPrice.Currency)
    .And.With(p => p.Product.SalePrices.Currency)
    .And.With(p => p.Product.BuyPrice.Currency)
    // пользовательское поле
    .And.With("your-custom-property-name")
````
### Загрузка картинок
````csharp
var imagesResponse = await api.Product.Images.GetAllAsync(Guid.Parse("product-id"));

foreach (var image in imagesResponse.Payload.Rows)
{
    var imageDataResponse = await api.Product.Images.DownloadAsync(image);

    await using (imageDataResponse.Payload)
    {
        if (imageDataResponse.Payload is MemoryStream memoryStream)
        {
            var imageData = memoryStream.ToArray();

            // обработать изображение
        }
    }
}
````
### Получение метаданных
````csharp
await api.Product.Metadata.GetAsync();
````
### Обработка исключений
````csharp
try
{
    await _moySkladApi.Counterparty.GetAsync(counterpartyId);
}
catch (ApiException ex)
{
    // обработать код ошибки
    if (ex.ErrorCode == 404) { ... }

    // обработать ошибки
    foreach (var error in ex.Errors) { ... }

    // полное описание ошибки
    // cодержит все коды/описания по каждой ошибке из ex.Errors.
    _logger.Log(ex.Message);
}
````
## Сборка и запуск тестов
* В корневой папке в файле `build.ps1` укажите `API_LOGIN` и `API_PASSWORD`
```ps1
  build.ps1
# Enter your login and password
# $Env:API_LOGIN = "enter-your-api-login-here"
# $Env:API_PASSWORD = "enter-your-api-password-here"
```
* Запустите `build.ps1`
## Поддержка
Я открыт для любого сотрудничества и расширения функционала данного проекта. Pull requests приветствуются, однако сначала откройте issue для обсуждения.

Если вам понравился данный проект, воткните :star:
