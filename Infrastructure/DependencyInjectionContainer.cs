using Infrastructure.services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Infrastructure.context;
using System;
using Microsoft.Extensions.Logging;

namespace Infrastructure;

public static class DependencyInjectionContainer {

  const int POOL_SIZE = 1024;

  public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
    //services.AddSingleton<HealthCheckResilienceService>();

    services.AddPooledDbContextFactory<DefaultContext>((sp, options) => {
      options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        options.EnableSensitiveDataLogging(true);

      var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
      options.UseLoggerFactory(loggerFactory);
      options.LogTo(
        message => loggerFactory.CreateLogger("EFCore"),
        [DbLoggerCategory.Database.Command.Name],
        LogLevel.Information,
        DbContextLoggerOptions.SingleLine
      );

      //options.UseSqlServer(...)
    },
    POOL_SIZE
    );

    return services;
  }
}
