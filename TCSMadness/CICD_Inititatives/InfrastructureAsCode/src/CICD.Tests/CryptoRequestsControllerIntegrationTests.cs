using CICD.Infrastructure.Domain;
using System;
using System.Net.Http;
using Xunit;

namespace CICD.Tests
{
    public class TestServerFixture : IDisposable
    {
        public HttpClient Client { get; }

        public TestServerFixture()
        {
            Client = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
        }

        public TestServerFixture(string baseAddress)
        {
            Client = new HttpClient { BaseAddress = new Uri(baseAddress), Timeout = TimeSpan.FromSeconds(5) };
            //_client.DefaultRequestHeaders.TryAddWithoutValidation("uoko-rpc-response", "1");
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }

    public class CryptoRequestsControllerIntegrationTests : IClassFixture<TestServerFixture>
    {
        private readonly HttpClient _client;

        public CryptoRequestsControllerIntegrationTests(TestServerFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async void post_then_get()
        {
            // Arrange
            var habit = new CryptoRequest
            {
                CryptoOperation = Infrastructure.Enums.CryptoOperation.Encrypt,
                InputString = "Sarabi"
            };
            // Act
            var postResponse = await _client.PostAsJsonAsync("api/cicd/registrations", habit);
            var created = await postResponse.Content.ReadAsAsync<CryptoRequest>();

            // Assert
            Assert.True(postResponse.IsSuccessStatusCode);

            Assert.Equal(habit.InputString, created.InputString);
        }
    }
}