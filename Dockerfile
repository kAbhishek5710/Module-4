# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy only the csproj and restore
COPY Module\ 4/Module\ 4.csproj Module\ 4/
RUN dotnet restore Module\ 4/Module\ 4.csproj

# Copy the rest of the project
COPY Module\ 4/ Module\ 4/
WORKDIR /src/Module\ 4
RUN dotnet publish -c Release -o /app/out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "Module 4.dll"]
