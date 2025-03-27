# Backend .NET Core API Project for a Todo List

This project is the second part of my todo list app.
By running this project, it initialises a local SQL database to hold data which can be interacted with via API calls in the backend solution.

##Steps to run
1) Open the project in Visual Studio
2) Right click the TodoListRESTAPI project and click `Set as Startup Project`
3) Navigate to the `appsettings.json` file and change the Server name to your local SQL database name, by default it was set to isaacshee\\sqlexpress
     `"DevConnection": "Server = <your sql server name>; Database=TodoListRESTDb; Trusted_Connection=True; MultipleActiveResultSets=True; Encrypt=False;"`
   <br>This is needed in order to initialise the code first database via EntityFramework Core Migration, in order to store data
4) Open the Package Manager Console in VS by navigating to the top tool bar and clicking Tools > NuGet Package Manager > Package Manager Console
5) We need to run two commands in order to run the migration tool, in the terminal, run:
   i) `Add-Migration "InitialCreate"`
   ii) `Update-Database`
   If all went accordingly, you should a new database in your SQL server called 'TodoListRESTDb' with two tables, 1) EFMigrationsHistory and 2)TodoItems
6) With the backend setup, we can now run the project which will run the Swagger API on localhost:7058
   The backend is now up and running and you can even test the API calls directly without the frontend using Swagger.
