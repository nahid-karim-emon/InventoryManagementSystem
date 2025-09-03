# Inventory Management System (IMS)

A comprehensive system for managing product inventory, built with .NET and following Clean Architecture principles. This project serves as a demonstration of a modern, scalable, and maintainable web API structure.

## Project Structure

The solution is structured based on the principles of **Clean Architecture** to ensure a separation of concerns, making the system easier to test, maintain, and scale.

-   **`IMS.Core`**: Contains the core business logic and domain entities. It has no dependencies on any other layer. This is the heart of the application.
    -   Entities (e.g., Product, Category, Warehouse)
    -   Interfaces for repositories
    -   Domain-specific exceptions

-   **`IMS.Application`**: Implements the business rules and use cases (application logic). It depends on `IMS.Core` but not on the UI or Infrastructure layers.
    -   CQRS (Commands and Queries)
    -   DTOs (Data Transfer Objects)
    -   Validation logic
    -   Interfaces for infrastructure services (e.g., IEmailSender, IDateTimeProvider)

-   **`IMS.Infrastructure`**: Contains implementations for external concerns, such as databases, email providers, file storage, etc. It depends on the `IMS.Application` layer.
    -   Entity Framework Core `DbContext`
    -   Repository implementations
    -   Implementation of external services

-   **`IMS.Api`**: The presentation layer. For this project, it's an ASP.NET Core Web API that exposes the application's functionality via RESTful endpoints. It depends on `IMS.Application` and `IMS.Infrastructure`.
    -   Controllers
    -   Middleware
    -   Dependency Injection setup

-   **`IMS.Service`**: (Optional: Describe its purpose here if it's different from the above). For example, this could contain background workers, Windows Services, or other hosted services that run alongside the API.

## Technologies Used

-   **Framework:** .NET 8 (or your version)
-   **API:** ASP.NET Core
-   **Data Access:** Entity Framework Core
-   **Architecture:** Clean Architecture, CQRS Pattern
-   **Database:** [e.g., SQL Server, PostgreSQL, SQLite - specify yours here]

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

-   [.NET SDK](https://dotnet.microsoft.com/download) (version 8 or your specific version)
-   [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or your chosen database)
-   A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation & Setup

1.  **Clone the repository:**
    ```sh
    git clone https://github.com/your-username/InventoryManagementSystem.git
    cd InventoryManagementSystem
    ```

2.  **Configure the database connection:**
    -   Open the `appsettings.Development.json` file inside the `IMS.Api` project.
    -   Update the `ConnectionStrings` section with your database credentials.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;"
    }
    ```

3.  **Apply database migrations:**
    -   Open a terminal or command prompt in the root directory of the solution.
    -   Run the Entity Framework Core migration command to create the database schema:
    ```sh
    dotnet ef database update --project IMS.Infrastructure
    ```

4.  **Run the application:**
    -   You can run the project directly from Visual Studio by setting `IMS.Api` as the startup project and pressing F5.
    -   Or, from the command line:
    ```sh
    dotnet run --project IMS.Api
    ```
    The API will be available at `https://localhost:xxxx` and `http://localhost:yyyy`.

## License

This project is licensed under the MIT License - see the `LICENSE` file for details.
