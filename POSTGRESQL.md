# 🌐 How to Set Up PostgreSQL with ASP.NET Core Minimal API — A Complete, Production-Ready Guide

Are you building an ASP.NET Core Minimal API and want to use **PostgreSQL** as your database? Have you been frustrated by incomplete tutorials, vague explanations, or confusing project structures?

You’re in the right place.

This post is a **complete, comprehensive, beginner-to-pro guide** for integrating PostgreSQL into an ASP.NET Core Minimal API **from scratch**, using **only one project**, and covering everything you need to know — from setup to schema seeding to migrations.

No abstractions. No in-memory hacks. No large-scale solutions. Just a clean, real, production-capable setup.

---

## 🧰 What You’ll Need

Before we dive in, make sure you have the following installed on your machine:

- [.NET SDK 8.0 or later](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- EF Core CLI tool for migrations:

```bash
dotnet tool install --global dotnet-ef
```

> If you already have `dotnet-ef` installed, you can update it using `dotnet tool update --global dotnet-ef`.

---

## 🏁 Step 1: Create Your Project

Let’s start with a clean, single-project setup using the Minimal API template.

```bash
mkdir InventoryApp
cd InventoryApp
dotnet new webapi
```

This will generate a `Program.cs`, `appsettings.json`, and some boilerplate files. You can delete the following files to keep things clean:

- `WeatherForecast.cs`
- `Controllers/WeatherForecastController.cs`

We’re not using controllers — this is a **Minimal API** app.

---

## 📦 Step 2: Add Required NuGet Packages

To use Entity Framework Core with PostgreSQL, you’ll need to add a few packages.

Run the following in your project root:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

Here’s what each one does:

- `Microsoft.EntityFrameworkCore`: core EF package.
- `Microsoft.EntityFrameworkCore.Design`: enables migrations and tooling.
- `Npgsql.EntityFrameworkCore.PostgreSQL`: PostgreSQL provider for EF Core.

---

## 🧱 Step 3: Define Your Models

Let’s now define our database entities. Create a folder called `Models` and add the following three files:

### 📄 `Models/User.cs`

```csharp
namespace InventoryApp.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
}
```

### 📄 `Models/Category.cs`

```csharp
namespace InventoryApp.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
```

### 📄 `Models/Product.cs`

```csharp
namespace InventoryApp.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string SKU { get; set; }
    public int Quantity { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public bool IsArchived { get; set; }
    public DateTime CreatedAt { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
```

Each of these classes will represent a table in the database. Notice how we set up the relationship between `Product` and `Category`.

---

## 🧠 Step 4: Create the `DbContext`

This is the bridge between your C# classes and the actual database tables.

Create a folder called `Data`, and inside it create `InventoryDbContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using InventoryApp.Models;

namespace InventoryApp.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets" },
            new Category { Id = 2, Name = "Furniture", Description = "Home and office furniture" },
            new Category { Id = 3, Name = "Clothing", Description = "Apparel and accessories" }
        );
    }
}
```

This does three things:

1. Registers the entities (`Users`, `Categories`, `Products`)
2. Enables table creation based on these models
3. Seeds 3 default categories when the database is created

---

## ⚙️ Step 5: Add PostgreSQL Connection to `appsettings.json`

Update `appsettings.json` like so:

```json
{
  "ConnectionStrings": {
    "InventoryDatabase": "Host=localhost;Port=5432;Database=inventory_db;Username=inventory_user;Password=inventory_pass"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

Replace the values with your actual PostgreSQL username, password, and database.

---

## 🧩 Step 6: Register the DbContext in `Program.cs`

Now update `Program.cs` to inject the DbContext:

```csharp
using InventoryApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("InventoryDatabase")));

var app = builder.Build();

app.MapGet("/", () => "Inventory API is running!");

app.Run();
```

This tells the application how to connect to the database, and registers the `InventoryDbContext` so it can be used via dependency injection in services or routes.

---

## 💾 Step 7: Create and Apply the Database Migrations

Now that everything is wired up, let’s generate the schema and push it to PostgreSQL.

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

What this does:

- `migrations add`: generates SQL migration files based on your models
- `database update`: applies those migrations to PostgreSQL

At this point, your `inventory_db` database should contain the `Users`, `Categories`, and `Products` tables — and the `Categories` table will have 3 seed records.

---

## 🔐 Step 8: Secure Your Credentials for Production

Instead of hardcoding your DB credentials in `appsettings.json`, use environment variables.

### ✅ Example (Linux/macOS)

```bash
export ConnectionStrings__InventoryDatabase="Host=localhost;Database=inventory_db;Username=prod_user;Password=securepass"
```

.NET will automatically override the config using this environment variable.

---

## 🧾 Step 9: .gitignore Best Practices

Make sure your `.gitignore` file includes:

```bash
**/bin/
**/obj/
*.user
*.suo
.env
appsettings.Development.json
```

You don’t want secrets or build outputs in your Git history.

---

## ✅ Final Directory Structure

```bash
InventoryApp/
├── Models/
│   ├── User.cs
│   ├── Category.cs
│   └── Product.cs
├── Data/
│   └── InventoryDbContext.cs
├── appsettings.json
├── Program.cs
├── InventoryApp.csproj
```

---

## 🎯 Recap: What We Achieved

| Feature                       | ✅ Completed |
| ----------------------------- | ------------ |
| Minimal API Project           | ✅           |
| PostgreSQL Integration        | ✅           |
| EF Core Setup                 | ✅           |
| Migrations & Database Created | ✅           |
| Seeded Categories             | ✅           |
| Secure Credential Handling    | ✅           |

You now have a real PostgreSQL-backed ASP.NET Core Minimal API application — ready for further development, testing, or deployment.

---

## 🚀 What’s Next?

Now that your data layer is solid, you can:

- Add CRUD endpoints for `User`, `Product`, and `Category`
- Connect a Blazor or React frontend
- Add services, DTOs, and validation
- Implement authentication and authorization

---

## 💬 Final Thoughts

Too many tutorials assume too much, skip important steps, or leave you with a broken app. This guide was written to be complete and functional from end to end. Whether you're building a startup backend or learning .NET for the first time, this foundation will scale with you.

If this guide saved you hours of confusion — share it with someone else who needs it. 🧠💡

Happy coding! 🧑‍💻🐘
