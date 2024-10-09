# Survivor Competition API

This is a RESTful API for managing a Survivor competition application. It allows for the creation, retrieval, updating, and deletion (CRUD) of competitors and categories.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
  - [Competitor Endpoints](#competitor-endpoints)
  - [Category Endpoints](#category-endpoints)
- [Testing the API](#testing-the-api)
- [Contributing](#contributing)
- [License](#license)

## Features

- Manage competitors and categories for a Survivor competition.
- Supports CRUD operations for both competitors and categories.
- Entity relationships (one-to-many) between categories and competitors.

## Technologies Used

- .NET 6 (or later)
- Entity Framework Core
- SQL Server
- ASP.NET Core Web API

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or later)
- A SQL Server instance (local or remote)
- An IDE such as [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/survivor-competition-api.git
