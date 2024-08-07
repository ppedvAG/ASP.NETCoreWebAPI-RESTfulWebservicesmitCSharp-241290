# ASP.NET Core WebAPI Kurs

## M001 | Grundlagen

- [x] Was ist Rest
- [x] ASP.NET Core WebAPI - Grundaufbau

## M002 | Überblick und IOC

- [x] [Dependency Injection](https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/dependency-injection) mit ServiceCollection
- [x] Middleware

- [x] Projektstruktur
- [x] Erstellen eines WebAPI - Projektes
- [x] Beispiel WheatherForcecast
- [x] appsettings.json
- [x] [http-files](https://learn.microsoft.com/en-us/aspnet/core/test/http-files)
- [x] [Error Handling](https://learn.microsoft.com/en-us/aspnet/web-api/overview/error-handling/exception-handling)

## M003 | Controller und Konventionen

- [x] DeepDive ControllerBase
- [x] Best Practices: DI, Controller
- [x] WebAPI Konventionen
- [x] Http-Methoden (GET / POST / DELETE / PATCH)
- [x] Erwartetede Rückgabewerte und Statuscodes
- [x] Return Values

## M004 | Routing, MediaTypes, Async/Await

- [x] Konventionelles [Routing](https://learn.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/)
- [x] Attribute Routing
- [x] Token Replacement
- [x] Route Constraints
- [x] [Model Binding](https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/)

- [x] Content Negotiation
- [x] MediaTypes & [Formatters](https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/media-formatters)

- [ ] Async/Await Pattern

- [x] Lab Movies

## M005 | WebAPI mit EFCore

<!--
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
-->

- [x] O/R Mapping Framework EFCore
- [x] Code First Ansatz (Entites + DbContext)
- [x] DB Migration
- [x] Best Practices: DTOs, Mapper

```bash
	dotnet tool install --global dotnet-ef
	dotnet ef migrations add <script-name> --project <BusinessLogic>
	dotnet ef database update --project <BusinessLogic>
	dotnet watch run
```

- [x] Controller mit Scaffolding erstellen (Microsoft.EntityFrameworkCore.Design)
<!--
	```bash
	dotnet tool install -g dotnet-aspnet-codegenerator

	dotnet-aspnet-codegenerator controller -name YourModelController -m YourModel -dc NorthwindDbContext -outDir Controllers -udl
	```
-->

- [x] DB First Ansatz
- [x] [Northwind DB](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)
- [x] LocalDB

<!--
	```bash
		SqlLocalDB create <InstanceName>
		SqlLocalDB start <InstanceName>
		SqlLocalDB info <InstanceName>

		-- Datenbank erstellen
		sqlcmd -S "(localdb)\mssqllocaldb" -Q "CREATE DATABASE NORTHWND;"

		-- Script ausführen
		sqlcmd -S "(localdb)\mssqllocaldb" -d NORTHWND -i instnwnd.sql

		-- Ausführung überprüfen
		sqlcmd -S "(localdb)\mssqllocaldb" -d NORTHWND -Q "SELECT * FROM sys.tables;"
	```
-->

## M006 | Testing

- [x] [Überblick Strategien](https://learn.microsoft.com/de-de/ef/core/testing/)
- [x] [Unit Testing Controllers](https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api)
- [x] Moq benutzen um Controller Dependencies zu mocken
- [x] LocalDB benutzen

<!-- https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/ -->

## M007 | Authentication

- [ ] JWT Bearer Token mit Claims erzeugen
- [ ] Register und Login
- [ ] Swagger konfigurieren

- [ ] Microsoft Identity Platform
- [ ] Azure Portal EntraId: Redirects, Secrets, Scopes
- [ ] User Secrets
- [ ] IdentityDbContext<AppUser>
- [ ] DB Migration
- [ ] User & Roles

<!--
    - Microsoft.Identity.Web
    - Microsoft.AspNetCore.Identity.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.Design
-->

## M008 | HTTP-Client

- [x] HTTP Client
- [x] Daten senden/empfangen mit POST, GET, UPDATE, DELETE

## M009 | OData Service

- [x] Install-Package Microsoft.AspNetCore.OData
- [x] [OData](https://learn.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/) konfigurieren auf Northwind DB

<!-- https://github.com/OData/AspNetCoreOData/tree/main/sample/ODataAlternateKeySample -->

## Sonstiges

- Paging
- MinimalAPI
- RateLimitation Middleware
- SignalR und Hubs
- gRPC mit ASP.NET Core als Option zu Web APIs
