
# Portfolio API

## Overview

The **Portfolio API** is a .NET-based service that retrieves and displays GitHub repositories, allowing developers to showcase their projects on their personal websites. It connects to a user's GitHub account, fetches repository details, and provides advanced search capabilities.  

## Features

- **Portfolio Retrieval:** Fetches a developer's GitHub repositories, including:
  - Programming languages used
  - Last commit date
  - Number of stars
  - Number of pull requests
  - Repository link  

- **General Repository Search:** Allows searching across **public** GitHub repositories with filters:
  - Repository name
  - Programming language
  - GitHub username  

## Technologies Used

- **.NET Core Web API** – Backend framework.
- **Octokit.NET** – GitHub API client for .NET.
- **Scrutor** – Extends .NET dependency injection with service decoration.
- **MemoryCache** – Used to optimize GitHub API requests.

## Project Structure

The solution consists of:

1. **Service Layer (`IGitHubService`)** – Handles GitHub API calls.
2. **Cache Layer (`CacheGitHubService`)** – Implements caching to minimize GitHub API usage.
3. **Web API (`PortfolioController`)** – Exposes endpoints for retrieving portfolio data.

## Getting Started

1. **Clone the Repository:**
   ```sh
   git clone https://github.com/rivki-beker/portfolio-API.git
   cd portfolio-API
   ```

2. **Restore Dependencies:**
   ```sh
   dotnet restore
   ```

3. **Build the Solution:**
   ```sh
   dotnet build
   ```

4. **Run the Application:**
   ```sh
   dotnet run --project WebAPI
   ```
   The API is now available at `https://localhost:5001`.

## API Endpoints

### 1. Get Portfolio (Cached)
- **Endpoint:** `/api/portfolio`
- **Method:** `GET`
- **Response:**
  ```json
  [
    {
      "name": "Repo Name",
      "description": "Project Description",
      "url": "https://github.com/username/repo",
      "stars": 10,
      "language": "C#",
      "lastCommit": "2025-02-05T03:06:19Z",
      "pullRequests": 5
    }
  ]
  ```

### 2. Search Public Repositories
- **Endpoint:** `/api/search`
- **Method:** `GET`
- **Query Parameters:**  
  - `repositoryName` (optional) – Filter by name.
  - `language` (optional) – Filter by language.
  - `userName` (optional) – Filter by owner.

## Additional Resources

- [Octokit.NET Documentation](https://octokitnet.readthedocs.io/en/latest)
- [.NET Dependency Injection & Scrutor](https://andrewlock.net/using-scrutor-to-automatically-register-your-services-with-the-asp-net-core-di-container/)
- [.NET Memory Caching](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory)

## Contributing

Contributions are welcome! Please fork the repo and submit a **pull request**.
