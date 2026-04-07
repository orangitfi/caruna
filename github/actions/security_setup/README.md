# Security Setup GitHub Action

This GitHub Action installs essential security scanning tools for container and dependency analysis:
- [Syft](https://github.com/anchore/syft): A CLI tool and library for generating a Software Bill of Materials (SBOM) from container images and filesystems
- [Grype](https://github.com/anchore/grype): A vulnerability scanner for container images and filesystems

## Usage

```yaml
- uses: ./.github/actions/security_setup
```

## What This Action Does

This action performs two main tasks:

1. Installs Syft, which helps you:
   - Generate SBOMs from container images
   - Analyze filesystem contents
   - Identify software packages and dependencies

2. Installs Grype, which helps you:
   - Scan container images and filesystems for vulnerabilities
   - Match against vulnerability databases
   - Generate security reports

## Requirements

- This action runs on Linux-based runners
- Requires `curl` to be available in the environment

## Output

The action installs both tools to `/usr/local/bin`, making them available for subsequent steps in your workflow.

## Example Workflow

```yaml
name: Security Scan

on: [push, pull_request]

jobs:
  security:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      
      - name: Setup Security Tools
        uses: ./.github/actions/security_setup
        
      - name: Generate SBOM
        run: syft your-image:tag
        
      - name: Scan for Vulnerabilities
        run: grype your-image:tag
```

## License

This action is part of your project and follows your project's license terms. 
