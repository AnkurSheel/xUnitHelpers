#!/bin/bash

echo "outFolder - $1"
echo "configuration - $2"
echo "pwd - $PWD"

ls

echo "Restoring tooling for gitversion"
dotnet tool install GitVersion.Tool

echo "Running gitversion to determine version"
version = $(dotnet dotnet-gitversion /l console /output buildserver /nofetch)
echo "version - $version"