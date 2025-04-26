using Application.Extensions;
using Infrastructure.Repository;
using Microsoft.Extensions.Logging;

namespace Application.Service;

public class DefaultService {
  private readonly ILogger<DefaultService> _logger;
  private readonly DefaultRepository _repository;

  public DefaultService(ILogger<DefaultService> logger, DefaultRepository repository) {
    _logger = logger;
    _repository = repository;
  }

  public async Task<object[]> FetchSomething(CancellationToken ct) {
    _logger.LogFoo();
    return await _repository.FindSomething(ct);
  }
}
