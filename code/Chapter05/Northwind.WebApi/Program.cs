using Northwind.EntityModels; // To use the AddNorthwindContext method.
using Northwind.WebApi.Extensions; // To use MapGets.
using Northwind.WebApi.Middleware; // To call UseMetricsMiddleware.
using Northwind.WebApi.Services; // To use the MetricsService class.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddNorthwindContext();
builder.Services.AddSingleton<MetricsService>();

builder.AddOTelForNorthwind();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseMetricsMiddleware();

app.MapGets(); // Default pageSize: 10.

app.Run();

