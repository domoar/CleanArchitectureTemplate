using FluentAssertions;

namespace UnitTests;

public class BaseUnitTest {
  [Fact]
  public void True_Should_Be_True() {
    // Arrange
    Boolean booleanValue;

    // Act
    booleanValue = true;

    // Assert
    booleanValue.Should().BeTrue("Expected the value to be true.");
  }

  [Theory]
  [InlineData(true)]
  public void True_Should_Be_True_ForData(bool inlineData) {
    // Arrange
    Boolean boolValue;

    // Act 
    boolValue = inlineData;

    // Assert
    Assert.True(boolValue, "Expected the value to be true.");
  }
}
