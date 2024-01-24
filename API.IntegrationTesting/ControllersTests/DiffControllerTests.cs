using API.Models;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API.IntegrationTesting.ControllersTests
{
    public class DiffControllerTests: IDisposable
    {
        private DiffApplicationFactory _applicationFactory;
        private HttpClient _httpClient;

        public DiffControllerTests()
        {
            _applicationFactory = new DiffApplicationFactory();
            _httpClient = _applicationFactory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnAllItems()
        {
            
            var mockDiffs = new Item[]
            {
                new(){Id = 1, Left = "AAABBB==", Right="AAACCC==" },
                new(){Id = 2, Left = "AAAQQQ==", Right="AAAZZZ==" }
            };

            var result = _applicationFactory.ItemRepositoryMock.Setup(i => i.GetItems()).Returns(mockDiffs);

            var response = await _httpClient.GetAsync("v1/Diff");
           
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = JsonConvert.DeserializeObject<IEnumerable<Item>>(await response.Content.ReadAsStringAsync());

            Assert.Collection(data!,
             i =>
            {
                Assert.Equal("AAABBB==", i.Left);
                Assert.Equal("AAACCC==", i.Right);
            },
            i =>
            {
                Assert.Equal("AAAQQQ==", i.Left);
                Assert.Equal("AAAZZZ==", i.Right);
            }
            );
        }

        public void Dispose()
        {
            _httpClient.Dispose();
            _applicationFactory.Dispose();
        }
    }
}
