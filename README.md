# BookBarn Backend Repository

Welcome to the BookBarn Backend Repository! This repository contains the codebase for the backend API of BookBarn, a virtual book repository management system.

## Overview

The BookBarn backend is responsible for handling various functionalities such as user authentication, book management, searching, and more.

## Technologies Used

- **Programming Language:** C#
- **Framework:** .NET Framework
- **Database:** Microsoft SQL Server

## Installation

To set up the project locally, follow these steps:

1. **Clone the Repository:** 
    ```bash
    git clone https://github.com/Mih1rGupt4/BookBarn-Backend-Repo.git
    ```

2. **Navigate to the Project Directory:** 
    ```bash
    cd BookBarn-Backend-Repo
    ```

3. **Open the Solution File:**
    - Open the `BookBarnBackend.sln` file in Visual Studio.

4. **Build the Solution:**
    - Build the solution to restore NuGet packages.

5. **Resolve Missing Roslyn Compiler:**
    - If you encounter the error "Could not find a part of the path \bin\roslyn\csc.exe" while running the backend-API application:
        - Open the NuGet Package Manager Console.
        - Run:
            ```bash
            Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
            ```

## Usage

To run the backend server locally:

- **Visual Studio:**
    - Use Visual Studio to debug the application.

- **Command Line:**
    - Build and run the application from the command line.

    ```bash
    dotnet build
    dotnet run
    ```

Happy coding!
