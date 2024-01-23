using API.Util;
using FluentAssertions;
using System.Text;

namespace API.Tests.UtilTests
{
    public class HelperTests
    {
        private readonly string base64 = "AAAAAA==";

        [Fact]
        public void Helper_GetBytesAsString_ReturnBytes()
        {
            // Arrange
            var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(base64));

            // Act 
            var result = Helper.GetBytesAsString(decoded);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().HaveLength(4);
            result.Should().Be("0000");
        }

        [Fact]
        public void Helper_IsBase64String_ReturnBool()
        {
            // Arrange
            var wrongBase64 = "AAA==";

            // Act
            var result = Helper.IsBase64String(base64);
            var result2 = Helper.IsBase64String(wrongBase64);

            // Assert
            result.Should().BeTrue();
            result2.Should().BeFalse(); 
        }

        [Fact]
        public void Helper_ConvertBase64_ReturnString()
        {
            // Act
            var result = Helper.ConvertBase64(base64);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().BeOfType<string>();
        }
    }
}
