# Example React Container

A simple React application containerized with Docker, designed for testing container security scanning with Grype and Syft.

## 📋 Contents

- React 18 application built with Vite
- Multi-stage Docker build (Node.js builder + Nginx production)
- Nginx web server for production serving
- Health check endpoint
- Security headers configured

## 🚀 Quick Start

### Prerequisites

- Docker installed on your machine
- (Optional) Node.js 20+ for local development

## 🔨 Building the Container

### Basic Build

```bash
cd src/example_container
docker build -t example-react-app:latest .
```

### Build with Specific Tag

```bash
docker build -t example-react-app:v1.0.0 .
```

### Build with Custom Name

```bash
docker build -t myorg/myapp:latest .
```

## ▶️ Running the Container

### Run in Foreground

```bash
docker run -p 3000:3000 example-react-app:latest
```

### Run in Background (Detached Mode)

```bash
docker run -d -p 3000:3000 --name my-react-app example-react-app:latest
```

### Run with Custom Port

```bash
# Map container port 3000 to host port 8080
docker run -d -p 8080:3000 --name my-react-app example-react-app:latest
```

### Run with Auto-Restart

```bash
docker run -d -p 3000:3000 --name my-react-app --restart unless-stopped example-react-app:latest
```

## 🌐 Accessing the UI

Once the container is running, access the application in your browser:

- **Default URL**: http://localhost:3000
- **Health Check**: http://localhost:3000/health

You should see a simple React interface with a counter button and container status information.

## 🔍 Container Management

### List Running Containers

```bash
docker ps
```

### List All Containers (including stopped)

```bash
docker ps -a
```

### Stop the Container

```bash
docker stop my-react-app
```

### Start a Stopped Container

```bash
docker start my-react-app
```

### Restart the Container

```bash
docker restart my-react-app
```

### Remove the Container

```bash
# Stop first if running
docker stop my-react-app
docker rm my-react-app
```

### Force Remove Running Container

```bash
docker rm -f my-react-app
```

## 🖥️ Logging into the Container

### Execute a Shell in Running Container

```bash
# Using sh (Alpine Linux uses sh, not bash)
docker exec -it my-react-app sh
```

### Execute as Root User

```bash
docker exec -it -u root my-react-app sh
```

### Execute a Single Command

```bash
# Check nginx status
docker exec my-react-app ps aux

# List files in web root
docker exec my-react-app ls -la /usr/share/nginx/html

# Check nginx configuration
docker exec my-react-app cat /etc/nginx/conf.d/default.conf
```

### Explore the Container Filesystem

```bash
# Login to container
docker exec -it my-react-app sh

# Once inside:
cd /usr/share/nginx/html    # Web root with built React files
ls -la                       # List files
cat index.html              # View index file
exit                        # Exit container shell
```

## 📜 Reading Logs

### View All Logs

```bash
docker logs my-react-app
```

### Follow Logs in Real-Time

```bash
docker logs -f my-react-app
```

### View Last N Lines

```bash
# Last 50 lines
docker logs --tail 50 my-react-app
```

### View Logs with Timestamps

```bash
docker logs -t my-react-app
```

### View Logs Since Specific Time

```bash
# Logs from last 10 minutes
docker logs --since 10m my-react-app

# Logs from specific time
docker logs --since 2026-01-23T10:00:00 my-react-app
```

### Combine Options

```bash
# Follow last 100 lines with timestamps
docker logs -f --tail 100 -t my-react-app
```

## 🔐 Security Scanning

### Using the Docker Security Scan Action

This container is designed to work with the `docker-scan` GitHub Action:

```yaml
- uses: ./.github/actions/docker-scan
  with:
    working-directory: "./src/example_container"
    dockerfile-path: "./Dockerfile"
    image-name: "example-react-app"
    image-tag: "latest"
```

### Manual Security Scan with Grype

```bash
# Build the image first
docker build -t example-react-app:latest .

# Generate SBOM with Syft
syft example-react-app:latest -o json > sbom.json

# Scan with Grype
grype sbom:sbom.json --only-fixed
```

### Manual SBOM Generation

```bash
# JSON format
syft example-react-app:latest -o json > sbom.json

# SPDX format
syft example-react-app:latest -o spdx-json > sbom-spdx.json

# CycloneDX format
syft example-react-app:latest -o cyclonedx-json > sbom-cyclonedx.json
```

## 🛠️ Local Development (Without Docker)

If you want to develop locally without Docker:

```bash
# Install dependencies
npm install

# Run development server with hot reload
npm run dev

# Access at http://localhost:3000

# Build for production
npm run build

# Preview production build
npm run preview
```

## 🏗️ Container Architecture

### Multi-Stage Build

The Dockerfile uses a multi-stage build for optimal size and security:

1. **Builder Stage** (node:20-alpine)
   - Installs dependencies
   - Builds the React application
   - Creates optimized production bundle

2. **Production Stage** (nginx:alpine)
   - Copies only the built files
   - Runs lightweight Nginx server
   - Minimal attack surface

### Container Size

- **Builder stage**: ~500MB (discarded)
- **Final image**: ~25MB
- **Base image**: nginx:alpine (~40MB total)

## 📊 Health Checks

The container includes a health check that runs every 30 seconds:

```bash
# Check container health status
docker inspect --format='{{.State.Health.Status}}' my-react-app

# View health check logs
docker inspect --format='{{range .State.Health.Log}}{{.Output}}{{end}}' my-react-app
```

Health check endpoint: `http://localhost:3000/health`

## 🔧 Troubleshooting

### Container Won't Start

```bash
# Check logs for errors
docker logs my-react-app

# Inspect container details
docker inspect my-react-app
```

### Port Already in Use

```bash
# Find what's using port 3000
lsof -i :3000

# Or use a different port
docker run -p 8080:3000 example-react-app:latest
```

### Cannot Access UI

```bash
# Verify container is running
docker ps

# Check if port is mapped correctly
docker port my-react-app

# Test health endpoint
curl http://localhost:3000/health
```

### Build Failures

```bash
# Build with verbose output
docker build --progress=plain -t example-react-app:latest .

# Build without cache
docker build --no-cache -t example-react-app:latest .
```

## 🧹 Cleanup

### Remove All Related Resources

```bash
# Stop and remove container
docker stop my-react-app && docker rm my-react-app

# Remove image
docker rmi example-react-app:latest

# Remove all dangling images
docker image prune -f

# Remove all unused containers, networks, images
docker system prune -a
```

## 📝 Files Structure

```
example_container/
├── Dockerfile              # Multi-stage container definition
├── nginx.conf             # Nginx server configuration
├── .dockerignore          # Files to exclude from build
├── package.json           # Node.js dependencies
├── vite.config.js        # Vite build configuration
├── index.html            # HTML entry point
├── src/
│   ├── main.jsx          # React entry point
│   ├── App.jsx           # Main App component
│   ├── App.css           # App styles
│   └── index.css         # Global styles
└── README.md             # This file
```

## 🎯 Use Cases

This example container is perfect for:

- Testing Docker security scanning workflows
- Learning Docker containerization
- CI/CD pipeline testing
- Container orchestration practice
- Security tooling demonstrations
- SBOM generation examples

## 📚 Additional Resources

- [Docker Documentation](https://docs.docker.com/)
- [React Documentation](https://react.dev/)
- [Vite Documentation](https://vitejs.dev/)
- [Nginx Documentation](https://nginx.org/en/docs/)
- [Grype Security Scanner](https://github.com/anchore/grype)
- [Syft SBOM Generator](https://github.com/anchore/syft)
