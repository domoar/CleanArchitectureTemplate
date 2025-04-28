using System;
using Infrastructure.Context;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public static class DependencyInjectionContainer {
  public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
    return services;
  }
}
