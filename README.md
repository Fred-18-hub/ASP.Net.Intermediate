# ToDoList Solution

## Overview
This solution contains multiple projects for managing a to-do list application. The projects include a web API, a console application, and a web application. The solution targets both .NET 6 and .NET 8.

## Projects
1. **ToDoList.Api**: A .NET 8 web API for managing to-do list items with user authentication.
2. **ToDoListAssignment**: A .NET 6 console application for managing to-do list items.
3. **ToDoListWithEntityFramework**: A .NET 8 console application using Entity Framework Core for data persistence.
4. **ToDoList.Web**: A web application for managing to-do list items.

## Prerequisites
- .NET 6 SDK
- .NET 8 SDK
- SQL Server (PostgreSQL)

## Getting Started

### ToDoList.Api
1. **Restore dependencies**: with the following command:
   ```bash
   dotnet restore
   ```
2. **Update the database connection string** in `appsettings.json`:
	```json
	{
	  "ConnectionStrings": {
		"DefaultConnectionPG": "YourConnectionStringHere"
	  }
	}
	```
3. **Apply database migrations**: with the following command:
   ```bash
   dotnet ef database update
   ```
4. **Run the application**: with the following command:
   ```bash
   dotnet run
   ```


## Contributing
Contributions are welcome! Please open an issue or submit a pull request.

## License
This project is licensed under the MIT License.
