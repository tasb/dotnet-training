# Session 02 - Dotnet Basics

## Contents

1. [App Settings](#app-settings)
2. [Nuget](#nuget)

## App Settings

1. Show code from folder `demos/02.dotnet-basics/app-settings`
2. Run code: `dotnet run`
3. Set Development environment: `export DOTNET_ENVIRONMENT=Development`
4. Run code: `dotnet run`
5. Set Production environment: `export DOTNET_ENVIRONMENT=Production`
6. Run code: `dotnet run`
7. Set Invalid environment: `export DOTNET_ENVIRONMENT=Invalid`
8. Run code: `dotnet run`
9. Explain the effect of `optional: true` method `AddJsonFile` on `Program.cs`
10. Use env vars: `export Logging__LogLevel__Default=XPTO`
11. Run code: `dotnet run`

## Nuget

1. Show code from folder `demos/02.dotnet-basics/nuget`
2. Run code: `dotnet build`
3. Check that the .nupkg file was created
4. Show `nuget.config` file. Mention that this file is not required, but it's a good practice to have it and can be created using `dotnet new nugetconfig`
5. Run: `dotnet nuget push bin/Release/Theonorg.DotnetTraining.CalcLibDemo.1.0.0.nupkg  --source github`
6. Check the error
7. Change version to `1.0.1` on `.csproj` file
8. Run: `dotnet nuget push bin/Release/Theonorg.DotnetTraining.CalcLibDemo.1.0.1.nupkg  --source github`
9. Check on GitHub the package was uploaded
