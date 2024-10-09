using Asp.Versioning;
using BidCalculation.Abstractions.Services;
using BidCalculation.Configuration;
using BidCalculation.Core.Features.Calculator;
using BidCalculation.Core.Services;
using FluentValidation.AspNetCore;
using Serilog;
using Serilog.Events;

namespace BidCalculation.Extensions;

public static class ServiceConfiguration
{
    private const string InitLog = "Init Bid Calculation API";
    
    public static void AddServices(this IServiceCollection services, IConfiguration config)
    {
        var backend = config.GetSection(CorsConfig.Section).Get<CorsConfig>().Localhost;
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin", b =>
            {
                b.WithOrigins(backend)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddVersioning();
        services.AddLogging();
        services.AddFluentValidationAutoValidation();
    }

    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<ICalculatorService, CommonCar>();
        services.AddScoped<ICalculatorService, LuxuryCar>();
        services.AddScoped<IBidService, BidService>();
        services.AddScoped<BidCalculator>();
    }
    
    public static void AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });
    }

    public static void AddLogging(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        Log.Information(InitLog);
    }
}