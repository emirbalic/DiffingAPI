using API.Models;
using API.Services;
using FluentAssertions;

namespace API.Tests.ServicesTests
{
    public class DiffServiceTests
    {
        [Fact]
        public void DiffService_GetDiffResponse_ReturnsObject()
        {
            // Arrange
            var item = new Item()
            { 
                Id=1,
                Left= "AQABAQ==",
                Right= "AAABCC=="

            };

            var expected = new DiffResponse()
            {
                DiffResultType = "ContentDoNotMatch",
                Diffs = new List<Diff>
                {
                    new Diff
                    {
                        Offset = 0,
                        Length = 1
                    },
                    new Diff
                    {
                        Offset = 3,
                        Length = 2
                    }
                }
            };

            // Act 
            var result = DiffService.GetDiffResponse(item);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<DiffResponse>();
            result.Should().BeEquivalentTo(expected);

        }
    }
}
