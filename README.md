
# ASP.NET Core Backend Project using Entity Framework and SQL Server

This project is an ASP.NET Core web application that demonstrates how to use Entity Framework Core with SQL Server for database operations. 

## Prerequisites

Before running the project, make sure you have installed the following:

- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet/6.0) (version 6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any SQL Server instance
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended for development)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/your-repository.git
cd your-repository
```

### 2. Configure the Database

1. Open the `appsettings.json` file located in the root of the project.
2. Update the `ConnectionStrings` section to point to your SQL Server database:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
}
```

### 3. Apply Migrations

Ensure that Entity Framework Core migrations are up to date and apply them:

```bash
dotnet ef database update
```

If no migrations exist, create one:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the Application

To run the application, execute the following command in the root directory:

```bash
dotnet run
```









