# SportsStoreApp

[![SportsStoreClientApp-CI][SportsStoreClientApp-CI-status-badge]][SportsStoreClientApp-CI-status]
[![Quality Gate Status][Quality-Gate-Status-badge]][Quality-Gate-Status]

[![SportsStoreServerApp-CI][ServerApp-CI-status-badge]][ServerApp-CI-status]
[![Quality Gate Status][ServerApp-Quality-Gate-status-badge]][ServerApp-Quality-Gate-status]

Based on the SportsStore Application built in ['Essential Angular for ASP.NET Core MVC 3 - A Practical Guide to Successfully Using Both in Your Projects'](https://www.apress.com/9781484229156) by Adam Freeman (Apress, 2019).

The Application is one part Angular and other part ASP.NET Core MVC 3.

## Prerequisites

- .NET Core SDK 3.1.x
- Visual Studio 2019 or alternative editor
- Node 14.x
- Angular 8.x

## How to build

Build the project using Visual Studio 2019.

## How to run

Hit F5 to start a debug session. The ASP.NET Core engine will start the Angular Development Server automatically.

## Screen capture

![SportsStore Home][screenshot-sportsstore]

[SportsStoreClientApp-CI-status-badge]: https://github.com/feliperomero3/SportsStoreApp/workflows/SportsStoreClientApp-CI/badge.svg
[SportsStoreClientApp-CI-status]: https://github.com/feliperomero3/SportsStoreApp/actions?query=workflow:SportsStoreClientApp-CI
[Quality-Gate-Status-badge]: https://sonarcloud.io/api/project_badges/measure?project=feliperomero3_SportsStoreApp_ClientApp&metric=alert_status
[Quality-Gate-Status]: https://sonarcloud.io/dashboard?id=feliperomero3_SportsStoreApp_ClientApp

[ServerApp-CI-status-badge]: https://dev.azure.com/feliperomeromx/Projects/_apis/build/status/feliperomero3.SportsStoreApp?branchName=master
[ServerApp-CI-status]: https://dev.azure.com/feliperomeromx/Projects/_build/latest?definitionId=10&branchName=master
[ServerApp-Quality-Gate-status-badge]: https://sonarcloud.io/api/project_badges/measure?project=feliperomero3_SportsStoreApp_ServerApp&metric=alert_status
[ServerApp-Quality-Gate-status]: https://sonarcloud.io/dashboard?id=feliperomero3_SportsStoreApp_ServerApp
[screenshot-sportsstore]: .github\assets\screenshot-sportsstore.png
