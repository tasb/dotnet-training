# Lab 02 - Build your first app

On this lab you will create your first console application using .NET! The previous lab doesn't count as an application, it was just a "Hello World" :)

Expected time to complete: 150/180 minutes

## Learning Objectives

- Create a Nuget library
- Push your library to a remote repository
- Create a console app using your class library
- Use console for input and output
- Control your app behavior using app settings
- Handle filesystem

## Instructions

- [Prepare your GitHub Package repository](#prepare-your-github-package-repository)
- [Prepare your dev machine](#prepare-your-dev-machine)
- [Create an Exchange Rate library](#create-an-exchange-rate-library)
- [Add Business Layer to your app](#add-business-layer-to-your-app)
- [Add Console UI to your app](#add-console-ui-to-your-app)

## Prepare your GitHub Package repository

To use your GitHub repository as a Package Source, you only need to create a token to authenticate your requests.

Navigate to <https://github.com/settings/tokens> (you need to be logged in) and click on 'Generate new token' and then 'Generate new token (classic)'.

On the 'Note' field, type 'Dotnet Training' and on 'Select scopes' check 'write:packages'. When you select this scope, several other scopes will be selected automatically.

Scroll to the bottom of the page and click on 'Generate token'.

Copy the generated token and save it in a safe place. You'll need it later.

To use it on a more secure way, add this to your environment variables.

On Windows, to add a new environment variable, open the 'Start' menu and type 'environment variables'. Select 'Edit the system environment variables' and click on 'Environment Variables' button.

Then create a new variable named 'GITHUB_TOKEN' and paste the token you copied before as value.

On Linux, you can add the token to your .bashrc file:

```bash
export GITHUB_TOKEN=your-token-here
```

## Prepare your dev machine

Before starting developing your app, you need to prepare your dev machine.

First, create a folder named `personal-finance-demo` and navigate to it.

Then, create a new solution using the following command:

Inside it create a folder called `src` where you'll add your dotnet projects.

Finally, on root folder, create a file named `nuget.config` with the following content:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <!--To inherit the global NuGet package sources remove the <clear/> line below -->
    <clear />
    <add key="nuget" value="https://api.nuget.org/v3/index.json" />
    <add key="github" value="https://nuget.pkg.github.com/$$$GITHUB_USERNAME$$$/index.json" />
  </packageSources>
  <packageSourceMapping>
      <packageSource key="nuget">
          <package pattern="*" />
      </packageSource>
      <packageSource key="github">
          <package pattern="$$$GITHUB_USERNAME$$$.DotnetTraining.*" />
      </packageSource>
    </packageSourceMapping>
    <packageSourceCredentials>
        <github>
            <add key="Username" value="$$$GITHUB_USERNAME$$$" />
            <add key="ClearTextPassword" value="%GITHUB_TOKEN%" />
        </github>
    </packageSourceCredentials>
</configuration>
```

Replace all occurrences of `$$$GITHUB_USERNAME$$$` with your GitHub username.

This file will allow you to authenticate on GitHub Package repository using your token and will instruct nuget to use it every time you try to install a package with the name `$$$GITHUB_USERNAME$$$.DotnetTraining.*`.

## Create an Exchange Rate library

Let's create a library to calculate amount based on exchange rates. On this case, we'll create a simple library with constant rates, but you can extend it to use a real API to get the rates.

Navigate to `src` folder and create a new class library using the following command:

```bash
dotnet new classlib -o ExchangeRateLib
```

Open your .csproj file and add the following content inside the `<PropertyGroup>` tag:

```xml
<RootNamespace>$$$GITHUB_USERNAME$$$.DotnetTraining.ExchangeRateLib</RootNamespace>

<PackageId>$$$GITHUB_USERNAME$$$.DotnetTraining.ExchangeRateLib</PackageId>
<Version>1.0.0</Version>
<Authors>tib$$$GITHUB_USERNAME$$$erna</Authors>
<Company>$$$GITHUB_USERNAME$$$</Company>
<GeneratePackageOnBuild>true</GeneratePackageOnBuild>
```

Replace all occurrences of `$$$GITHUB_USERNAME$$$` with your GitHub username.

The `<RootNamespace>` tag will set the base namespace to be used on your project. This is the namespace that will be used on your code files.

Now remove `Class1.cs` file and start to create your files.

Resources to be created:

- An Interface named `IExchangeRateCalculator` where you specify:
  - A property to hold the Currency as a string
  - A method named `Convert` that receives an amount and a currency and returns the converted amount
- An abstract class that implements `IExchangeRateCalculator` named `ExchangeRateCalculatorBase` where you:
  - Implements both the property and the method defined on the interface
  - Add a constructor
    - Receives the currency and set the property
    - Call an abstract method named `GenerateExchangeRates`to be implemented on derived classes to generate the exchange rates
- Two classes named `EuroExchangeRateCalculator`and `USDExchangeRateCalculator` that inherits from `ExchangeRateCalculatorBase` and implements the `GenerateExchangeRates` method
  - `EuroExchangeRateCalculator` should have the following rates:
    - USD: 1.18
    - GBP: 0.85
  - `USDExchangeRateCalculator` should have the following rates:
    - EUR: 0.85
    - GBP: 0.72
  - `GBPExchangeRateCalculator` should have the following rates:
    - EUR: 1.18
    - USD: 1.38

After creating your classes, you can run `dotnet build -c Release` to check if everything is ok. Since you have set `<GeneratePackageOnBuild>true</GeneratePackageOnBuild>` on your .csproj file, a Nuget package will be generated on `bin/Release` folder.

Now you can push your package to GitHub Package repository using the following command:

```bash
dotnet nuget push bin/Release/$$$GITHUB_USERNAME$$$.DotnetTraining.ExchangeRateLib.1.0.0.nupkg  --source github
```

Replace all occurrences of `$$$GITHUB_USERNAME$$$` with your GitHub username.

You can navigate to <https://github.com/$$$GITHUB_USERNAME$$$?tab=packages> to check if your package was uploaded.

Now, when you want to use this package on another project, you can just add it as a dependency to your project using dotnet CLI with the following command:

```bash
dotnet add package $$$GITHUB_USERNAME$$$.DotnetTraining.ExchangeRateLib
```

This command will use the latest version of your package. If you want to use a specific version, you can use the following command:

```bash
dotnet add package $$$GITHUB_USERNAME$$$.DotnetTraining.ExchangeRateLib --version 1.0.0
```

## Add Business Layer to your app

For Business Layer, you need to create a class library project and add a reference to your Exchange Rate library.

Navigate to `src` folder and create a new class library using the following command:

```bash
dotnet new classlib -o BusinessLayer

dotnet add package $$$GITHUB_USERNAME$$$.DotnetTraining.ExchangeRateLib
```

When `.csproj` is created, add the following content inside the `<PropertyGroup>` tag:

```xml
<RootNamespace>$$$GITHUB_USERNAME$$$.DotnetTraining.BusinessLayer</RootNamespace>
```

Replace all occurrences of `$$$GITHUB_USERNAME$$$` with your GitHub username.

Now, you can start to create the following models:

- Currency: an enum with the following values:
  - EUR
  - USD
  - GBP
- Account: a class with the following properties:
  - Name: a string
  - InitialBalance: a decimal
  - Balance: a decimal
  - Currency: a Currency
  - List of Transactions
  - IExchangeRateCalculator instance
- Transaction: a class with the following properties:
  - Amount: a decimal
  - AmountInAccountCurrency: a decimal
  - Currency: a Currency
  - Date: a DateTime
  - Description: a string
- Expense and Income as derived classes of Transaction

On Account class, you should add the following methods:

- AddTransaction: receives a Transaction, add it to the list of transactions and update the balance
- GetBalance: returns the current balance
- GetTransactionsByMonth: receives a month and a year and returns all transactions on that month (try to use LINQ)
- GetTransactionsBetweenDates: receives two dates and returns all transactions between those dates (try to use LINQ)
- SelectExchangeRateCalculator: receives a currency and returns an instance of IExchangeRateCalculator based on the currency (private method to be called on constructor)

Then, create an AccountService class with the following properties:

- Account: an Account instance (to make it simple)

With the following methods:

- AddExpense: receives an amount, a currency, a date and a description and add a new Expense to the account. Needs to check if the amount is a negative value and make it negative if it's not.
- AddIncome: receives an amount, a currency, a date and a description and add a new Income to the account. Needs to check if the amount is a positive value and if not, throw an ArgumentException.
- GetBalance: returns the current balance
- GetTransactionsByMonth: receives a month and a year and returns all transactions on that month (try to use LINQ)
- GetTransactionsBetweenDates: receives two dates and returns all transactions between those dates (try to use LINQ)

These classes usually are created inside specific folders, like `Models` and `Services`. You should do it and reflect it on your namespaces.

When creating your methods and properties be aware of the modifiers you can use to make only available outside your project the things you want.

## Add Console UI to your app

Final step is to create a console app to use your Business Layer.

On this case, the reference will be done directly to your Business Layer project. To make build more easier, you'll create a solution file on root folder and add both projects to it.

Navigate to `src` folder and create a new console app project using the following command:

```bash
dotnet new console -o ConsoleApp
```

When `.csproj` is created, add the following content inside the `<PropertyGroup>` tag:

```xml
<RootNamespace>$$$GITHUB_USERNAME$$$.DotnetTraining.ConsoleApp</RootNamespace>
```

Replace all occurrences of `$$$GITHUB_USERNAME$$$` with your GitHub username.

Now, navigate to `ConsoleApp` folder and add a reference to your Business Layer project using the following command:

```bash
dotnet add reference ../BusinessLayer/BusinessLayer.csproj
```

Finally, navigate to root folder and create a new solution file using the following command:

```bash
dotnet new sln
```

Then, add both projects to your solution using the following command:

```bash
dotnet sln add src/BusinessLayer/BusinessLayer.csproj src/ConsoleApp/ConsoleApp.csproj
```

Now you can execute `dotnet build` on root folder to check if everything is ok. This command will use the solution file to build both projects.

Now, on the `Program.cs` file, you can start to create your console app.

In the following code block you may find one implementation for the console menus that you can use or use one create by you. Some logic is missing, so you need to complete it and this code may not run as is.

To read characters from console, you can use `Console.ReadKey().KeyChar` and to read lines you can use `Console.ReadLine()`.

```csharp
using $$$GITHUB_USERNAME$$$.DotnetTraining.BusinessLayer.Models;
using $$$GITHUB_USERNAME$$$.DotnetTraining.BusinessLayer.Services;
using $$$GITHUB_USERNAME$$$.DotnetTraining.ConsoleApp.Models;

Console.WriteLine("Welcome to Personal Finance Console App!");
Console.WriteLine("Let me ask you details to create your Account");

Console.Write("Account Name: ");
string str = Console.ReadLine()!;

do {
    Console.Write("Account Currency (EUR, USD, GBP): ");
    str = Console.ReadLine()!;

} while (<valid_currency>);

Console.Write("Initial Balance: ");
decimal number = decimal.Parse(Console.ReadLine()!);

Console.WriteLine($"Account created: {<account_toString}");
Console.WriteLine("Let's add some transactions to your account");

char? option = null;

do {

    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Add Expense");
    Console.WriteLine("2. Add Income");
    Console.WriteLine("3. Get Balance");
    Console.WriteLine("4. Get Transactions by Month");
    Console.WriteLine("5. Get Transactions between Dates");
    Console.WriteLine("q. Quit");

    option = Console.ReadKey().KeyChar;

    Console.WriteLine();

    switch(option)  {
        case '1':
            <AddExpense>
            break;
        case '2':
            <AddIncome>
            break;
        case '3':
            <GetBalance>
            break;
        case '4':
            <GetTransactionsByMonth>
            break;
        case '5':
            <GetTransactionsBetweenDates>
            break;
    }

} while (option != 'q');
```

Have fun!
