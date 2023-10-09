# Web1
Migration is a way to keep the database schema in sync with the EF Core model by preserving data.

Open the Package Manager Console from the menu Tools -> NuGet Package Manager -> Package Manager Console in Visual Studio and execute the following command to add a migration.

Package Manager Console
PM> Update-Database
If you are using dotnet Command Line Interface, execute the following command.

CLI
> dotnet ef database update

(Just do one of 2 ways)