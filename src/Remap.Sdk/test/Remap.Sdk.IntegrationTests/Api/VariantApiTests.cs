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

            _subject = new VariantApi(_configuration);
        }

        [Test]
        public async Task GetMetadataAsync_should_return_status_code_200()
        {
            var response = await _subject.Metadata.GetAsync();

            response.StatusCode.Should().Be(200);
        }
    }
}