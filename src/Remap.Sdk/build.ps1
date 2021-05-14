$ErrorActionPreference = "Stop";

# build
pushd ./src
dotnet build -c Release
popd

# test
pushd ./test/Remap.Sdk.UnitTests
dotnet test -c Release
popd

pushd ./test/Remap.Sdk.IntegrationTests
dotnet test -c Release
popd

# pack
pushd ./src
dotnet pack -c Release -o ../../../nuget --no-build
popd