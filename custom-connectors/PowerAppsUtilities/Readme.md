
### NOTE
> This is a *sample* connector.  The connector is provided here with the intent to illustrate certain features and functionality around connectors.

## PowerApps Utilities (via Azure Functions) [Sample] Connector
While PowerApps has many fuctions available for manipulating data, sometimes Connectors are not easy to use from within PowerApps.

This connector adds implementations of some utility methods which otherwise may be impossible from within PowerApps.

This connector is backed by an Azure Function App, source code is also provided. You can run and test the Function App from within VS Code. The Azure Function extension also allows simple deployment of the code to a Function App.

## Prerequisites
- .NET Core SDK v2.1 (2.1.607 or higher)
- VS Code
- VS Code Extensions
    - C# for Visual Studio Code
    - Azure Functions (v0.20.1)

## TODOs
- Take the host of the Azure Functions App as a connection parameter
    - or deployment variable???
- Add other documentation
