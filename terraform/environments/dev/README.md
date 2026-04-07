# Development Environment

This directory contains the Terraform configuration for the development environment.

## Overview

The development environment is configured with:
- A VPC with public and private subnets
- Multiple availability zones
- Proper tagging for resource management
- State management using S3 and DynamoDB

## Prerequisites

1. AWS CLI configured with appropriate credentials
2. S3 bucket for Terraform state
3. DynamoDB table for state locking
4. Terraform >= 1.0.0

## Configuration

1. Update the backend configuration in `versions.tf`:
   ```hcl
   backend "s3" {
     bucket         = "your-terraform-state-bucket"
     key            = "dev/terraform.tfstate"
     region         = "us-west-2"
     dynamodb_table = "terraform-state-lock"
     encrypt        = true
   }
   ```

2. Initialize Terraform:
   ```bash
   terraform init
   ```

3. Review the plan:
   ```bash
   terraform plan
   ```

4. Apply the configuration:
   ```bash
   terraform apply
   ```

## Variables

| Name | Description | Type | Default |
|------|-------------|------|---------|
| aws_region | AWS region | `string` | `"us-west-2"` |
| project_name | Name of the project | `string` | `"terraform-template"` |
| vpc_cidr | CIDR block for the VPC | `string` | `"10.0.0.0/16"` |
| public_subnets | List of public subnet CIDR blocks | `list(string)` | `["10.0.1.0/24", "10.0.2.0/24"]` |
| private_subnets | List of private subnet CIDR blocks | `list(string)` | `["10.0.3.0/24", "10.0.4.0/24"]` |
| availability_zones | List of availability zones | `list(string)` | `["us-west-2a", "us-west-2b"]` |

## Outputs

| Name | Description |
|------|-------------|
| vpc_id | The ID of the VPC |
| public_subnet_ids | List of public subnet IDs |
| private_subnet_ids | List of private subnet IDs |
| vpc_cidr_block | The CIDR block of the VPC |

## Security

- State file encryption enabled
- State locking using DynamoDB
- Proper IAM roles and policies
- Network isolation between public and private subnets

## Maintenance

- Regular updates to AWS provider version
- Security patches and updates
- Documentation updates
- Performance optimization

## Troubleshooting

1. If you encounter state locking issues:
   ```bash
   terraform force-unlock <LOCK_ID>
   ```

2. If you need to reinitialize:
   ```bash
   terraform init -reconfigure
   ```

## License

This environment configuration is licensed under the MIT License. 