using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CustomerOrderApiTests
    {
        private CustomerOrderApi _subject;
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

            _subject = new CustomerOrderApi(new HttpClient(), _credentials);
        }

        [Test]
        public async Task GetCustomerOrdersAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder<CustomerOrdersQuery>();
            var response = await _subject.GetAllAsync(query);

            response.StatusCode.Should().Be(200);
        }
    }
}