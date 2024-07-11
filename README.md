# ASP.NET Core WebAPI Kurs

## M001 | Grundlagen

- [ ] Was ist Rest
- [ ] ASP.NET Core WebAPI - Grundaufbau

## M002 | Überblick und IOC

- [ ] [Dependency Injection](https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/dependency-injection) mit ServiceCollection
- [ ] Middleware

- [ ] Projektstruktur
- [ ] Erstellen eines WebAPI - Projektes
- [ ] Beispiel WheatherForcecast
- [ ] appsettings.json
- [ ] [http-files](https://learn.microsoft.com/en-us/aspnet/core/test/http-files)
- [ ] [Error Handling](https://learn.microsoft.com/en-us/aspnet/web-api/overview/error-handling/exception-handling)

## M003 | Controller und Konventionen

- [ ] DeepDive ControllerBase
- [ ] Best Practices: DI, Controller, DTOs, Mapper
- [ ] WebAPI Konventionen
- [ ] Http-Methoden (GET / POST / DELETE / PATCH)
- [ ] Erwartetede Rückgabewerte und Statuscodes
- [ ] Return Values

## M004 | Routing, MediaTypes, Async/Await

- [ ] Konventionelles [Routing](https://learn.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/)
- [ ] Attribute Routing
- [ ] Token Replacement
- [ ] Route Constraints
- [ ] [Model Binding](https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/)

- [ ] Content Negotiation
- [ ] MediaTypes & [Formatters](https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/media-formatters)

- [ ] Async/Await Pattern

- [ ] Lab Movies

## M005 | WebAPI mit EFCore

<!--
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
-->

- [ ] O/R Mapping Framework EFCore
- [ ] Code First Ansatz (Entites + DbContext)
- [ ] DB Migration

```bash
	dotnet tool install --global dotnet-ef
	dotnet ef migrations add <script-name> --project <BusinessLogic>
	dotnet ef database update --project <BusinessLogic>
	dotnet watch run
```

- [ ] Controller mit Scaffolding erstellen (Microsoft.EntityFrameworkCore.Design)
<!--
	```bash
	dotnet tool install -g dotnet-aspnet-codegenerator

	dotnet-aspnet-codegenerator controller -name YourModelController -m YourModel -dc NorthwindDbContext -outDir Controllers -udl
	```
-->

- [ ] DB First Ansatz
- [ ] [Northwind DB](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)
- [ ] LocalDB

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

- [ ] [Überblick Strategien](https://learn.microsoft.com/de-de/ef/core/testing/)
- [ ] [Unit Testing Controllers](https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api)
- [ ] Moq benutzen um Controller Dependencies zu mocken
- [ ] LocalDB benutzen

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

- [ ] HTTP Client
- [ ] Daten senden/empfangen

## M009 | OData Service

- [ ] Install-Package Microsoft.AspNetCore.OData
- [ ] [OData](https://learn.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/) konfigurieren auf Northwind DB

<!-- https://github.com/OData/AspNetCoreOData/tree/main/sample/ODataAlternateKeySample -->

## Sonstiges

- Paging
- MinimalAPI
- RateLimitation Middleware
- SignalR und Hubs
- gRPC mit ASP.NET Core als Option zu Web APIs
