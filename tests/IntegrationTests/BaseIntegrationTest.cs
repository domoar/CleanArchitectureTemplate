﻿using System.Net;
using FluentAssertions;

namespace IntegrationTests;

public class BaseIntegrationTest : IClassFixture<CleanArchitectureTemplateApiFactory> {

  private readonly HttpClient _client;

  [Fact]
  public void True_Should_Be_True() {
    // Arrange
    Boolean boolValue;

    // Act
    boolValue = true;

    // Assert
    boolValue.Should().BeTrue("Expected the value to be true.");
  }

  [Theory]
  [InlineData(true)]
  public void True_Should_Be_True_ForData(bool inlineData) {
    // Arrange
    Boolean boolValue;

    // Act 
    boolValue = inlineData;

    // Assert
    boolValue.Should().BeTrue("Expected the value to be true.");
  }

  [Fact]
  public async Task UseFactory() {
    // Arrange
    string url = "";

    // Act 
    var response = await _client.GetAsync(url);

    // Assert
    response.StatusCode.Should().Be(HttpStatusCode.NotFound);
  }

  public BaseIntegrationTest(CleanArchitectureTemplateApiFactory apiFactory) {
    _client = apiFactory.CreateClient();
  }
}
