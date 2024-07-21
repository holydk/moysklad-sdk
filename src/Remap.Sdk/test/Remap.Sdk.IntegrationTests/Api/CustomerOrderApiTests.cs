using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CustomerOrderApiTests
    {
        private MoySkladCredentials _credentials;
        private CustomerOrderApi _subject;

        [Test]
        public async Task GetCustomerOrdersAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder<CustomerOrdersQuery>();
            var response = await _subject.GetAllAsync(query);

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
            _subject = new CustomerOrderApi(new HttpClient(httpClientHandler), _credentials);
        }
    }
}