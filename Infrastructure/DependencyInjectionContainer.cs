using Infrastructure.services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjectionContainer {
  public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
    services.AddSingleton<HealthCheckResilienceService>();
    return services;
  }
}
