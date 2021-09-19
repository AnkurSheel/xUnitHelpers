Write-Output $outFolder
Write-Output $configuration
Write-Output $project

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

$buildId = $env:BUILD_BUILDID
Write-Host "Build id variable is $buildId"

$runInBuild = $false
if (![System.String]::IsNullOrEmpty($buildId))
{
    $runInBuild = $true
    Write-Host "Running in an Azure Devops Build"
}