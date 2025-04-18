using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjectionContainer {
  public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
    return services;
  }
}
