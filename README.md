# F# Azure Function App Boilerplate 

## Setup
```bash
# create local.setting.json
cp example.local.setting.json local.setting.json
```

## Build
```bash
dotnet build
```

Or run [Visual Studio Code](https://code.visualstudio.com/) task: `build`

## Run
```bash
cd bin/Debug/netcoreapp2.1 && func start
```

Or run Visual Studio Code task: `func: host start`

## Debug
Use Visual Studio Code: Start debugger `Debug Functions App`

## Prerequisites
* [.NET CLI tools](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
* [Azure Functions Core Tools](https://github.com/Azure/azure-functions-core-tools) 