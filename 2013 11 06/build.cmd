@echo off

:Build
cls

SET TARGET="Default"

IF NOT [%1]==[] (set TARGET="%~1")

SET VERSION=

IF NOT [%2]==[] (set VERSION="%~2")

SET FAKE_VERSION=2.1.581-alpha

"packages\FAKE.%FAKE_VERSION%\tools\Fake.exe" "build.fsx" "target=%TARGET%" %VERSION%

rem Bail if we're running a TeamCity build.
if defined TEAMCITY_PROJECT_NAME goto Quit

rem Loop the build script.
set CHOICE=nothing
echo (Q)uit, (Enter) runs the build again
set /P CHOICE=
if /i "%CHOICE%"=="Q" goto :Quit

GOTO Build

:Quit
exit /b %errorlevel%