# Lab 05 - Run Unit Tests on your WebAPI

On this lab you will use create unit tests for your API.

Expected time to complete: 150/180 minutes

## Learning Objectives

- Create a unit test
- Use dependency injection for make unit testing easier
- Create a mock for your database
- Run dotnet test
- Get code coverage

## Instructions

- [Before you start](#before-you-start)
- [Create Unit Testing project](#create-unit-testing-project)
- [Prepare your projects](#prepare-your-projects)
- [Add mock for your web api](#add-mock-for-your-web-api)
- [Add your unit tests](#add-your-unit-tests)
- [Generate code coverage report](#generate-code-coverage-report)

### Before you start

Before you start you need to install [ReportGenerator](https://github.com/danielpalme/ReportGenerator) to get your code coverage report in HTML format.

To install it, you can use the following command:

```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

Now you have it available on your console.

You can use this [Echo APP sample](https://github.com/theonorg/echo-api) to help you on this lab.

Finally, you may use your code from last lab but if you prefer, you can start from the code present on last session from [Lab 04](https://github.com/theonorg/training-personal-finance/tree/lab04).

### Create Unit Testing project

Navigate to your solution folder and create a new project using the following command:

```bash
dotnet new xunit -o src/PersonalFinance.API.Tests
```

You can navigate to your new project folder and run the following command to check if everything is working:

```bash
dotnet test
```

You should get a message saying that 0 tests were run but you should not get any error.

### Prepare your projects

As discussed on last session, you should expose internals of your Web API project to be able to test it.

Edit your PersonalFinance.API.csproj file and add the following line:

```xml
  <ItemGroup>
    <InternalsVisibleTo Include="PersonalFinance.API.Tests" />
  </ItemGroup>
```

Now you need to add a reference to your API project on your test project.

Edit your PersonalFinance.API.Tests.csproj file and add the following line:

```xml
  <ItemGroup>
    <ProjectReference Include="..\PersonalFinance.API\PersonalFinance.API.csproj" />
  </ItemGroup>
```

Finally, you need to add a reference to your test project on your solution.

Navigate to root folder and execute the following command:

```bash
dotnet sln add src/PersonalFinance.API.Tests/PersonalFinance.API.Tests.csproj
```

### Add mock for your web api

On your test project create a new file called `PersonalFinanceAPIMock.cs` and add the following class:

```csharp
class PersonalFinanceAPIApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        // In here you should add your database mock
 
        return base.CreateHost(builder);
    }
}
```

### Add your unit tests

Now you can add your unit tests. Create one file per controller and add your tests.

At the end you should be able to run your tests using the following command:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

Since you're on the root folder, this command will use the solution to execute the test project.

The property allow you to generate the Cobertura XML file to be used to generate the HTML report.

### Generate code coverage report

You should use Report Generator command to generate the HTML report.

You can use the following command:

```bash
reportgenerator "-reports:src/PersonalFinance.API.Tests/TestResults/*/coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html
```

Then navigate to `coveragereport` folder and open the `index.html` file to see your code coverage report on your browser.

Congratulations! You have completed this lab!
