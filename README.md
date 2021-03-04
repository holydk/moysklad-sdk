# МойСклад C# API client
Реализация C# клиента для МойСклад API
## Поддерживаемые API
* МойСклад Remap API v1.2
## Начало работы c Remap API
Установите [Confiti.MoySklad.Remap.Sdk NuGet Package](https://www.nuget.org/packages/Confiti.MoySklad.Remap.Sdk).
### Package Manager Console
```
> Install-Package Confiti.MoySklad.Remap.Sdk
```
### .NET CLI
```
> dotnet add package Confiti.MoySklad.Remap.Sdk
```
### Примеры
#### Быстрый старт
```csharp
var configuration = new Configuration()
{
    AccessToken = "your-access-token"
    // или
    Username = "your-username",
    Password = "your-password",
};

var customerOrderApi = new CustomerOrderApi(configuration);

var request = GetCustomerOrderRequest
{
    Id = Guid.Parse("product-id")
};
var response = await customerOrderApi.GetAsync(request);
```
#### Фильтрация
Примеры некоторых фильтров:
```csharp
// фильтр '='
request.Query.Parameter(p => p.Name).Should().Be("foo");
// вложенный фильтр '='
request.Query.Parameter(p => p.Alcoholic.Type).Should().Be(123);
// множественный фильтр '='
request.Query.Parameter(p => p.Archived).Should().Be(true).Or.Be(false);
// фильтр '~'
request.Query.Parameter(p => p.Article).Should().Contains("foo");
// фильтр '~='
request.Query.Parameter(p => p.Article).Should().StartsWith("foo");
// фильтр '>=' и '<='
request.Query.Parameter(p => p.Updated).Should()
    .BeGreaterOrEqualTo(DateTime.Parse("2020-07-10 12:00:00"))
    .And
    .BeLessOrEqualTo(DateTime.Parse("2020-07-12 12:00:00"));
```
#### Сортировка
```csharp
request.Query.Order().By(p => p.Name);
```
#### Limit и Offset
````csharp
request.Query.Limit(100);
request.Query.Offset(50);
````
#### Контекстный поиск
````csharp
request.Query.Search("foo");
````
#### Группировка
````csharp
request.Query.GroupBy(GroupBy.Consignment);
````
#### Expand
````csharp
request.Query.Expand()
    .With(p => p.Images).And
    .With(p => p.Product).And
    // вложенный
    .With(p => p.SalePrices.Currency).And
    .With(p => p.BuyPrice.Currency).And
    .With(p => p.Product.SalePrices.Currency).And
    .With(p => p.Product.BuyPrice.Currency);
````
#### Загрузка картинок
````csharp
var request = new GetImagesRequest("product-id");
var response = await productApi.Images.GetAllAsync(request);

foreach (var image in response.Rows)
{
    var imageDataRequest = new DownloadImageRequest(image);
    var imageDataResponse = await productApi.Images.DownloadAsync(imageDataRequest);

    .....
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