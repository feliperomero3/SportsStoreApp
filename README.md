# SportsStoreApp

| Angular | ASP.NET Core MVC 3 |
| --- | --- |
| [![ClientApp-CI][ClientApp-CI-status-badge]][ClientApp-CI-status] | [![ServerApp-CI][ServerApp-CI-status-badge]][ServerApp-CI-status] |
| [![Coverage][Coverage-Status-badge]][Coverage-Status] | [![Coverage][ServerApp-Coverage-status-badge]][ServerApp-Coverage-status] |
| [![Quality Gate Status][Quality-Gate-Status-badge]][Quality-Gate-Status] | [![Quality Gate Status][ServerApp-Quality-Gate-status-badge]][ServerApp-Quality-Gate-status] |

Based on the SportsStore Application built in the Book ['Essential Angular for ASP.NET Core MVC 3 - A Practical Guide to Successfully Using Both in Your Projects'](https://www.apress.com/9781484229156) by Adam Freeman (Apress, 2019).

The Application is one part Angular and other part ASP.NET Core MVC 3.

## Prerequisites

- .NET Core SDK 3.1.x
- Visual Studio 2019 or alternative editor
- Node 12.x
- Angular CLI 9.x

## Getting started

1. Clone the project
2. Open the solution file `SportsStoreApp.sln` with Visual Studio 2019
3. Right click the solution node on the Solution Explorer tool window and click on 'Restore Client-Side Libraries'
4. Open a command prompt at the root of the project and execute the following

    ```bash
    cd ClientApp
    npm install
    cd ..
    cd src/SportsStore
    dotnet restore
    dotnet build
    dotnet run --project SportsStore.csproj
    ```

5. Open <https://localhost:5001> on your favorite web browser. _It may take a while to start on first launch._

## How to debug

Open the solution file and hit F5 to start a debug session. The ASP.NET Core engine will start the Angular Development Server automatically (go through [Getting started](#getting-started) section first).

## Screen capture

![SportsStore Home][screenshot-sportsstore]

## License

[MIT License](LICENSE)

Copyright (c) 2020 Felipe Romero

[ClientApp-CI-status-badge]: https://github.com/feliperomero3/SportsStoreApp/workflows/SportsStoreClientApp-CI/badge.svg
[ClientApp-CI-status]: https://github.com/feliperomero3/SportsStoreApp/actions?query=workflow:SportsStoreClientApp-CI
[Coverage-Status-badge]: https://sonarcloud.io/api/project_badges/measure?project=feliperomero3_SportsStoreApp_ClientApp&metric=coverage
[Coverage-Status]: https://sonarcloud.io/dashboard?id=feliperomero3_SportsStoreApp_ClientApp
[Quality-Gate-Status-badge]: https://sonarcloud.io/api/project_badges/measure?project=feliperomero3_SportsStoreApp_ClientApp&metric=alert_status
[Quality-Gate-Status]: https://sonarcloud.io/dashboard?id=feliperomero3_SportsStoreApp_ClientApp

[ServerApp-CI-status-badge]: https://dev.azure.com/feliperomeromx/Projects/_apis/build/status/feliperomero3.SportsStoreApp?branchName=master
[ServerApp-CI-status]: https://dev.azure.com/feliperomeromx/Projects/_build/latest?definitionId=10&branchName=master
[ServerApp-Coverage-status-badge]: https://sonarcloud.io/api/project_badges/measure?project=feliperomero3_SportsStoreApp_ServerApp&metric=coverage
[ServerApp-Coverage-status]: https://sonarcloud.io/dashboard?id=feliperomero3_SportsStoreApp_ServerApp
[ServerApp-Quality-Gate-status-badge]: https://sonarcloud.io/api/project_badges/measure?project=feliperomero3_SportsStoreApp_ServerApp&metric=alert_status
[ServerApp-Quality-Gate-status]: https://sonarcloud.io/dashboard?id=feliperomero3_SportsStoreApp_ServerApp

[screenshot-sportsstore]: .github/assets/screenshot-sportsstore.png
