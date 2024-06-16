using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
	public class RetailShiftApiTests
	{
		private MoySkladCredentials _credentials;
		private RetailShiftApi _subject;

		[Test]
		public async Task GetAllAsync_should_return_status_code_200()
		{
			var query = new ApiParameterBuilder();
			query.Order().By("moment", OrderBy.Desc);
			query.Limit(100);
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
			_subject = new RetailShiftApi(new HttpClient(httpClientHandler), _credentials);
		}
	}
}