using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Models;
using Newtonsoft.Json;
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

        [Test]
        public void Test1()
        {
            var defaultWriteSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = DefaultMoySkladContractResolver.Instance,
                Converters = ApiClient.DefaultConverters
            };

            var obj = new Variant()
            {
                Name = "test"
            };        

            var json = JsonConvert.SerializeObject(obj, defaultWriteSettings);
        }

        [Test]
        public void Test2()
        {
            var entity = new ProductFolder()
            {
                
            };
            var result = _configuration.ApiClient.Serialize(entity);
        }
    }
}