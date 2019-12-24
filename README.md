# GameStorageService - Develop
[![Build Status](https://travis-ci.com/SkyMen-Lab/GameStorageService.svg?branch=develop)](https://travis-ci.com/SkyMen-Lab/GameStorageService)

## Intro
GameStorageService is a service for manipulating with data in relation database (PostrgeSQL). It uses **.NET Core 3.1** and **ASP.NET Core Web API**

## Setup
Before you run the project, make sure you have got PostgreSQL server running, and you have [enforced HTTPS](https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.1&tabs=visual-studio)

### Database setup:
Modify `""PostgreSQL"` string in `appsettings.json` if your credentials for database is different from mine.

We use **Entity Framework Core 3.0** as [ORM](https://www.techopedia.com/definition/24200/object-relational-mapping--orm) and [Code First approach](https://entityframeworkcore.com/approach-code-first).

To start with, install EF Core CLI tools: by running following:
```
dotnet tool install --global dotnet-ef
```

Then, we need to setup migrations directory (which is by default would be located in `GameStorageService/GameStorageService`) by running the following command in GameStorageService project directory:
```
dotnet ef migrations add Init
```

After that, EF Core will generate first migration to apply to the database, and we can run the command to generate SQL query generating all the tables in our database
```
dotnet ef database update
```

by default, migration assembly is set as GameStorageService, but you can change it by modifying `.MigrationsAssembly()` parameter in `Startup.cs` : 
```cs
services.AddDbContext<DomainContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL"), builder => 
                    builder.MigrationsAssembly("GameStorageService")));
```
## Contribution
All developers are always welcome to contribute to the project and open issues and pull-requests with appropriate messages.

## License
The code is licensed under the GNU General Public License v2.0
