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
  <ItemGroup>
    <ProjectReference Include="pathToNasfaqAPI/Nasfaq.API.csproj"/>
  </ItemGroup>
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net4.8</TargetFramework>
  </PropertyGroup>
</Project>
```
### Develop with dotnet
You can create a new project with `dotnet new ...`, replace `...` with the type of app you want, like `console`.
While in your project's repository, run `dotnet restore` to fix dependencies, `dotnet run` to quickly build and run, and `dotnet build` to build.

### Develop with msbuild
You need to create you projects yourself by hand or with Visual Studio.
While in your project's repository, run `msbuild -t:restore` to fix dependencies and `msbuild project.csproj` to build

### Run the build executable
In either case you will get a .exe built of your application. Run it with `mono app.exe`.
