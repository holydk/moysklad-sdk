using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class ReportProfitApiTests
    {
        private MoySkladCredentials _credentials;
        private ReportProfitApi _subject;

        [Test]
        public async Task GetByCounterpartyAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();

            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);

            var response = await _subject.GetByCounterpartyAsync(query);

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetByEmployeeAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();

            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);

            var response = await _subject.GetByEmployeeAsync(query);

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetByProductAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();

            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);

            var response = await _subject.GetByProductAsync(query);

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetBySalesChannelAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();

            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);

            var response = await _subject.GetBySalesChannelAsync(query);

            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetByVariantAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();

            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);

            var response = await _subject.GetByVariantAsync(query);

            response.StatusCode.Should().Be(200);
        }

        [SetUp]
        public void Init()
        {
            var account = TestAccount.Create();
            _credentials = new MoySkladCredentials()
            {
                Username = account.Username,
                Password = account.Password
            };

            var httpClientHandler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            _subject = new ReportProfitApi(new HttpClient(httpClientHandler), _credentials);
        }
    }
}