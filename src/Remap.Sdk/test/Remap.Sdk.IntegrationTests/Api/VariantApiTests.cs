using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class VariantApiTests
    {
        private MoySkladCredentials _credentials;
        private VariantApi _subject;

        [Test]
        public async Task GetMetadataAsync_should_return_status_code_200()
        {
            var response = await _subject.Metadata.GetAsync();

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

            _subject = new VariantApi(new HttpClient(), _credentials);
        }
    }
}