# Node.js Setup Action

This GitHub Action sets up a Node.js environment with common tools and configurations for your workflow.

## Features

- Configurable Node.js version
- Automatic dependency caching
- Flexible installation commands
- Customizable working directory
- Uses latest stable versions of core actions

## Usage

```yaml
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: ./.github/actions/setup
        with:
          node-version: '20.x'
          cache-dependency-path: '**/package-lock.json'
          install-command: 'npm ci'
          working-directory: '.'
```

## Inputs

| Input | Description | Required | Default |
|-------|-------------|----------|---------|
| `node-version` | Version of Node.js to use | Yes | '20.x' |
| `cache-dependency-path` | Path to package-lock.json or yarn.lock | No | '**/package-lock.json' |
| `install-command` | Command to install dependencies | No | 'npm ci' |
| `working-directory` | Working directory to run commands in | No | '.' |

## Example Workflows

### Basic Usage
```yaml
name: Basic Node.js Workflow

on: [push, pull_request]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: ./.github/actions/setup
```

### Custom Configuration
```yaml
name: Custom Node.js Workflow

on: [push, pull_request]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: ./.github/actions/setup
        with:
          node-version: '18.x'
          cache-dependency-path: 'frontend/package-lock.json'
          install-command: 'yarn install --frozen-lockfile'
          working-directory: 'frontend'
```

## Notes

- The action uses `actions/checkout@v4` and `actions/setup-node@v4`
- NPM caching is enabled by default for faster installations
- The default installation command uses `npm ci` for clean installs
- The action is designed to be reusable across different Node.js projects 
