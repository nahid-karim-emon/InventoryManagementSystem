<div align="center">

# 📦 Enterprise Inventory Management System (IMS)

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-336791?style=flat&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Redis](https://img.shields.io/badge/Redis-DC382D?style=flat&logo=redis&logoColor=white)](https://redis.io/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean_Architecture-2ea44f?style=flat)]()
[![Pattern](https://img.shields.io/badge/Pattern-CQRS-blue?style=flat)]()

A high-performance, scalable RESTful API for managing enterprise inventory, suppliers, and sales. Engineered with **.NET 8**, strictly following **Clean Architecture** principles and the **CQRS** pattern to ensure maintainability and high scalability.

</div>

---

## ✨ Key Features

- **Domain-Driven Design (DDD):** Built with strict separation of concerns using Clean Architecture.
- **CQRS Pattern:** Segregation of Read and Write operations using **MediatR**.
- **Performance Optimized:** Implemented **Redis Caching** to reduce database load and speed up read queries by over 40%.
- **Secure:** Integrated with JWT-based Authentication and Role-Based Authorization.
- **Robust Database:** Uses **PostgreSQL** with Entity Framework Core for reliable data persistence.
- **Validation:** Automated input validation pipeline using **FluentValidation**.

---

## 🏗️ Project Structure (Clean Architecture)

- **`IMS.Core` (Domain Layer):** The heart of the system. Contains entities, enums, exceptions, and repository interfaces. Has no external dependencies.
- **`IMS.Application` (Application Layer):** Contains business logic, CQRS Handlers (Commands/Queries), DTOs, and Validators. Depends only on the Core layer.
- **`IMS.Infrastructure` (Data Access Layer):** Implements `DbContext`, database repositories (PostgreSQL), and caching mechanisms (Redis).
- **`IMS.Service` (Business/External Services):** Contains implementations for external concerns like JWT Token generation, Email Sending, or third-party APIs.
- **`IMS.Api` (Presentation Layer):** The ASP.NET Core Web API. Contains Controllers and Middleware. Exposes endpoints via Swagger.

---

## 🛠️ Tech Stack

- **Framework:** .NET 8, ASP.NET Core Web API
- **Language:** C# 12
- **Database:** PostgreSQL
- **Caching:** Redis
- **ORM:** Entity Framework Core 8
- **Patterns:** Clean Architecture, Repository Pattern, CQRS
- **Security:** JWT (JSON Web Tokens), BCrypt
- **Documentation:** Swagger (OpenAPI)

---

## 🚀 Getting Started

Follow these instructions to get a local copy running for development and testing.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Redis](https://redis.io/download/) (or via Docker: `docker run -d -p 6379:6379 redis`)
- An IDE (Visual Studio 2022 or VS Code)

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/nahid-karim-emon/InventoryManagementSystem.git
   cd InventoryManagementSystem
