using FluentAssertions;

namespace UnitTests
{
    public class BaseUnitTest
    {
        [Fact]
        public void True_Should_Be_True()
        {
            // Arrange
            Boolean booleanValue;

            // Act
            booleanValue = true;

            // Assert
            booleanValue.Should().BeTrue();
        }
    }
}