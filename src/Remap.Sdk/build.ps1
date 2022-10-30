$ErrorActionPreference = "Stop";

# build
Push-Location ./src
dotnet build -c Release
Pop-Location

# test
Push-Location ./test/Remap.Sdk.UnitTests
dotnet test -c Release
Pop-Location

Push-Location ./test/Remap.Sdk.IntegrationTests
dotnet test -c Release
Pop-Location

# pack
Push-Location ./src
dotnet pack -c Release -o ../../../nuget --no-build
Pop-Location