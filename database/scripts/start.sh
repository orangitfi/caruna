#!/bin/bash
set -e

echo "═══════════════════════════════════════════════════"
echo "  Caruna - Start Database Container"
echo "═══════════════════════════════════════════════════"
echo ""

# Tarkista että docker-compose.yml löytyy
if [ ! -f "docker-compose.yml" ]; then
    echo "❌ Error: docker-compose.yml not found!"
    echo "   Please run this script from the project root directory."
    exit 1
fi

# Etsi muut SQL Server -kontit jotka käyttävät porttia 1433
echo "🔍 Checking for other SQL Server containers using port 1433..."
OTHER_CONTAINERS=$(docker ps --format '{{.Names}}' --filter "publish=1433" | grep -v "caruna-db" || true)

if [ -n "$OTHER_CONTAINERS" ]; then
    echo ""
    echo "⚠️  Found other containers using port 1433:"
    echo "$OTHER_CONTAINERS" | while read container; do
        echo "   - $container"
    done
    echo ""
    echo "🛑 Stopping conflicting containers..."
    echo "$OTHER_CONTAINERS" | while read container; do
        echo "   Stopping $container..."
        docker stop "$container" > /dev/null 2>&1 || true
    done
    echo "✓ Conflicting containers stopped"
else
    echo "✓ No conflicting containers found"
fi

echo ""

# Tarkista onko caruna-db jo käynnissä
if docker ps --format '{{.Names}}' | grep -q "^caruna-db$"; then
    echo "✓ caruna-db is already running"
else
    echo "🚀 Starting caruna-db..."
    docker-compose up -d
    
    # Odota että kontti on käynnissä
    echo "⏳ Waiting for container to start..."
    COUNTER=0
    until docker ps --format "{{.Names}}" | grep -q "^caruna-db$"; do
        if [ $COUNTER -ge 10 ]; then
            echo "❌ Failed to start container"
            exit 1
        fi
        sleep 1
        COUNTER=$((COUNTER + 1))
    done
    echo "✓ Container started"
fi

echo ""

# Odota että SQL Server vastaa
echo "⏳ Waiting for SQL Server to be ready (max 60 seconds)..."
MAX_WAIT=60
COUNTER=0
until docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "DevPassword123!" -C -Q "SELECT 1" > /dev/null 2>&1; do
    if [ $COUNTER -ge $MAX_WAIT ]; then
        echo "❌ Timeout waiting for SQL Server"
        exit 1
    fi
    echo "   Still waiting..."
    sleep 3
    COUNTER=$((COUNTER + 3))
done

if [ $? -eq 0 ]; then
    echo "✓ SQL Server is ready"
    echo ""
    echo "═══════════════════════════════════════════════════"
    echo "  Database is running"
    echo "═══════════════════════════════════════════════════"
    echo "  Host:     localhost"
    echo "  Port:     1433"
    echo "  User:     SA"
    echo "  Password: DevPassword123!"
    echo "═══════════════════════════════════════════════════"
    echo ""
    
    # Tarkista onko Fortum-kanta olemassa
    if docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P "DevPassword123!" -C -Q "SELECT name FROM sys.databases WHERE name='Fortum'" -h -1 2>/dev/null | grep -q "Fortum"; then
        echo "✓ Fortum database exists"
        echo ""
        echo "Connect with:"
        echo "  DBeaver / DataGrip / SSMS → localhost:1433"
        echo ""
    else
        echo "⚠️  Fortum database not found"
        echo ""
        echo "Restore the database with:"
        echo "  ./database/scripts/restore.sh"
        echo ""
    fi
else
    echo "❌ SQL Server failed to start"
    echo ""
    echo "Check logs with:"
    echo "  docker-compose logs sqlserver"
    echo ""
    exit 1
fi
