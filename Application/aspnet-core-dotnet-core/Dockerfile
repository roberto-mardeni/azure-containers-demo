FROM mcr.microsoft.com/dotnet/core/sdk:9.0-azurelinux3.0 AS build-env
WORKDIR /app

# Copy the published web app
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Run command
FROM mcr.microsoft.com/dotnet/core/aspnet:9.0-azurelinux3.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "aspnet-core-dotnet-core.dll"]