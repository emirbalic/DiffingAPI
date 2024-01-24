using API.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace API.IntegrationTesting.ControllersTests
{
    public class DiffApplicationFactory: WebApplicationFactory<Program>
    {
        public Mock<IItemRepository> ItemRepositoryMock { get; }

        public DiffApplicationFactory()
        {
            ItemRepositoryMock = new Mock<IItemRepository>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton(ItemRepositoryMock.Object);
            });
        }
    }
}
