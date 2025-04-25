using Infrastructure.Context;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository;

public class DefaultRepository
{
  private readonly ILogger<DefaultRepository> _logger;
  private readonly IDbContextFactory<DefaultContext> _factory;

  public DefaultRepository(ILogger<DefaultRepository> logger, IDbContextFactory<DefaultContext> factory)
  {
    _logger = logger;
    _factory = factory;
  }

  public async Task<object[]> FindSomething(CancellationToken ct)
  {
    var ctx = await _factory.CreateDbContextAsync(ct);
    _logger.LogFoo();
    return [];
  }
}
