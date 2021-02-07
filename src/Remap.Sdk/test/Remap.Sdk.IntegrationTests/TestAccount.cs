using System;

namespace Confiti.MoySklad.Remap.IntegrationTests
{
    public class TestAccount
    {
        public string Username { get; set;}

        public string Password { get; set;}

        public static TestAccount Create()
        {
            var username = Environment.GetEnvironmentVariable("API_LOGIN");
            var password = Environment.GetEnvironmentVariable("API_PASSWORD");

            return new TestAccount()
            {
                Username = username,
                Password = password
            };
        }
    }
}