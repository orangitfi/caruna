#!/bin/bash

# Exit on error
set -e

# Check if gh CLI is installed
if ! command -v gh &> /dev/null; then
    echo "GitHub CLI (gh) is not installed. Please install it first."
    echo "Visit: https://cli.github.com/manual/installation"
    exit 1
fi

# Check if user is authenticated
if ! gh auth status &> /dev/null; then
    echo "Please authenticate with GitHub first:"
    gh auth login
fi

# Get repository name from git config
REPO_NAME=$(git config --get remote.origin.url | sed 's/.*github.com[:/]//' | sed 's/\.git$//')
if [ -z "$REPO_NAME" ]; then
    echo "Could not determine repository name. Please run this script from a git repository."
    exit 1
fi

echo "Setting up repository settings for: $REPO_NAME"

# Enable branch protection for main, staging, and develop branches
for BRANCH in main staging develop; do
    echo "Setting up protection rules for $BRANCH branch..."
    
    # Create branch protection rule
    gh api repos/$REPO_NAME/branches/$BRANCH/protection \
        -X PUT \
        -H "Accept: application/vnd.github.v3+json" \
        -f required_status_checks='{"strict":true,"contexts":["terraform-plan","run-tests","check-documentation"]}' \
        -f enforce_admins=true \
        -f required_pull_request_reviews='{"dismissal_restrictions":{},"dismiss_stale_reviews":true,"require_code_owner_reviews":true,"required_approving_review_count":1}' \
        -f restrictions=null
done

# Set up repository settings
echo "Configuring repository settings..."

# Enable auto-merge
gh api repos/$REPO_NAME -X PATCH \
    -H "Accept: application/vnd.github.v3+json" \
    -f allow_auto_merge=true \
    -f allow_merge_commit=false \
    -f allow_squash_merge=true \
    -f allow_rebase_merge=true \
    -f delete_branch_on_merge=true

# Set up branch rules
echo "Setting up branch rules..."

# Create branch rules
gh api repos/$REPO_NAME/rules/branches \
    -X POST \
    -H "Accept: application/vnd.github.v3+json" \
    -f name="feature/*" \
    -f protection='{"required_status_checks":null,"enforce_admins":false,"required_pull_request_reviews":null,"restrictions":null}'

# Set up issue templates
echo "Setting up issue templates..."

# Create issue template directory if it doesn't exist
mkdir -p .github/ISSUE_TEMPLATE

# Create bug report template
cat > .github/ISSUE_TEMPLATE/bug_report.md << 'EOF'
---
name: Bug Report
about: Create a report to help us improve
title: '[BUG] '
labels: bug
assignees: ''
---

**Describe the bug**
A clear and concise description of what the bug is.

**To Reproduce**
Steps to reproduce the behavior:
1. Go to '...'
2. Click on '....'
3. See error

**Expected behavior**
A clear and concise description of what you expected to happen.

**Screenshots**
If applicable, add screenshots to help explain your problem.

**Environment:**
 - OS: [e.g. Ubuntu 20.04]
 - Terraform Version: [e.g. 1.0.0]
 - AWS Provider Version: [e.g. 4.0.0]

**Additional context**
Add any other context about the problem here.
EOF

# Create feature request template
cat > .github/ISSUE_TEMPLATE/feature_request.md << 'EOF'
---
name: Feature Request
about: Suggest an idea for this project
title: '[FEATURE] '
labels: enhancement
assignees: ''
---

**Is your feature request related to a problem? Please describe.**
A clear and concise description of what the problem is.

**Describe the solution you'd like**
A clear and concise description of what you want to happen.

**Describe alternatives you've considered**
A clear and concise description of any alternative solutions or features you've considered.

**Additional context**
Add any other context or screenshots about the feature request here.
EOF

# Create security issue template
cat > .github/ISSUE_TEMPLATE/security.md << 'EOF'
---
name: Security Issue
about: Report a security vulnerability
title: '[SECURITY] '
labels: security
assignees: ''
---

**Describe the security issue**
A clear and concise description of the security vulnerability.

**Impact**
Describe the potential impact of this security issue.

**Steps to reproduce**
Steps to reproduce the behavior:
1. Go to '...'
2. Click on '....'
3. See vulnerability

**Expected behavior**
A clear and concise description of what you expected to happen.

**Environment:**
 - OS: [e.g. Ubuntu 20.04]
 - Terraform Version: [e.g. 1.0.0]
 - AWS Provider Version: [e.g. 4.0.0]

**Additional context**
Add any other context about the security issue here.
EOF

# Commit and push the new files
git add .github/ISSUE_TEMPLATE/
git commit -m "Add issue templates" || true
git push origin main

echo "Repository setup complete!"
echo "Please verify the settings in the GitHub repository settings page."
echo "URL: https://github.com/$REPO_NAME/settings" 