﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;
public class CleanArchitectureTemplateApiFactory : WebApplicationFactory<IApiMarker>, IAsyncLifetime {
  public async Task InitializeAsync() {
    await Task.Delay(1);
    //TODO add test fixture
  }

  async Task IAsyncLifetime.DisposeAsync() {
    await Task.Delay(1);
    //TODO add test teardown
  }

  [CollectionDefinition("ApiFactory context collection")]
  public class SharedApiFactoryFixtureCollection : ICollectionFixture<CleanArchitectureTemplateApiFactory> { }
}
