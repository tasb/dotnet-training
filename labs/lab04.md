# Lab 04 - Connect your API to SQL database

On this lab you will use Entity Framework Core as ORM library to connect your API to a database.

Expected time to complete: 150/180 minutes

## Learning Objectives

- Create your SQL Server database with code-first approach
- Use Entity Framework Core to connect to database
- Manage migrations
- Use dependency injection to inject your DbContext
- Connect your API to a SQL Server

## Instructions

- [Before you start](#before-you-start)
- [Add packages to your code](#add-packages-to-your-code)
- [Create your Model](#create-your-model)
- [Manage DBContext](#manage-dbcontext)
- [Update Transaction Methods](#update-transaction-methods)
- [Add Accounts Methods](#add-controllers-for-accounts)
- [Generate migrations](#generate-migrations)
- [Test your API](#test-your-api)

### Before you start

Before you start you need to have access to a SQL Server database.

You can have several options to have access to a SQL Server database:

- [Install SQL Server on your machine](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x409&culture=en-us&country=us)
- [Using a SQL Server container](https://hub.docker.com/_/microsoft-mssql-server)
- [Using a SQL Server on Azure](https://go.microsoft.com/fwlink/p/?LinkID=2161134&clcid=0x409&culture=en-us&country=us)

This lab is fully developed using a SQL Server but if you want to use another database, you can do it.

You just need to adapt the package, connection string and some specific code to your database.

You can find more details about all available providers on [Entity Framework Core documentation](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli).

To run migration, you need to have installed the [dotnet-ef tool](https://docs.microsoft.com/en-us/ef/core/cli/dotnet).

You can use this [TodoList sample](https://github.com/tasb/dotnet-training/tree/main/demos/04.efcore/todo-sample) to help you on this lab.

Finally, you may use your code from last lab but if you prefer, you can start from the code present on last session from [Lab 03](https://github.com/theonorg/training-personal-finance/tree/lab03). 

### Add packages to your code

On this lab, you will follow a code-first approach to create your database.

For that, you need to add to your API project the following packages:

- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design

Use dotnet CLI to add this packages on root folder of your PersonalFinance.API project.

### Create your Model

First thing to do is to create your model.

For this lab, you should have an Account and a Transaction model.

You should create new folder called Models on your PersonalFinance.API project and add the needed classes.

You need to create new classes instead of using the records you use on previous labs because you need to add some attributes to your properties.

The records you have on the library can be used as DTOs.

The attributes must similar and implement a One-to-Many relationship between Account and Transaction.

### Manage DBContext

Now you need to create your DBContext. Inside it you may add two `DbSet` for the two models you have.

Recall that this calls must inherit from DbContext and have a constructor that receives a DbContextOptions.

If you want to add some configuration to your models, you can do it on `OnModelCreating` method.

Then, you need to add it to your API.

For doing that, you may use dependency injection, using the `AddDbContext` method on your `Program.cs` file and before configuring your services.

### Update Transaction Methods

Now you Transaction methods inside `TransactionService` needs to be changed to use your `DbContext`.

First, you need to add `DbContext` as a parameter on your constructor.

Then, you need to change your methods to use your DbContext instead of your local collection.

Doing that, you need to change too the way you add this service to dependency injection, moving from a Singleton to a Scoped service.

On this lab we're introducing a new model (`Account`) and those have a direct link, so every transaction service must receive an `AccountID` from query string.

### Add Controllers for Accounts

Now it's time to build a service and routes for your Accounts.

Follow the same steps you used for transactions and provide CRUD operations for your Accounts.

On top of CRUD operations, you need to create a route to list all transactions from an account.

Then route should be: `GET /accounts/{id}/transactions`.

### Generate migrations

Finally, and before running your API, you need to generate migrations.

Use the tool you installed before to generate migrations.

A new migration is created using the `dotnet ef migrations add` command.

For updating your database, you need to use the `dotnet ef database update` command.

Remember that you need to provide a connection string to your database and for local development the recommended way is to use the `dotnet user-secrets` command.

### Test your API

Now it's time to test your API.

You can use several ways to do it, like directly on your browser or using external tooling like [Postman](https://www.postman.com/).

If you want, you can try to use [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) extension on VS Code (in case your using it).
