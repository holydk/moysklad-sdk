# Enter your login and password
# $Env:API_LOGIN = "enter-your-api-login-here"
# $Env:API_PASSWORD = "enter-your-api-password-here"

#region Utilities

function Write-Color([String[]]$Messages, [ConsoleColor[]]$Color) {
    for ($i = 0; $i -lt $Messages.Length; $i++) {
        if ($i -gt $Color.Length - 1) {
            Write-Host $Messages[$i] -Foreground $Color[$Color.Length - 1] -NoNewLine
        } else {
            Write-Host $Messages[$i]  -Foreground $Color[$i] -NoNewLine
        }
        
        if ($i -ne $Messages.Length - 1) {
            Write-Host " " -NoNewline
        }
    }
}

#endregion

New-Item -ItemType Directory -Force -Path ./nuget

$ErrorActionPreference = "Stop";

$cd = Get-Location

# build
Get-ChildItem ".\src" -File -Filter "build.ps1" -Recurse | 
Foreach-Object {
    Set-Location $_.DirectoryName 
    & .\build.ps1 $args

    if ($LASTEXITCODE -ne 0)
    {
        Write-Color -Messages "Build failed in", $_.FullName -Color Red

        Set-Location $cd
        
        exit $LASTEXITCODE
    }

    $artifacts = $_.DirectoryName + "\artifacts\*.nupkg"
    $sources = $cd.Path + "\nuget"
    Copy-Item -Force -path $artifacts -Destination $sources

    Write-Color -Messages "Build successful in", $_.FullName -Color Green
}

Set-Location $cd