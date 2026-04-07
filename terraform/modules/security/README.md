# Security Module

This module manages security-related resources including security groups, IAM roles, and policies for the ECS infrastructure.

## Features

- Security groups for ALB and ECS tasks
- IAM roles and policies with least privilege
- Security group rules for container access
- Environment-specific security configurations

## Usage

```hcl
module "security" {
  source = "../../modules/security"

  environment    = "staging"
  vpc_id         = module.network.vpc_id
  container_port = 80

  tags = {
    Environment = "staging"
    Project     = "example"
  }
}
```

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| environment | Environment name | string | - | yes |
| vpc_id | VPC ID where security groups will be created | string | - | yes |
| container_port | Port exposed by the container | number | 80 | no |
| tags | A map of tags to add to all resources | map(string) | {} | no |

## Outputs

| Name | Description |
|------|-------------|
| alb_security_group_id | ID of the ALB security group |
| ecs_task_security_group_id | ID of the ECS task security group |

## Security Considerations

- Security groups follow the principle of least privilege
- Inbound rules only allow necessary traffic
- Outbound rules allow all traffic (can be restricted if needed)
- Security groups are environment-specific
- IAM roles follow least privilege principle

## Maintenance

- Regular review of security group rules
- Audit of IAM permissions
- Update security configurations as needed
- Monitor security group changes

## Requirements

| Name | Version |
|------|---------|
| terraform | >= 1.0.0 |
| aws | ~> 5.0 |

## License

This module is licensed under the MIT License. 