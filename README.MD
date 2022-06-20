# Nasfaq.API
This C# library allows you to easily interact with the nasfaq api.

## Compatibility
The project depends on .NET 4.8.

It is maintained with Linux (x86_64, arm6l+) and Windows(x86_64) in mind.

## Requirements

### Linux
Install the [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) according to your platform.
On platforms not supported by .NET Core (such as ARMv6 Raspberry Pis), you need to install mono and msbuild.
#### Arch Linux
```bash
sudo pacman -Syu mono
yay -Syu msbuild-git
```
#### Others
https://www.mono-project.com/download/stable/

### Windows
Install the [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) according to your platform.
If you wish to use `msbuild` instead of dotnet core, you can just install `Visual Studio`, or install `Tools for Visual Studio` to get only the tools.

## Usage
Clone the git repository and add a reference to it in your C# project. Here's a template for a new project's .csproj:
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net4.8</TargetFramework>
  </PropertyGroup>
</Project>
```
Then, add the priestess nuget feed to your local nuget settings:
```bash
dotnet nuget add source --username USERNAME --password TOKEN --store-password-in-clear-text --name github_priestess "https://nuget.pkg.github.com/priestesshpt/index.json"
```
Change USERNAME with your username and TOKEN with your `read:packages` [package token](https://docs.github.com/en/packages/learn-github-packages/about-permissions-for-github-packages#about-scopes-and-permissions-for-package-registries)

Finally add the package to your project with:
```bash
dotnet add package Nasfaq.API 
```

### Develop with dotnet
You can create a new project with `dotnet new ...`, replace `...` with the type of app you want, like `console`.
While in your project's repository, run `dotnet restore` to fix dependencies, `dotnet run` to quickly build and run, and `dotnet build` to build.

### Develop with msbuild
You need to create you projects yourself by hand or with Visual Studio.
While in your project's repository, run `msbuild -t:restore` to fix dependencies and `msbuild project.csproj` to build

### Run the build executable
In either case you will get a .exe built of your application. Run it with `mono app.exe`.
