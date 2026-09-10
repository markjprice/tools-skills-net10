**Errata** (1 item)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/tools-skills-net10/issues) or email me at markjprice (at) gmail.com.

- [Page 42 - Creating a class library for entity models using SQL Server](#page-42---creating-a-class-library-for-entity-models-using-sql-server)


# Page 42 - Creating a class library for entity models using SQL Server

> Thanks to Phil aka [zkazz](https://github.com/zkazz) for raising [this issue on September 10, 2026](https://github.com/markjprice/tools-skills-net10/issues/2).

In Step 6, `Initial Catalog` is missing the `C`.

Here's the complete correct command:
```shell
dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --namespace Northwind.EntityModels --data-annotations
```
