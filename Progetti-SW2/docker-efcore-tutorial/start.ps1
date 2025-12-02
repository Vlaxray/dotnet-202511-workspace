Write-Host "=== Docker EF Core Setup ===" -ForegroundColor Green

# Clean up
Write-Host "1. Cleaning up..." -ForegroundColor Yellow
docker-compose down -v 2>$null
docker rm -f sql-server-db efcore-app 2>$null
docker network prune -f 2>$null

# Build
Write-Host "2. Building containers..." -ForegroundColor Yellow
docker-compose build

# Start SQL Server first
Write-Host "3. Starting SQL Server..." -ForegroundColor Yellow
docker-compose up -d sql-server

Write-Host "Waiting for SQL Server to be ready..." -ForegroundColor Cyan
$attempts = 0
$maxAttempts = 30

while ($attempts -lt $maxAttempts) {
    $attempts++
    Write-Host "Attempt $attempts/$maxAttempts" -ForegroundColor Gray
    
    $result = docker exec sql-server-db /opt/mssql-tools/bin/sqlcmd `
        -S localhost `
        -U sa `
        -P "YourStrong!Passw0rd123" `
        -Q "SELECT 1" `
        2>$null
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "SQL Server is ready!" -ForegroundColor Green
        break
    }
    
    if ($attempts -eq $maxAttempts) {
        Write-Host "SQL Server failed to start in time" -ForegroundColor Red
        docker-compose logs sql-server
        exit 1
    }
    
    Start-Sleep -Seconds 5
}

# Create database
Write-Host "4. Creating database..." -ForegroundColor Yellow
docker exec sql-server-db /opt/mssql-tools/bin/sqlcmd `
    -S localhost `
    -U sa `
    -P "YourStrong!Passw0rd123" `
    -Q "CREATE DATABASE BlogDb" `
    2>$null

# Start app
Write-Host "5. Starting application..." -ForegroundColor Yellow
docker-compose up -d app

# Wait and show logs
Start-Sleep -Seconds 10
Write-Host "6. Application logs:" -ForegroundColor Yellow
docker-compose logs app --tail=50

Write-Host "`n=== Setup Complete ===" -ForegroundColor Green
Write-Host "SQL Server: localhost:1433" -ForegroundColor Cyan
Write-Host "Username: sa" -ForegroundColor Cyan
Write-Host "Password: YourStrong!Passw0rd123" -ForegroundColor Cyan
Write-Host "Database: BlogDb" -ForegroundColor Cyan
Write-Host "`nTo view logs: docker-compose logs -f app" -ForegroundColor Gray
Write-Host "To stop: docker-compose down" -ForegroundColor Gray