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
#### Пользовательский HttpClient
```csharp
// создайте новый HttpClient или получите из DI
var httpClient = new HttpClient();
var credentials = new MoySkladCredentials()
{
    AccessToken = "your-access-token"
};
var api = new MoySkladApi(credentials, httpClient);
```
#### Фильтрация
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

var response = await api.Assortment.GetAllAsync(query);
```
#### Сортировка
```csharp
query.Order().By(p => p.Name);
```
#### Limit и Offset
````csharp
query.Limit(100);
query.Offset(50);
````
#### Контекстный поиск
````csharp
query.Search("foo");
````
#### Группировка
````csharp
query.GroupBy(GroupBy.Consignment);
````
#### Expand
````csharp
query.Expand()
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
var response = await api.Product.Images.GetAllAsync(Guid.Parse("product-id"));

foreach (var image in response.Rows)
{
    var imageDataResponse = await api.Product.Images.DownloadAsync(image);

    .....
}
````
#### Получение метаданных
````csharp
await api.Product.Metadata.GetAsync();
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