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

---

## Usage

### API Endpoints

#### User Authentication

- **POST /api/auth/login**
    - No documentation available.
    
- **POST /api/auth/register**
    - No documentation available.
    
- **GET /api/auth/userdetails/{username}**
    - No documentation available.

---

#### Account

- **GET /api/Account/UserInfo**
    - No documentation available.
    
- **POST /api/Account/Logout**
    - No documentation available.
    
- **GET /api/Account/ManageInfo?returnUrl={returnUrl}&generateState={generateState}**
    - No documentation available.
    
- **POST /api/Account/ChangePassword**
    - No documentation available.
    
- **POST /api/Account/SetPassword**
    - No documentation available.
    
- **POST /api/Account/AddExternalLogin**
    - No documentation available.
    
- **POST /api/Account/RemoveLogin**
    - No documentation available.
    
- **GET /api/Account/ExternalLogin?provider={provider}&error={error}**
    - No documentation available.
    
- **GET /api/Account/ExternalLogins?returnUrl={returnUrl}&generateState={generateState}**
    - No documentation available.
    
- **POST /api/Account/Register**
    - No documentation available.
    
- **POST /api/Account/RegisterExternal**
    - No documentation available.

---

#### Books

- **GET /api/books**
    - Get list of books
    
- **GET /api/books/{id}**
    - Get book details based on id
    - **URL Parameters:**
        - id: The ID of the book.
    
- **POST /api/books/filter**
    - Get list of books based on filter condition
    - **Request Body Format:**
    
    ```json
    {
      "Author": "sample string 1",
      "Category": "sample string 2",
      "Title": "sample string 3"
    }
    ```

- **POST /api/books**
    - Insert a Book
    - **Request Body Format:**
    
    ```json
    {
      "ISBN": "sample string 2",
      "Title": "sample string 3",
      "Category": "sample string 4",
      "Author": "sample string 5",
      "Publisher": "sample string 6",
      "Price": 7.1,
      "Stock": 8,
      "YearOfPublication": "sample string 9",
      "ImageUrlSmall": "sample string 10",
      "ImageUrlMedium": "sample string 11",
      "ImageUrlLarge": "sample string 12"
    }
    ```

- **PUT /api/books**
    - Update existing Book Details
    - **Request Body Format:**
    
    ```json
    {
      "BookID": 1,
      "ISBN": "sample string 2",
      "Title": "sample string 3",
      "Category": "sample string 4",
      "Author": "sample string 5",
      "Publisher": "sample string 6",
      "Price": 7.1,
      "Stock": 8,
      "YearOfPublication": "sample string 9",
      "ImageUrlSmall": "sample string 10",
      "ImageUrlMedium": "sample string 11",
      "ImageUrlLarge": "sample string 12"
    }
    ```

- **DELETE /api/books/{id}**
    - Delete a book based on id
    - **URL Parameters:**
        - id: The ID of the book.

---

#### Order

- **GET /api/order/{id}**
    - get orders based on the userid
    
- **PATCH /api/order/{id}**
    - update the status of the order based on the orderid
    
- **GET /api/Order/all**
    - get all orders (only accessible by admin)
    
- **POST /api/Order**
    - insert a new order into the order history
---
For more details on each API endpoint, please refer to the source code comments or the API documentation.

Happy coding!
