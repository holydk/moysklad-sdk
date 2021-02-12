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
        private Configuration _configuration;

        [SetUp]
        public void Init()
        {
            var account = TestAccount.Create();
            _configuration = new Configuration()
            {
                Username = account.Username,
                Password = account.Password
            };

            _subject = new CustomerOrderApi(_configuration);
        }

        [Test]
        public async Task GetCustomerOrdersAsync_should_return_status_code_200()
        {
            var request = new GetCustomerOrdersRequest();
            var response = await _subject.GetAllAsync(request);

            response.StatusCode.Should().Be(200);
        }
    }
}