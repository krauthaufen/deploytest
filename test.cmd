@echo off
SETLOCAL
PUSHD %~dp0

IF NOT exist .paket\paket.exe (
	dotnet tool install Paket --tool-path .paket
)

.paket\paket.exe restore

dotnet packages\fake-cli\tools\netcoreapp2.1\any\fake-cli.dll build
