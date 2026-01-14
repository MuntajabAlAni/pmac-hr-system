#!/bin/bash
# Script to run .NET commands with correct PATH for .NET 9.0
export PATH="$HOME/.dotnet:$PATH"
dotnet "$@"