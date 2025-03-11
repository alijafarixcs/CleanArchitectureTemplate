

## Part 1: MediatR

```bash
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
```

## Part 1: Sqliite

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite 

```
## Run Migrations
After setting up the DbContext, create the database:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
## Verify Database File
After running the migrations, mydatabase.db should appear in your project folder.

You can use DB Browser for SQLite or sqlite3 CLI to inspect the database:
```bash
sqlite3 mydatabase.db
```

Then, check tables:
```bash
.tables
```
