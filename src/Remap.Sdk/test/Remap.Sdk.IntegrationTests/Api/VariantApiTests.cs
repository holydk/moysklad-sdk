using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class VariantApiTests
    {
        private VariantApi _subject;
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

            _subject = new VariantApi(() => _credentials, () => new HttpClient());
        }

        [Test]
        public async Task GetMetadataAsync_should_return_status_code_200()
        {
            var response = await _subject.Metadata.GetAsync();

            response.StatusCode.Should().Be(200);
        }
    }
}