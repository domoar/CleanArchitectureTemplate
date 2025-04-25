using Api.extensions;
using Application.Service;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.controller.v1;

[ApiController]
[Route("api/[controller]/[action]")]
[ApiVersion("1")]
[Produces("application/json")]
public class DefaultController : ControllerBase {
  private readonly ILogger<DefaultController> _logger;
  private readonly DefaultService _service;

  public DefaultController(ILogger<DefaultController> logger, DefaultService service) {
      _logger = logger;
      _service = service;
  }

  [HttpGet]
  public async Task<IActionResult> GetSomething(CancellationToken cancellationToken) {
    var result = await _service.FetchSomething(cancellationToken);
    _logger.LogFoo();
    return Ok(result);
  }

  [HttpPost]
  public async Task<IActionResult> CreateSomething( CancellationToken cancellationToken) {
    await Task.Delay(1);
    _logger.LogFoo();
    return Ok();
  }

  [HttpPut]
  public async Task<IActionResult> UpdateSomething(CancellationToken cancellationToken) {
    await Task.Delay(1);
    _logger.LogFoo();
    return Ok();
  }

  [HttpPatch("{id}")]
  public async Task<IActionResult> PatchSomething(Guid id, CancellationToken cancellationToken) {
    await Task.Delay(1);
    _logger.LogFoo();
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteSomething(Guid id, CancellationToken cancellationToken) {
    await Task.Delay(1);
    _logger.LogFoo();
    return Ok();
  }
}
