# build
$proj = Get-ChildItem ".\src" -File -Filter "*.csproj"
if ($proj.Exists) {
    dotnet build $proj.FullName  -c Release
} else {
    $LASTEXITCODE = 1
}

if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

# test
Get-ChildItem ".\test" -Filter "*.csproj" -Recurse |
Foreach-Object {
    dotnet test $_.FullName -c Release
}

if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

# pack
dotnet pack $proj.FullName -c Release -o .\artifacts --no-build