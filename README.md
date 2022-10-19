﻿# FS Engineer Test(Chuck/Swapi/C#)

## Project Structure

    .
    ├── src                                     # Application Source Files.
            ├──sovtechapi
    |               └── Sovtech.Data            # Data Layer
                    └── Sovtech.Core            # Application Logic Layer
                    └── Sovtech.API             # API
            ├── test
                    └── Sovtech.Core.Tests.Unit # Business Logic Layer Unit Tests
                    └── Sovtech.Api.Tests.Unit  # API Unit Tests
    ├── .gitignore                              # Git ignore.
    ├── README.md                               # This file.
    

#### API Documentation
API documentation is [here](https://localhost:5000/swagger) after running the application on visual studio 2022/ VSCode

#### Technologies Used
- dotnet 6
- NSubstitute
- Fluent Assertions

## Getting Started

##### Prerequisites
- dotnet 6 SDK needs to be installed on your machine. See [dotnet 6 Docs](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Visual studio 2022/VS Code needs to be installed

##### Setting up locally
- Clone with SSH => `git@github.com:chiomajoshua/sovtech-challenge.git`
- Clone with HTTPS => `https://github.com/chiomajoshua/sovtech-challenge.git`


##### Running the app on an attached device
- Open project with visual studio/Visual Studio
- If Nugets do not restore automatically, right-click on the solution folder and select Restore Nuget Packages
- Build and Run the project.


##### Todos
- Build Web UI