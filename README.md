# starshot-sample-project
Sample project - using Angular and .NET Core
Technologies used:
 - Angular 8
 - .NET Core 3.1
 - EF Core, Migration & Fluent API EF Core
 - AutoMapper
 - MSSQL 

How to run the project

1. Clone the repository
2. Open the StarshotSample.sln file and restore all nuget packages
3. Run "npm install" on the ClientApp Folder of the Starshot.Web project
4. Open the appsettings.development.json and modify the connection string to point to your local db (SQL Server)
5. Run the db migration
  > dotnet ef database update
  or 
  > update-database in vs package console manager
6. Run the project
7. login using the default user seeded from migration: 
  > in this case, 
   username: admin
   password: 123456
