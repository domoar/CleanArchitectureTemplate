namespace IntegrationsTests
{
    public class BaseIntegrationTest
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