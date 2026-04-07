# Branch Protection Rules

This document outlines the branch protection rules and branching strategy for the Terraform template repository.

## Branch Structure

### Main Branches
- `main` - Production environment
- `staging` - Staging environment
- `develop` - Development environment

### Feature Branches
- `feature/*` - Feature development branches
  - `feature/compute`
  - `feature/network`
  - `feature/security`
  - `feature/monitoring`
  - `feature/cost-tracking`
  - `feature/secrets`

## Protection Rules

### `main` Branch
- Requires pull request reviews before merging
- Requires status checks to pass before merging
  - Terraform plan must succeed
  - All tests must pass
  - Documentation must be up to date
- Requires branches to be up to date before merging
- No direct pushes allowed
- Requires linear history
- Requires signed commits
- Requires conversation resolution
- Restricts who can push to matching branches
  - Only repository administrators and release managers

### `staging` Branch
- Requires pull request reviews before merging
- Requires status checks to pass before merging
  - Terraform plan must succeed
  - All tests must pass
- Requires branches to be up to date before merging
- No direct pushes allowed
- Requires conversation resolution
- Restricts who can push to matching branches
  - Only repository administrators and release managers

### `develop` Branch
- Requires pull request reviews before merging
- Requires status checks to pass before merging
  - Terraform plan must succeed
  - All tests must pass
- Requires branches to be up to date before merging
- No direct pushes allowed
- Requires conversation resolution

### Feature Branches
- No protection rules
- Developers can push directly
- Must be created from `develop`
- Must be named according to the pattern `feature/*`

## Branch Lifecycle

1. **Feature Development**
   - Create feature branch from `develop`
   - Develop and test changes
   - Create pull request to `develop`
   - Address review comments
   - Merge to `develop` after approval

2. **Staging Deployment**
   - Create pull request from `develop` to `staging`
   - Run integration tests
   - Verify in staging environment
   - Merge to `staging` after approval

3. **Production Deployment**
   - Create pull request from `staging` to `main`
   - Run final verification
   - Tag release
   - Merge to `main` after approval

## Pull Request Requirements

### Required Reviewers
- At least one repository administrator
- At least one subject matter expert for the affected module
- All reviewers must approve

### Required Status Checks
- Terraform plan must succeed
- All tests must pass
- Documentation must be up to date
- No merge conflicts
- Branch must be up to date

### Pull Request Template
- Description of changes
- Related issue(s)
- Testing performed
- Documentation updates
- Security considerations
- Breaking changes (if any)

## Release Process

1. **Version Bumping**
   - Update version in `versions.tf`
   - Update CHANGELOG.md
   - Create version tag

2. **Release Steps**
   - Create release branch from `main`
   - Run final verification
   - Create GitHub release
   - Merge back to `develop`

## Emergency Fixes

For critical fixes that need to bypass normal process:

1. Create `hotfix/*` branch from `main`
2. Fix the issue
3. Create pull requests to both `main` and `develop`
4. Get expedited review
5. Merge to both branches
6. Create new release

## Branch Cleanup

- Feature branches should be deleted after merging
- Release branches should be deleted after release
- Hotfix branches should be deleted after merging
- Stale branches will be automatically deleted after 30 days of inactivity 