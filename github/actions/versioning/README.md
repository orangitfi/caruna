# Version Composite Action

This GitHub Actions composite action automates version management using GitVersion. It determines version numbers based on your git history and handles version tagging for your releases.

## Features

- Automatically determines version numbers using GitVersion
- Handles both main branch and development versions
- Creates and pushes version tags for releases
- Supports semantic versioning

## Usage

```yaml
- uses: ./.github/actions/versioning
```

## Behavior

The action performs the following steps:

1. **Checkout**: Checks out the repository code
2. **Fetch History**: Fetches complete git history and tags
3. **GitVersion Setup**: Installs GitVersion 5.x
4. **Version Calculation**: Runs GitVersion to determine the current version
5. **Version Setting**:
   - For `main` branch: Sets version as `major.minor.patch`
   - For other branches: Sets version as `major.minor.patch-dev{run_number}`
6. **Tag Creation**: For the main branch, creates and pushes a version tag

## Requirements

- A `GitVersion.yml` configuration file in your repository root
- GitVersion 5.x compatibility

## Environment Variables

The action sets the following environment variable:
- `CUSTOM_VERSION`: The calculated version number

## Notes

- The action uses GitVersion's semantic versioning capabilities
- Tags are only created on the main branch
- Development versions include the GitHub Actions run number
- The action requires full git history to work correctly

## Example Output

For main branch:
```
CUSTOM_VERSION=1.2.3
```

For development branch:
```
CUSTOM_VERSION=1.2.3-dev42
``` 
