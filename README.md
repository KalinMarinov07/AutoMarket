# AutoMarket

AutoMarket is a car listings management web application developed with ASP.NET Core MVC.

The application allows users to browse available vehicles, view detailed information about each listing, and manage car advertisements.

## Technologies

- C#
- ASP.NET Core MVC (.NET 10)
- Entity Framework Core
- Microsoft SQL Server
- Razor Views
- HTML5, CSS3, JavaScript
- Bootstrap

## Features

- Browse available car listings
- View detailed vehicle information
- Create new car listings
- Edit existing listings
- Delete listings with confirmation
- Select vehicle brand and model using dropdown menus
- Dynamically filter models based on the selected brand
- Select engine type and vehicle type
- Display vehicle images using image URLs
- Server-side form validation
- Client-side form validation

## Project Structure

The solution is organized into the following projects:

- **AutoMarket.Web** — MVC controllers, Razor views, static files and application configuration.
- **AutoMarket.Data** — Entity Framework Core DbContext, configurations and migrations.
- **AutoMarket.Data.Models** — Database entity models and enums.
- **AutoMarket.Services.Core** — Business logic and database operations.
- **AutoMarket.ViewModels** — View models used by the MVC application.
- **AutoMarket.Common** — Shared constants.

## Database Models

The application uses three main entities:

- **Brand** — Represents a vehicle manufacturer.
- **Model** — Represents a vehicle model associated with a brand.
- **CarListing** — Represents an advertisement containing vehicle specifications, price, mileage, description and image URL.

## Getting Started

### Prerequisites

Make sure you have installed:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development workload
- Microsoft SQL Server or SQL Server LocalDB

### Installation

1. Clone the repository:

   `git clone https://github.com/YOUR_USERNAME/AutoMarket.git`

2. Open the solution in Visual Studio.

3. Restore the NuGet packages.

4. Configure the database connection string.

5. Apply the Entity Framework Core migrations.

6. Set `AutoMarket.Web` as the startup project.

7. Run the application.

## Database Configuration

Configure the SQL Server connection string using the configuration key expected by the application's `DbContext`.

The application reads the database connection string from the ConnectionStrings:DefaultConnection configuration key.

Example configuration in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=AutoMarket;Trusted_Connection=True;Encrypt=False;"
}

Update the server name to match your local SQL Server installation.

For development, you can override this setting in appsettings.Development.json.

Do not commit real passwords or sensitive connection strings.

## Database Migrations

The project uses Entity Framework Core Code First migrations.

Before running the application, apply the existing migrations to create the database schema.

In Visual Studio Package Manager Console, select `AutoMarket.Data` as the default project and use the startup project `AutoMarket.Web`.

## Application Pages

| Page | Description |
|---|---|
| Home | Landing page |
| CarListing/Index | Browse all car listings |
| CarListing/Details/{id} | View vehicle details |
| CarListing/Create | Create a new listing |
| CarListing/Edit/{id} | Edit a listing |
| CarListing/Delete/{id} | Confirm listing deletion |

## Author

Developed as an educational project for the SoftUni C# Web module.
