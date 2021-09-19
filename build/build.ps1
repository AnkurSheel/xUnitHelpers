$outFolder = $args[0]
$configuration = $args[1]
$project = $args[2]

Write-Host "Output folder is $outFolder"
Write-Host "Configuration: $configuration"
Write-Host "Project: $project"

Write-Host "Build id variable is $env:BUILD_BUILDID"

Write-Host "Restoring tooling for gitversion"

dotnet tool restore

Write-Host "Get version"
# $version = dotnet dotnet-gitversion /nofetch | Out-String | ConvertFrom-Json
dotnet dotnet-gitversion /l console /output buildserver /nofetch
# Write-HOST "version"
# Write-Output $version

# $nugetVersion = $version.NuGetVersionV2

# Write-Host "Build Library"
# Write-Host "dotnet build --configuration $configuration /p:Version=$nugetVersion $project"
# dotnet build --configuration $configuration /p:Version=$nugetVersion $project

# Write-Host "Build Nuget Package"
# Write-Host "dotnet build --configuration $configuration /p:Version=$nugetVersion $project"
# dotnet pack $project --configuration $configuration --include-symbols --no-build --output $outFolder /p:Version=$nugetVersion

Get-ChildItem -Path Env: