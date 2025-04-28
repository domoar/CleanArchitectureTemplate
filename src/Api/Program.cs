using Api;
using Api.Middleware;
using Api.ServiceExtension;
using Application;
using Domain;
using HealthChecks.UI.Client;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region logging
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();
#endregion logging

builder.Services.AddDefaultProblemDetails();
builder.Services.AddDefaultApiVersioning();
builder.Services.AddDefaultResponseCompression();
builder.Services.AddDefaultSwaggerGeneration();

builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<Banner>();
var app = builder.Build();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseResponseCompression();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) {
  app.UseSwagger();
  app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("../swagger/v1/swagger.json", "Cleanarchitecture Template API V1");
    options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
    options.ConfigObject.AdditionalItems["syntaxHighlight"] = false;
  });
}

if (app.Environment.IsDevelopment() || app.Environment.IsStaging()) {
  app.UseDeveloperExceptionPage();
}
else {
  app.UseExceptionHandler();
}


//app.MapHealthChecks(
//  "_health",
//  new HealthCheckOptions() {
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//  });

using (var banner = app.Services.GetRequiredService<Banner>()) {
  banner.LogBanner();
}

await app.RunAsync();
