using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CounterpartyApiTests
    {
        private CounterpartyApi _subject;
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

            _subject = new CounterpartyApi(_credentials);
        }

        [Test]
        public async Task GetCounterpartiesAsync_should_return_status_code_200()
        {
            var request = new GetCounterpartiesRequest();
            var response = await _subject.GetAllAsync(request);

            response.StatusCode.Should().Be(200);
        }
    }
}