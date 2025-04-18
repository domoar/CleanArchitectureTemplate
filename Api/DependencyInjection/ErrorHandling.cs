using Api.middleware;
using Microsoft.AspNetCore.Http.Features;

namespace Api.DependencyInjection;

public static class ProblemDetailsServiceCollectionExtensions {
  //TODO use Hellang
  public static IServiceCollection AddDefaultProblemDetails(this IServiceCollection services) {
    services.AddProblemDetails(options => {
      options.CustomizeProblemDetails = context => {
        context.ProblemDetails.Instance =
            $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";

        context.ProblemDetails.Extensions.TryAdd(
            "requestId",
            context.HttpContext.TraceIdentifier);

        var activity = context.HttpContext
            .Features
            .Get<IHttpActivityFeature>()?
            .Activity;
        context.ProblemDetails.Extensions.TryAdd(
            "traceId",
            activity?.Id);
      };
    });

    services.AddExceptionHandler<ProblemExceptionHandler>();

    return services;
  }
}
