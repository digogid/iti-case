using NUnit.Framework;
using ItiCaseAPI;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace ItiCaseTests
{
    public class IntegrationTest
    {
        private readonly HttpClient client;
        private readonly string getVerb = "GET";
        private readonly string validationUri = "password/isvalid";

        public IntegrationTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
            );
            client = server.CreateClient();
        }

        [Test]
        public async Task ShouldBe_Valid()
        {
            string password = "AbTp9!foo";
            var request = new HttpRequestMessage(new HttpMethod(getVerb), $"{validationUri}/{password}");
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var result = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ShouldBe_InvalidBecauseOfLength()
        {
            string password = "ab12YZ!@";
            var request = new HttpRequestMessage(new HttpMethod(getVerb), $"{validationUri}/{password}");
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var result = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ShouldBe_InvalidBecauseOfUpperCase()
        {
            string password = "abcde123!@#";
            var request = new HttpRequestMessage(new HttpMethod(getVerb), $"{validationUri}/{password}");
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var result = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ShouldBe_InvalidBecauseOfLowerCase()
        {
            string password = "123VWXYZ!@#";
            var request = new HttpRequestMessage(new HttpMethod(getVerb), $"{validationUri}/{password}");
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var result = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ShouldBe_InvalidBecauseOfDigit()
        {
            string password = "abcXYZ!@#";
            var request = new HttpRequestMessage(new HttpMethod(getVerb), $"{validationUri}/{password}");
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var result = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ShouldBe_InvalidBecauseOfSpecialCharacter()
        {
            string password = "abc123XYZ";
            var request = new HttpRequestMessage(new HttpMethod(getVerb), $"{validationUri}/{password}");
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var result = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
            Assert.IsFalse(result);
        }

        [Test]
        public async Task ShouldBe_InvalidBecauseOfEmptyPassword()
        {
            string password = "";
            var request = new HttpRequestMessage(new HttpMethod(getVerb), $"{validationUri}/{password}");
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var result = Convert.ToBoolean(await response.Content.ReadAsStringAsync());
            Assert.IsFalse(result);
        }
    }
}
