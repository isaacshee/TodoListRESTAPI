# Backend .NET Core API Project for a Todo List

This project is the second part of my todo list app.
By running this project, it initialises a local SQL database to hold data which can be interacted with via API calls in the backend solution.

## Requirements
1) Visual Studio: https://visualstudio.microsoft.com/
2) SQL Server: https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms?redirectedfrom=MSDN

## Steps to run
1) Open the project in Visual Studio
   
2) Right click the TodoListRESTAPI project and click `Set as Startup Project`
 
3) Navigate to the `appsettings.json` file and change the Server name to your local SQL database name, by default it was set to isaacshee\\sqlexpress
     `"DevConnection": "Server = <your sql server name>; Database=TodoListRESTDb; Trusted_Connection=True; MultipleActiveResultSets=True; Encrypt=False;"`\
   This is needed in order to initialise the code first database via EntityFramework Core Migration, in order to store data
   
5) Open the Package Manager Console in VS by navigating to the top tool bar and clicking Tools > NuGet Package Manager > Package Manager Console
 
6) We need to run two commands in order to run the migration tool, in the terminal, run:\
   i) `Add-Migration "InitialCreate"`\
   ii) `Update-Database`\
   If all went accordingly, you should have a new database in your SQL server called 'TodoListRESTDb' with two tables, EFMigrationsHistory and TodoItems
   
7) With the backend setup, we can now run the project which will run the Swagger API on localhost:7058\
   The backend is now up and running and you can even test the API calls directly without the frontend using Swagger.

8) If you have already setup the frontend using this repo: https://github.com/isaacshee/todolist-react.git \
   Then you are ready to use the Todo List!
