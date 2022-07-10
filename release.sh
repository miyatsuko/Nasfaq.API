#!/bin/sh
dotnet pack -c Release
dotnet nuget push "bin/Release/Nasfaq.API.$1.nupkg" --source "github_miyatsuko"