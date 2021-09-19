echo "outFolder - %1"
echo "configuration - %2"
echo "project - %3"
echo "pwd - %cd%"

echo "Restoring tooling for gitversion"
dotnet tool install GitVersion.Tool

echo "Running gitversion to determine version"
dotnet dotnet-gitversion /l console /output buildserver /nofetch

Set