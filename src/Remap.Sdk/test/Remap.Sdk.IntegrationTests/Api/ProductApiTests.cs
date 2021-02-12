using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class ProductApiTests
    {
        private ProductApi _subject;
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

            _subject = new ProductApi(_configuration);
        }
    }
}