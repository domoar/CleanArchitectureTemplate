using Infrastructure.services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Infrastructure.Context;
using System;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public static class DependencyInjectionContainer {
  public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
    return services;
  }
}
