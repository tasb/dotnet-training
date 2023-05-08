# Lab 01 - Prepare your dev machine

On this lab you will prepare your dev machine to start working with .NET.

Expected time to complete: 30/45 minutes

## Learning Objectives

- Install .NET SDK
- Install VS Code
- Add recommended extensions to VS Code
- Run your first CLI command
- Test your first .NET code

## Instructions

- [Install software](#install-software)
- [Add VS Code extensions](#add-vs-code-extensions)
- [Run .NET CLI command](#run-net-cli-command)
- [Create and Run .NET code](#create-and-run-net-code)

## Install software

To install .NET SDK you need to navigate to <https://dotnet.microsoft.com/en-us/download/dotnet/7.0> and download the SDK for your OS and architecture.

After download, run the installer and follow the instructions.

Then, you need to install VS Code. Navigate to <https://code.visualstudio.com/download> and download the installer for your OS and architecture.

After download, run the installer and follow the instructions.

Both install processes are very simple and straightforward and you may proceed with default configurations.

If you want, you can take more time during install to check additional option you may add to your environment.

## Add VS Code extensions

To install VS Code extension you may VS Code UI or following a direct link from VS Code Marketplace.

To make this process easier and to make sure you install the right extensions, please navigate to the following link and install the extensions:

- [C# for Visual Studio Code (powered by OmniSharp)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [C# Extensions](https://marketplace.visualstudio.com/items?itemName=kreativ-software.csharpextensions)
- [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)

When you navigate to each link you'll see an 'Install' button to start installation. You may be asked to allow to navigate to VS Code to proceed with your installation.

Sometimes you need to restart your VS Code to finish the installation process.

An additional extension can installed for you to try [GitHub Copilot](https://github.com/features/copilot). This extension is not required for the course, but you can try it if you want.

- [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot)

Now you have all needed software to start working with .NET.

## Run .NET CLI command

Let's try if your .NET CLI is working properly.

Open your favorite console/terminal and execute the following command:

```bash
dotnet --version
```

And you may get an output like this:

```bash
7.0.203
```

As we talked during initial session, there are several .NET versions and you may have more than one installed on your machine.

To check all installed versions you can execute the following command:

```bash
dotnet --list-sdks
```

And you may get an output like this:

```bash
7.0.203 [/usr/local/share/dotnet/sdk]
```

Together with .NET SDKs you may have installed .NET Runtimes. To check all installed versions you can execute the following command:

```bash
dotnet --list-runtimes
```

And you may get an output like this:

```bash
Microsoft.AspNetCore.App 7.0.5 [/usr/local/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.NETCore.App 7.0.5 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
```

In next labs you'll learn how do you specify which version of .NET you want to use to run your code.

## Create and Run .NET code

Let's create a initial and simple project to test if everything is working properly.

Of course that you'll create an Hello World project!

First, using .NET CLI let's create a new console project:

```bash
dotnet new console -o hello-world
```

You may get an output like this:

```bash
The template "Console App" was created successfully.

Processing post-creation actions...
Restoring /Users/tiago.bernardo/work/training/hello-world/hello-world.csproj:
  Determining projects to restore...
  Restored /Users/tiago.bernardo/work/training/hello-world/hello-world.csproj (in 28 ms).
Restore succeeded.
```

Now, let's navigate to the project folder:

```bash
cd hello-world
```

And open the project on VS Code:

```bash
code .
```

You find just one line of code, right? :)

This is called the new program style that were introduced on .NET 6.0. We'll learn more about it in next sessions.

Now, let's build the project:

```bash
dotnet build
```

And you should get an output like this:

```bash
MSBuild version 17.5.1+f6fdcf537 for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
  hello-world -> /Users/tiago.bernardo/work/training/hello-world/bin/Debug/net7.0/hello-world.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:00.40
```

Take a look into this line:

```bash
hello-world -> /Users/tiago.bernardo/work/training/hello-world/bin/Debug/net7.0/hello-world.dll
```

The compiler created a folder under `bin` folder with the name build configuration used, that in this case was the default `Debug`.

Inside that folder another one with target framework was created, in this case, `net7.0`.

Inside of it you have the DLL file that was generated by the compiler and that will used by the runtime to execute your code.

Now you can execute your code:

```bash
dotnet run
```

And you get the expected output:

```bash
Hello, World!
```

Before finishing this lab, let's take a quick look into `.csproj` file to check the structure of your project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework>
    <RootNamespace>hello_world</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
````

Since you created your code using .NET 7.0 SDK CLI, this project was automatically set to run using the same runtime.

You can check the following line:

```xml
<TargetFramework>net7.0</TargetFramework>
````

If you have other SDKs/Runtimes on your machine you could change the version here to be used by you .NET CLI.

Finally, you can use .NET CLI to generate your code on "old .NET version" :)

Go back to your console/terminal and move to previous folder:

```bash
cd ..
```

Then, you can create a new project with the following command:

```bash
dotnet new console -o old-hello-world --use-program-main
```

Now open the project on VS Code:

```bash
code old-hello-world
```

And check that you have a lot more code to execute the same Hello World:

```csharp
namespace old_hello_world;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```

Now run, your new old code:

```bash
cd old-hello-world

dotnet run
```

And check you get exactly the same output that you had before:

```bash
Hello, World!
```

Congratulations! You have your first .NET code running!
