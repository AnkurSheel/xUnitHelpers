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
$version = dotnet dotnet-gitversion /nofetch | Out-String | ConvertFrom-Json

Write-HOST "version"
Write-Output $version

$assemblyVer = $version.AssemblySemVer
$assemblyFileVer = $version.AssemblySemFileVer
$nugetVersion = $version.NuGetVersionV2
$assemblyInformationalVersion = $version.FullSemVer + "." + $version.Sha
$fullSemver = $version.FullSemVer


Write-Host "Build Library"
dotnet build --configuration $configuration -p:Version=$nugetVersion $project
