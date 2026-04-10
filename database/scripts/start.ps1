# Caruna - Start Database Container (Windows PowerShell)

Write-Host "═══════════════════════════════════════════════════" -ForegroundColor Cyan
Write-Host "  Caruna - Start Database Container" -ForegroundColor Cyan
Write-Host "═══════════════════════════════════════════════════" -ForegroundColor Cyan
Write-Host ""

# Tarkista että docker-compose.yml löytyy
if (-not (Test-Path "docker-compose.yml")) {
    Write-Host "❌ Error: docker-compose.yml not found!" -ForegroundColor Red
    Write-Host "   Please run this script from the project root directory." -ForegroundColor Yellow
    exit 1
}

# Tarkista Docker
try {
    docker ps | Out-Null
} catch {
    Write-Host "❌ Error: Docker is not running!" -ForegroundColor Red
    Write-Host "   Please start Docker Desktop and try again." -ForegroundColor Yellow
    exit 1
}

# Etsi muut SQL Server -kontit portissa 1433
Write-Host "🔍 Checking for other SQL Server containers using port 1433..." -ForegroundColor Yellow

$allContainers = docker ps --format "{{.Names}}" --filter "publish=1433" 2>$null
$otherContainers = $allContainers | Where-Object { $_ -ne "caruna-db" }

if ($otherContainers) {
    Write-Host ""
    Write-Host "⚠️  Found other containers using port 1433:" -ForegroundColor Yellow
    foreach ($container in $otherContainers) {
        Write-Host "   - $container" -ForegroundColor Yellow
    }
    Write-Host ""
    Write-Host "🛑 Stopping conflicting containers..." -ForegroundColor Yellow
    foreach ($container in $otherContainers) {
        Write-Host "   Stopping $container..." -ForegroundColor Gray
        docker stop $container 2>$null | Out-Null
    }
    Write-Host "✓ Conflicting containers stopped" -ForegroundColor Green
} else {
    Write-Host "✓ No conflicting containers found" -ForegroundColor Green
}

Write-Host ""

# Tarkista onko caruna-db jo käynnissä
$carunaRunning = docker ps --format "{{.Names}}" | Select-String -Pattern "^caruna-db$" -Quiet

if ($carunaRunning) {
    Write-Host "✓ caruna-db is already running" -ForegroundColor Green
} else {
    Write-Host "🚀 Starting caruna-db..." -ForegroundColor Yellow
    docker-compose up -d
    
    # Odota että kontti käynnistyy
    Write-Host "⏳ Waiting for container to start..." -ForegroundColor Yellow
    $attempt = 0
    $maxAttempts = 10
    do {
        $attempt++
        Start-Sleep -Seconds 1
        $running = docker ps --format "{{.Names}}" | Select-String -Pattern "^caruna-db$" -Quiet
        if ($running) { break }
    } while ($attempt -lt $maxAttempts)
    
    if (-not $running) {
        Write-Host "❌ Failed to start container" -ForegroundColor Red
        exit 1
    }
    Write-Host "✓ Container started" -ForegroundColor Green
}

Write-Host ""

# Odota että SQL Server vastaa
Write-Host "⏳ Waiting for SQL Server to be ready (max 60 seconds)..." -ForegroundColor Yellow
$attempt = 0
$maxAttempts = 30

do {
    $attempt++
    Start-Sleep -Seconds 2
    if ($attempt -gt 1) {
        Write-Host "   Still waiting... ($attempt/$maxAttempts)" -ForegroundColor Gray
    }
    
    $result = docker exec caruna-db /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "DevPassword123!" -Q "SELECT 1" 2>$null
    if ($LASTEXITCODE -eq 0) { break }
} while ($attempt -lt $maxAttempts)

if ($LASTEXITCODE -eq 0) {
    Write-Host "✓ SQL Server is ready" -ForegroundColor Green
    Write-Host ""
    Write-Host "═══════════════════════════════════════════════════" -ForegroundColor Cyan
    Write-Host "  Database is running" -ForegroundColor Cyan
    Write-Host "═══════════════════════════════════════════════════" -ForegroundColor Cyan
    Write-Host "  Host:     localhost"
    Write-Host "  Port:     1433"
    Write-Host "  User:     SA"
    Write-Host "  Password: DevPassword123!"
    Write-Host "═══════════════════════════════════════════════════" -ForegroundColor Cyan
    Write-Host ""
    
    # Tarkista onko Fortum-kanta olemassa
    $dbExists = docker exec caruna-db /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "DevPassword123!" -Q "SELECT name FROM sys.databases WHERE name='Fortum'" -h -1 2>$null | Select-String "Fortum" -Quiet
    
    if ($dbExists) {
        Write-Host "✓ Fortum database exists" -ForegroundColor Green
        Write-Host ""
        Write-Host "Connect with:"
        Write-Host "  DBeaver / DataGrip / SSMS → localhost:1433"
        Write-Host ""
    } else {
        Write-Host "⚠️  Fortum database not found" -ForegroundColor Yellow
        Write-Host ""
        Write-Host "Restore the database with:"
        Write-Host "  .\database\scripts\restore.ps1"
        Write-Host ""
    }
} else {
    Write-Host "❌ SQL Server failed to start" -ForegroundColor Red
    Write-Host ""
    Write-Host "Check logs with:"
    Write-Host "  docker-compose logs sqlserver"
    Write-Host ""
    exit 1
}
