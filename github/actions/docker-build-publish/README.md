# Docker Build and Publish Action

This GitHub Action builds and publishes Docker images with built-in security features including Software Bill of Materials (SBOM) generation and vulnerability scanning.

## Features

- 🔒 **Security First**: Includes SBOM generation and vulnerability scanning
- 🏗️ **Docker Buildx**: Uses Docker Buildx for efficient builds
- 🔍 **Vulnerability Scanning**: Integrates Grype for security scanning
- 📦 **SBOM Generation**: Uses Syft to generate Software Bill of Materials
- 🔐 **Secure Authentication**: Handles Docker registry authentication securely

## Usage

```yaml
jobs:
  build-and-publish:
    runs-on: ubuntu-latest
    steps:
      - uses: ./.github/actions/docker-build-publish
        with:
          working-directory: '.'  # Directory containing your source code and Dockerfile
          dockerfile-path: './Dockerfile'  # Path to your Dockerfile
          docker-registry: 'ghcr.io'  # Container registry (e.g., ghcr.io, docker.io)
          docker-repository: 'myorg'  # Your repository/organization name
          docker-image-name: 'myapp'  # Name for your Docker image
          docker-tag: ${{ github.sha }}  # Version tag for the image
          docker-user: ${{ secrets.DOCKER_USER }}  # Registry username
          docker-password: ${{ secrets.DOCKER_PASSWORD }}  # Registry password/token
```

## Inputs

| Input | Required | Description |
|-------|----------|-------------|
| `working-directory` | Yes | Path to the directory containing Dockerfile and source code |
| `dockerfile-path` | Yes | Relative path to the Dockerfile (from working directory) |
| `docker-registry` | Yes | Docker registry (e.g. docker.io, ghcr.io) |
| `docker-repository` | Yes | Docker repository (e.g. samibister) |
| `docker-image-name` | Yes | Name of the Docker image (e.g., myorg/myimage) |
| `docker-tag` | Yes | Docker image tag (e.g., latest, 1.0.0, commit-SHA) |
| `docker-user` | Yes | Docker username |
| `docker-password` | Yes | Docker password or token |

## Workflow

The action performs the following steps:

1. Sets up Docker Buildx
2. Builds the Docker image
3. Generates SBOM using Syft
4. Performs security scan using Grype
5. Logs into the Docker registry
6. Pushes the Docker image
7. Logs out from the Docker registry
8. Cleans up temporary files

## Security Features

### SBOM Generation
The action generates a Software Bill of Materials (SBOM) using Syft, which provides a detailed inventory of all components in your Docker image.

### Vulnerability Scanning
Grype is used to scan the generated SBOM for known vulnerabilities. The scan fails if high-severity vulnerabilities are found.

## Best Practices

1. Always use secrets for Docker credentials
2. Use specific tags for production images
3. Regularly update your base images
4. Review security scan results
5. Keep your Dockerfile in version control

## Example

Here's a complete example of how to use this action in your workflow:

```yaml
name: Build and Publish Docker Image

on:
  push:
    branches: [ main ]

jobs:
  build-and-publish:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      
      - uses: ./.github/actions/docker-build-publish
        with:
          working-directory: '.'
          dockerfile-path: './Dockerfile'
          docker-registry: 'ghcr.io'
          docker-repository: 'myorg'
          docker-image-name: 'myapp'
          docker-tag: ${{ github.sha }}
          docker-user: ${{ secrets.DOCKER_USER }}
          docker-password: ${{ secrets.DOCKER_PASSWORD }}
``` 
