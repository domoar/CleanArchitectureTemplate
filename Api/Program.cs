using Application;
using Infrastructure;
using Domain;
using Api.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Services.AddDefaultProblemDetails();
builder.Services.AddDefaultApiVersioning();
builder.Services.AddDefaultResponseCompression();


builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) {
  app.UseSwagger();
  app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("../swagger/v1/swagger.json", "Cleanarchitecture Template API V1");
    options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
    options.ConfigObject.AdditionalItems["syntaxHighlight"] = false;
  });
}


await app.RunAsync();
