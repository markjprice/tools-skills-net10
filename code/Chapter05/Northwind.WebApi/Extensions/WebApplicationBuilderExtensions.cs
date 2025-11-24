using OpenTelemetry.Logs; // To use AddConsoleExporter.
using OpenTelemetry.Metrics; // To use WithMetrics.
using OpenTelemetry.Resources; // To use ResourceBuilder.
using OpenTelemetry.Trace; // To use WithTracing.

namespace Northwind.WebApi.Extensions;

public static class WebApplicationBuilderExtensions
{
  private const string serviceName = "Northwind.WebApi";

  public static WebApplicationBuilder AddOTelForNorthwind(
    this WebApplicationBuilder builder)
  {
    builder.Logging.AddOpenTelemetry(options =>
    {
      options
        .SetResourceBuilder(ResourceBuilder
          .CreateDefault().AddService(serviceName))
        .AddConsoleExporter();
    });

    builder.Services.AddOpenTelemetry()
      .ConfigureResource(resource => resource.AddService(serviceName))
      .WithTracing(tracing => tracing
        .AddAspNetCoreInstrumentation()
        .AddEntityFrameworkCoreInstrumentation()
        .AddSqlClientInstrumentation()
        .AddConsoleExporter())
      .WithMetrics(metrics => metrics
        .AddAspNetCoreInstrumentation()
        .AddConsoleExporter());

    return builder;
  }
}
