# $Env:API_LOGIN = "enter-your-api-login-here"
# $Env:API_PASSWORD = "enter-your-api-password-here"

$ErrorActionPreference = "Stop";

New-Item -ItemType Directory -Force -Path ./nuget

Push-Location ./src/Remap.Sdk
Invoke-Expression "./build.ps1 $args"
Pop-Location