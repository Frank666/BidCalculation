using BidCalculation.Extensions;
using BidCalculation.Features.BidCalculator.Get;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Host.UseSerilog();
builder.Services.AddServices(config);
builder.Services.AddCoreServices();

var app = builder.Build();
SwaggerBuilderExtensions.UseSwagger(app);
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapBidEndpoint();
app.UseCors("AllowSpecificOrigin");
app.Run();
