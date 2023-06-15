# Lab 02 - Build your first API

On this lab you will create your first WebAPI using .NET 7.0. You will learn how to use the new minimal API and how to use the new dependency injection system.

Expected time to complete: 150/180 minutes

## Learning Objectives

- Create and WebAPI
- Use async programming
- Use dependency injection
- Learn about minimal API

## Instructions

- [Before you start](#before-you-start)
- [Create a new WebAPI](#create-a-new-webapi)
- [Create Transactions Service](#create-transactions-service)
- [Implement API Endpoints](#implement-api-endpoints)

### Before you start

You should use last version of your code from [Lab 02](lab02.md) as starting point or you can use the code available [here](https://github.com/theonorg/training-personal-finance/tree/lab02).

### Create a new WebAPI

Let's create a new project to implement our API. We will use the new minimal API to create our API.

1. Open a terminal and navigate to the `srv` folder.
2. Run the following command to create a new minimal API project:

    ```bash
    dotnet new webapi -o PersonalFinance.Api -minimal
    ```

3. Add this project to the solution:

    ```bash
    cd ..

    dotnet sln add src/PersonalFinance.Api/PersonalFinance.Api.csproj
    ```

4. Open the `PersonalFinance.Api.csproj` file and add `RootNamespace` property inside `PropertyGroup` tag:

    ```xml
    <RootNamespace>$$$GITHUB_USERNAME$$$.DotnetTraining.PersonalFinanceAPI</RootNamespace>
    ```

5. Open the code on your favorite code editor and start to cleanup the code. Remove code from `Program.cs` until you have something like this:

    ```csharp

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // app.UseHttpsRedirection();

    app.Run();
    ```

6. Run the application:

    ```bash
    dotnet run --project src/PersonalFinance.Api/PersonalFinance.Api.csproj
    ```

7. You should get the following output:

    ```bash
    info: Microsoft.Hosting.Lifetime[0]
        Now listening on: http://localhost:5001
    info: Microsoft.Hosting.Lifetime[0]
        Application started. Press Ctrl+C to shut down.
    info: Microsoft.Hosting.Lifetime[0]
        Hosting environment: Development
    ```

8. Copy the URL you get on the output and open it on your browser. You should get a blank page. Now navigate to `/swagger` and you should get the Swagger UI.

9. You can stop your API and now start to code needed to implement the API.

### Create Transactions Service

1. Create a service to keep the list where you'll store your transactions
2. On that service, create methods to Add, update, delete and get transactions (on this lab we only have the concept of transaction, but on the next lab we will have the concept of account)
3. On same service create a method to filter transactions by month and year
4. You should create all models needed to implement this API

### Implement API Endpoints

Now you need to create GET, POST, PUT and DELETE endpoints to manage your transactions.

To handle your service, you may add it to the dependency injection system. On this case you need a singleton service.

Then on your endpoints, you need to reference it directly as an argument of your endpoint.
