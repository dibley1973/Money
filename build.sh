#!/usr/bin/env bash
dotnet restore
dotnet clean -c Release
dotnet build Money.sln -c Release