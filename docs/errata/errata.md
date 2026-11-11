**Errata** (3 items)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/tools-skills-net10/issues) or email me at markjprice (at) gmail.com.

- [Page 42 - Creating a class library for entity models using SQL Server](#page-42---creating-a-class-library-for-entity-models-using-sql-server)
- [Page 264 - Documenting a Minimal API web service using OpenAPI](#page-264---documenting-a-minimal-api-web-service-using-openapi)
- [Page 312 -  Salts](#page-312----salts)


# Page 42 - Creating a class library for entity models using SQL Server

> Thanks to Phil aka [zkazz](https://github.com/zkazz) for raising [this issue on September 10, 2026](https://github.com/markjprice/tools-skills-net10/issues/2).

In Step 6, `Initial Catalog` is missing the `C`.

Here's the complete correct command:
```shell
dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --namespace Northwind.EntityModels --data-annotations
```

# Page 264 - Documenting a Minimal API web service using OpenAPI

> Thanks to Phil aka [zkazz](https://github.com/zkazz) for raising [this issue on November 6, 2026](https://github.com/markjprice/tools-skills-net10/issues/3).

In Step 2, I wrote, "note the package reference for Microsoft’s OpenAPI package", but I should have written, "remove the version attribute from the package reference for Microsoft’s OpenAPI package because we are using CPM".

In Step 5, I show the code provided by the project template, with some parts highlighted, but the code in the book is outdated code from the previous edition written for .NET 8. 

The book shows the legacy Swagger package in `Program.cs`:
```cs
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

The updated code should use the newer Microsoft OpenAPI package:
```cs
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}
```

Also, the legacy code uses a deprecated extension method `.WithOpenApi()`. 

In Step 6, the book tells the reader, "Between the calls to `WithName` and `WithOpenApi`, add statements to further document the weather forecast endpoint, as shown highlighted in the following code:":
```diff
.WithName("GetWeatherForecast")
+ .Produces (StatusCodes.Status200OK)
+ .WithTags("Weather")
+ .WithSummary("Retrieves the current weather for a specified city")
+ .WithDescription("Provides weather details including temperature and summary for the city passed in the route parameter.")
.WithOpenApi();
```

Step 6 should say, "After the call to `WithName`, add statements to further document the weather forecast endpoint, as shown highlighted in the following code:":
```diff
.WithName("GetWeatherForecast")
+ .Produces (StatusCodes.Status200OK)
+ .WithTags("Weather")
+ .WithSummary("Retrieves the current weather for a specified city")
+ .WithDescription("Provides weather details including temperature and summary for the city passed in the route parameter.")
;
```

Step 8 should also be updated to show only the JSON document returned by the newer Microsoft OpenAPI package, not the legacy Swagger UI.

# Page 312 -  Salts

> Thanks to Phil aka [zkazz](https://github.com/zkazz) for raising [this issue on November 11, 2026](https://github.com/markjprice/tools-skills-net10/issues/5).

In the note box, I gave two links to password statistics. The first is now broken but the other still works and gives you enough of an idea to continue to make the point.
