using System;
using System.Linq;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class ReportProfitApiTests
    {
        private MoySkladCredentials _credentials;
        private ReportProfitApi _subject;

        [Test]
        public async Task GetReportProfitByProductAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();
            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);

            var response = await _subject.GetByProductAsync(query);

            response.StatusCode.Should().Be(200);
            response.Payload.Rows.FirstOrDefault()?.Assortment.Should().NotBe(null);
        }

        [Test]
        public async Task GetReportProfitByVariantAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();

            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);
            var response = await _subject.GetByVariantAsync(query);

            response.StatusCode.Should().Be(200);
            response.Payload.Rows.FirstOrDefault()?.Assortment.Should().NotBe(null);
        }

        [Test]
        public async Task GetReportProfitByEmployeeAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();

            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);
            var response = await _subject.GetByEmployeeAsync(query);

            response.StatusCode.Should().Be(200);
            response.Payload.Rows.FirstOrDefault()?.Employee.Should().NotBe(null);
        }

        [Test]
        public async Task GetReportProfitGetByCounterPartyAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();

            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);
            var response = await _subject.GetByCounterpartyAsync(query);

            response.StatusCode.Should().Be(200);
            response.Payload.Rows.FirstOrDefault()?.Counterparty.Should().NotBe(null);
        }

        [Test]
        public async Task GetReportProfitGetBySalesChannelAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder();

            query.Limit(100);
            query.MomentFrom(DateTime.Today.AddDays(-7));
            query.MomentTo(DateTime.Now);

            var response = await _subject.GetBySalesChannelAsync(query);

            response.StatusCode.Should().Be(200);
            response.Payload.Rows.FirstOrDefault()?.SalesChannel.Should().NotBe(null);
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

            _subject = new ReportProfitApi(new HttpClient(), _credentials);
        }
    }
}