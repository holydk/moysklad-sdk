using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class CounterpartyApiTests
    {
        private MoySkladCredentials _credentials;
        private CounterpartyApi _subject;

        [Test]
        public async Task GetCounterpartiesAsync_should_return_status_code_200()
        {
            var query = new ApiParameterBuilder<CounterpartiesQuery>();
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
            _subject = new CounterpartyApi(new HttpClient(httpClientHandler), _credentials);
        }
    }
}