# Network Module

This module creates a VPC with public and private subnets across multiple availability zones.

## Features

- Creates a VPC with DNS support
- Creates public and private subnets
- Supports multiple availability zones
- Implements proper tagging
- Follows security best practices

## Usage

```hcl
module "network" {
  source = "../../modules/network"

  environment = "dev"
  vpc_cidr    = "10.0.0.0/16"

  public_subnets  = ["10.0.1.0/24", "10.0.2.0/24"]
  private_subnets = ["10.0.3.0/24", "10.0.4.0/24"]

  availability_zones = ["us-west-2a", "us-west-2b"]

  tags = {
    Environment = "dev"
    Project     = "my-project"
  }
}
```

## Requirements

| Name | Version |
|------|---------|
| terraform | >= 1.0.0 |
| aws | >= 4.0.0 |

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| environment | Environment name (e.g., dev, staging, prod) | `string` | n/a | yes |
| vpc_cidr | CIDR block for the VPC | `string` | n/a | yes |
| public_subnets | List of public subnet CIDR blocks | `list(string)` | n/a | yes |
| private_subnets | List of private subnet CIDR blocks | `list(string)` | n/a | yes |
| availability_zones | List of availability zones | `list(string)` | n/a | yes |
| tags | A map of tags to add to all resources | `map(string)` | `{}` | no |

## Outputs

| Name | Description |
|------|-------------|
| vpc_id | The ID of the VPC |
| public_subnet_ids | List of public subnet IDs |
| private_subnet_ids | List of private subnet IDs |
| vpc_cidr_block | The CIDR block of the VPC |

## Security Considerations

- Public subnets are created but require explicit configuration for internet access
- Private subnets are isolated from direct internet access
- All resources are properly tagged for security and compliance
- Follows AWS security best practices

## Maintenance

- Regular updates to AWS provider version
- Security patches and updates
- Documentation updates
- Performance optimization

## License

This module is licensed under the MIT License. 