# parcel-manager

This is a simple application for managing shipments, bags and parcels.

## Running the application

1. .NET 5.x is required.
2. Node.js 14.x is required.
3. In a terminal, run the command *cd .\src\ParcelManager.API\ClientApp\\*
4. Run the command *npm install*
5. Run *cd ..\\..\\..\\*
6. Run *dotnet tool restore*
6. Run *dotnet ef database update --startup-project .\src\ParcelManager.API\ --project .\src\ParcelManager.Infrastructure\\*
7. Start the application
    * In Visual Studio, make sure the startup project is set as ParcelManager.API, then press F5
    * In VS Code, it should be enough to press F5 when a .cs file in ParcelManager.API is opened, accept the prompt, and press F5 again.
