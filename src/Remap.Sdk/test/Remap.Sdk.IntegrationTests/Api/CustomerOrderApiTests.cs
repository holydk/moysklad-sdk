using System;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
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

        // [Test]
        // public async Task CreateCustomerOrderAsync_should_return_status_code_200()
        // {
        //     var order = new CustomerOrder()
        //     {
        //         Name = $"Test order {(new Random(Guid.NewGuid().GetHashCode())).Next()}",
        //         Organization = new Organization()
        //         {
        //             Meta = new Meta()
        //             {
        //                 Href = "https://online.moysklad.ru/api/remap/1.2/entity/organization/7fc72ac0-2fd7-11ea-0a80-019a0005b728",
        //                 Type = EntityType.Organization,
        //                 MediaType = "application/json"
        //             }
        //         },
        //         Agent = new Counterparty()
        //         {
        //             Meta = new Meta()
        //             {
        //                 Href = "https://online.moysklad.ru/api/remap/1.2/entity/counterparty/7fd16ed5-2fd7-11ea-0a80-019a0005b73c",
        //                 Type = EntityType.Counterparty,
        //                 MediaType = "application/json"
        //             }
        //         }
        //     };
        //     var response = await _subject.CreateCustomerOrderAsync(order);

        //     response.StatusCode.Should().Be(200);
        // }
    }
}