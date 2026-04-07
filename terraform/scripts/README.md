# Repository Setup Scripts

This directory contains scripts for setting up and configuring the repository.

## GitHub Repository Setup

The `setup-github-repo.sh` script automates the configuration of GitHub repository settings, branch protection rules, and issue templates.

### Prerequisites

1. GitHub CLI (`gh`) must be installed:
   ```bash
   # macOS
   brew install gh

   # Ubuntu/Debian
   sudo apt install gh

   # Windows
   winget install GitHub.cli
   ```

2. GitHub CLI authentication:
   ```bash
   gh auth login
   ```

3. The repository must be initialized with git and have a remote origin set to GitHub.

### Usage

1. Make the script executable:
   ```bash
   chmod +x scripts/setup-github-repo.sh
   ```

2. Run the script:
   ```bash
   ./scripts/setup-github-repo.sh
   ```

### What the Script Does

1. **Branch Protection**:
   - Protects `main`, `staging`, and `develop` branches
   - Requires status checks:
     - terraform-plan
     - run-tests
     - check-documentation
   - Enforces pull request reviews
   - Requires at least one approval
   - Enforces admin rules

2. **Repository Settings**:
   - Enables auto-merge
   - Configures merge strategies:
     - Disables merge commits
     - Enables squash merges
     - Enables rebase merges
   - Enables branch deletion after merge

3. **Issue Templates**:
   - Bug report template
   - Feature request template
   - Security issue template

### Verification

After running the script, verify the settings in the GitHub repository settings page:
```
https://github.com/<username>/<repository>/settings
```

### Troubleshooting

1. **Script fails with "gh not found"**:
   - Ensure GitHub CLI is installed
   - Verify the installation by running `gh --version`

2. **Authentication errors**:
   - Run `gh auth login` to authenticate
   - Ensure you have the necessary permissions for the repository

3. **Repository not found**:
   - Verify the remote origin is set correctly
   - Check if you have access to the repository

4. **Permission denied**:
   - Ensure you have admin access to the repository
   - Check if you're authenticated with the correct account

### Manual Steps (if needed)

If the script fails, you can manually configure the settings in GitHub:

1. Go to repository Settings > Branches
2. Add branch protection rule for `main`, `staging`, and `develop`
3. Enable required status checks
4. Configure pull request reviews
5. Set up issue templates in `.github/ISSUE_TEMPLATE/ 