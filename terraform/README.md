# Terraform Template

This repository contains a standardized Terraform template structure following industry best practices for infrastructure as code (IaC) implementation.

## Overview

This template provides a consistent and maintainable structure for managing infrastructure across multiple environments using Terraform. It includes:

- Modular architecture
- Environment separation
- Security best practices
- Comprehensive documentation
- Testing framework
- State management
- Version control
- GitHub repository protection
- Automated workflows

## Prerequisites

- Terraform >= 1.0.0
- AWS CLI (for AWS resources)
- Git
- GitHub CLI (for repository setup)
- Make (optional, for using Makefile commands)

## Project Structure

```
.
├── environments/           # Environment-specific configurations
│   ├── dev/               # Development environment
│   ├── staging/           # Staging environment
│   └── prod/              # Production environment
├── modules/               # Reusable Terraform modules
│   ├── network/          # Network-related resources
│   ├── compute/          # Compute resources
│   └── security/         # Security-related resources
├── scripts/              # Helper scripts and utilities
├── .github/             # GitHub configuration
│   ├── workflows/       # GitHub Actions workflows
│   └── ISSUE_TEMPLATE/  # Issue templates
└── docs/                # Additional documentation
```

## Getting Started

1. Clone this repository:
   ```bash
   git clone <repository-url>
   cd terraform-template
   ```

2. Set up GitHub repository (if not already done):
   ```bash
   ./scripts/setup-github-repo.sh
   ```

3. Initialize Terraform:
   ```bash
   terraform init
   ```

4. Select your environment:
   ```bash
   cd environments/dev  # or staging/prod
   ```

5. Apply the configuration:
   ```bash
   terraform plan
   terraform apply
   ```

## Module Usage

Each module in the `modules/` directory is self-contained and follows a consistent structure. To use a module:

```hcl
module "example" {
  source = "../../modules/network"

  # Required variables
  environment = "dev"
  region     = "us-west-2"

  # Optional variables
  tags = {
    Project     = "MyProject"
    Environment = "dev"
  }
}
```

## Environment Management

Each environment (dev, staging, prod) has its own:
- State file
- Variable definitions
- Security controls
- Resource configurations

## Security

- All sensitive data is encrypted
- IAM roles follow least privilege principle
- Regular security audits are performed
- Secrets are managed securely
- Branch protection rules enforced
- Required pull request reviews
- Automated security checks

## Contributing

1. Fork the repository
2. Create a feature branch from `develop`
3. Commit your changes
4. Push to the branch
5. Create a Pull Request
6. Ensure all checks pass
7. Get required approvals
8. Merge to `develop`

### Branch Strategy

- `main` - Production environment
- `staging` - Staging environment
- `develop` - Development environment
- `feature/*` - Feature branches
- `hotfix/*` - Emergency fixes

See [Branch Protection Rules](.github/BRANCH_PROTECTION.md) for detailed information.

## Testing

Run the test suite:
```bash
make test
```

## Documentation

- [Design Decisions](DESIGN.md)
- [Architecture Documentation](docs/architecture.md)
- [Security Guidelines](docs/security.md)
- [Module Documentation](modules/README.md)
- [Environment Setup](environments/README.md)
- [Branch Protection Rules](.github/BRANCH_PROTECTION.md)
- [Scripts Documentation](scripts/README.md)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

For support, please open an issue in the repository or contact the maintainers.

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for a list of changes. 