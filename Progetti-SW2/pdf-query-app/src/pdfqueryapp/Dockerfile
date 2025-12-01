FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia i file del progetto
COPY src/PdfQueryApp/PdfQueryApp.csproj ./PdfQueryApp/
RUN dotnet restore ./PdfQueryApp/PdfQueryApp.csproj

# Copia tutto il resto
COPY . .
WORKDIR /src/PdfQueryApp

# Build dell'applicazione
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Runtime image con supporto GUI
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app

# Installare dipendenze necessarie per GUI su Linux
RUN apt-get update && apt-get install -y \
    libgtk-3-0 \
    libcairo2 \
    libpango-1.0-0 \
    libgdk-pixbuf2.0-0 \
    libglib2.0-0 \
    libx11-dev \
    libxext-dev \
    libxrandr-dev \
    libxtst-dev \
    && rm -rf /var/lib/apt/lists/*

# Copia l'app pubblicata
COPY --from=publish /app/publish .

# Crea una cartella per i PDF
RUN mkdir -p /app/Data

# Entry point
ENTRYPOINT ["dotnet", "PdfQueryApp.dll"]