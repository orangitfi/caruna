# ECS Compute Module

This module creates an ECS cluster with Fargate tasks, including an Application Load Balancer, auto-scaling, and monitoring capabilities.

## Features

- ECS Cluster with Fargate launch type
- Application Load Balancer with health checks
- Auto-scaling based on CPU, memory, and request count
- CloudWatch monitoring and logging
- IAM roles with least privilege
- Security groups for ALB and ECS tasks

## Usage

```hcl
module "compute" {
  source = "../../modules/compute"

  environment           = "staging"
  aws_region           = "eu-north-1"
  vpc_id               = module.network.vpc_id
  public_subnet_ids    = module.network.public_subnet_ids
  private_subnet_ids   = module.network.private_subnet_ids
  alb_security_group_id = module.security.alb_security_group_id
  container_image      = "nginx:latest"
  container_port       = 80
  task_cpu             = 256
  task_memory          = 512
  min_capacity         = 1
  max_capacity         = 10

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
| aws_region | AWS region | string | - | yes |
| vpc_id | VPC ID | string | - | yes |
| public_subnet_ids | Public subnet IDs for ALB | list(string) | - | yes |
| private_subnet_ids | Private subnet IDs for ECS tasks | list(string) | - | yes |
| alb_security_group_id | Security group ID for ALB | string | - | yes |
| container_image | Container image to use | string | - | yes |
| container_port | Port exposed by the container | number | 80 | no |
| task_cpu | CPU units for the ECS task | number | 256 | no |
| task_memory | Memory for the ECS task in MB | number | 512 | no |
| min_capacity | Minimum number of tasks | number | 1 | no |
| max_capacity | Maximum number of tasks | number | 10 | no |

## Outputs

| Name | Description |
|------|-------------|
| cluster_id | The ID of the ECS cluster |
| cluster_name | Name of the ECS cluster |
| service_name | Name of the ECS service |
| task_definition_arn | ARN of the task definition |
| load_balancer_dns | DNS name of the load balancer |
| target_group_arn | ARN of the target group |
| ecs_task_security_group_id | ID of the ECS task security group |
| log_group_name | Name of the CloudWatch log group |

## Security Considerations

- ECS tasks run in private subnets
- Security groups restrict traffic to necessary ports
- IAM roles follow least privilege principle
- Container insights enabled for monitoring
- Auto-scaling with circuit breaker for deployment safety

## Maintenance

- Regular updates of container images
- Monitoring of CloudWatch metrics
- Review of auto-scaling policies
- Regular security group audits

## Requirements

| Name | Version |
|------|---------|
| terraform | >= 1.0.0 |
| aws | >= 4.0.0 |

## License

This module is licensed under the MIT License. 