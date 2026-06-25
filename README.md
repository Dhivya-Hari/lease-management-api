# Lease Management API

## About the Project

This project is the backend for the Lease Management System. It is built using ASP.NET Core Web API and provides REST APIs for managing properties, tenants, and leases.

The application uses Entity Framework Core with SQL Server to store and retrieve data. Swagger is included to make testing and exploring the APIs easier during development.

## Technologies Used

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger / OpenAPI

## Features

* Property Management API
* Tenant Management API
* Lease Management API
* CRUD operations for all modules
* SQL Server database integration
* Entity Framework Core Code-First approach
* Database migrations
* Swagger API documentation
* CORS configuration for React frontend

## Project Structure

LeaseManagement.API
│
├── Controllers
│   ├── PropertiesController.cs
│   ├── TenantsController.cs
│   └── LeasesController.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Models
│   ├── Property.cs
│   ├── Tenant.cs
│   └── Lease.cs
│
├── Migrations
│
├── Properties
│
├── Program.cs
├── appsettings.json
└── LeaseManagement.API.csproj


## Database

The project uses SQL Server with Entity Framework Core.

Database Name:

```text
LeaseManagementDB
```

The database is created using Entity Framework migrations.

## API Endpoints

### Properties

* GET /api/Properties
* POST /api/Properties
* PUT /api/Properties/{id}
* DELETE /api/Properties/{id}

### Tenants

* GET /api/Tenants
* POST /api/Tenants
* PUT /api/Tenants/{id}
* DELETE /api/Tenants/{id}

### Leases

* GET /api/Leases
* POST /api/Leases
* PUT /api/Leases/{id}
* DELETE /api/Leases/{id}

## Running the Project

Restore packages

```bash
dotnet restore
```

Run the application

```bash
dotnet run
```

Swagger will be available at:

```text
http://localhost:5251/swagger
```

## Future Improvements

Some features planned for future updates:

* JWT Authentication
* Role-based authorization
* File upload for lease documents
* Search and filtering
* Pagination
* Dashboard analytics
* Validation improvements
* Logging and exception handling

