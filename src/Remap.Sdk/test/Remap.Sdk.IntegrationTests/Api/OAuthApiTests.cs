using System;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public class OAuthApiTests
    {
        private OAuthApi _subject;
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

            _subject = new OAuthApi(() => _credentials, () => new HttpClient());
        }

        [Test]
        public async Task ObtainTokenAsync_should_return_status_code_200_or_201()
        {
            var response = await _subject.GetAsync();

            response.StatusCode.Should().BeOneOf(200, 201);
        }

        [Test]
        public async Task ObtainTokenAsync_should_return_access_token()
        {
            var response = await _subject.GetAsync();

            response.Payload.AccessToken.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public async Task ObtainTokenAsync_with_invalid_password_should_throw_api_exception()
        {
            _credentials.Password = null;

            Func<Task> getAccessToken = () => _subject.GetAsync();
            await getAccessToken.Should().ThrowAsync<ApiException>();
        }

        [Test]
        public async Task ObtainTokenAsync_with_invalid_password_should_return_status_code_401()
        {
            _credentials.Password = null;

            try
            {
                await _subject.GetAsync();
            }
            catch (ApiException e) 
            {
                e.ErrorCode.Should().Be(401);
            }
        }
    }
}