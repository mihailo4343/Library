# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy and restore Library.Domain project
COPY ["Library.Domain/Library.Domain.csproj", "Library.Domain/"]
RUN dotnet restore "Library.Domain/Library.Domain.csproj"

# Copy and restore Library.Infrastructure project
COPY ["Library.Infrastructure/Library.Infrastructure.csproj", "Library.Infrastructure/"]
RUN dotnet restore "Library.Infrastructure/Library.Infrastructure.csproj"

# Copy and build Library.API project
COPY ["Library.API/Library.API.csproj", "Library.API/"]
RUN dotnet restore "Library.API/Library.API.csproj"
COPY . .
WORKDIR "Library.API"
RUN dotnet build "Library.API.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "Library.API.csproj" -c Release -o /app/publish

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.API.dll"]
