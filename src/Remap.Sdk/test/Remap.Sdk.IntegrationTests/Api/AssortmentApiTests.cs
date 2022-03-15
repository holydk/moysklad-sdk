using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class AssortmentApiTests
    {
        private AssortmentApi _subject;
        private MoySkladCredentials _credentials;

        [SetUp]
        public void Init()
        {
            var account = TestAccount.Create();
            _credentials = new MoySkladCredentials()
            {
                Username = account.Username,
                Password = account.Password
            };

            _subject = new AssortmentApi(_credentials);
        }

        [Test]
        public async Task GetAssortmentAsync_should_return_status_code_200()
        {
            var request = new GetAssortmentRequest();
            request.Query.Limit(100);
            request.Query.Expand().With(m => m.Components).And.With(m => m.Components.Assortment);
            var response = await _subject.GetAllAsync(request);

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetAssortmentAsync_with_query_should_return_status_code_200()
        {
            var request = new GetAssortmentRequest();

            request.Query.Parameter(p => p.Code)
                .Should().Be("foo").Or.Be("bar");
            request.Query.Parameter(p => p.Name)
                .Should().Be("foo");
            request.Query.Parameter(p => p.Article)
                .Should().Contains("foo");
            request.Query.Parameter(p => p.Archived)
                .Should().Be(true).Or.Be(false);
            request.Query.Parameter(p => p.Updated)
                .Should().BeGreaterOrEqualTo(DateTime.Parse("2019-07-10 12:00:00")).And.BeLessOrEqualTo(DateTime.Parse("2019-07-12 12:00:00"));
            request.Query.Parameter(p => p.Weighed)
                .Should().Be(true);
            request.Query.Parameter(p => p.Alcoholic.Type)
                .Should().Be(123);
            request.Query.Parameter(p => p.StockStore)
                .Should().Be("https://online.moysklad.ru/api/remap/1.2/entity/store/59a894aa-0ea3-11ea-0a80-006c00081b5b");
            request.Query.Parameter(p => p.StockMode)
                .Should().Be(StockMode.All);
            request.Query.Parameter(p => p.QuantityMode)
                .Should().Be(QuantityMode.All);
            request.Query.Search("foo");
            request.Query.Order().By(p => p.Name);
            request.Query.Limit(100);
            request.Query.Offset(50);
            request.Query.GroupBy(GroupBy.Consignment);

            var response = await _subject.GetAllAsync(request);

            response.StatusCode.Should().Be(200);
        }
    }
}