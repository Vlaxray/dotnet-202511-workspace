# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia file di progetto e ripristina dipendenze
COPY *.csproj ./
RUN dotnet restore

# Copia tutto il resto e pubblica
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Imposta l'entrypoint
ENTRYPOINT ["dotnet", "docker-efcore-tutorial.dll"]