# Secrets Management Module

This module implements secure secrets management using AWS Secrets Manager and KMS.

## Features

- KMS key for secrets encryption
- Secrets Manager for secure secret storage
- IAM policies for least privilege access
- Secret rotation monitoring
- CloudWatch alarms for rotation status
- Environment-specific secrets

## Usage

```hcl
module "secrets" {
  source = "../../modules/secrets"

  environment         = "staging"
  ecs_task_role_name = module.compute.ecs_task_role_name
  sns_topic_arn      = module.monitoring.sns_topic_arn

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
| ecs_task_role_name | Name of the ECS task role | string | - | yes |
| sns_topic_arn | ARN of the SNS topic for alerts | string | - | yes |
| tags | A map of tags to add to all resources | map(string) | {} | no |

## Outputs

| Name | Description |
|------|-------------|
| kms_key_id | ID of the KMS key |
| kms_key_arn | ARN of the KMS key |
| app_secret_arn | ARN of the application secrets |
| db_secret_arn | ARN of the database secrets |
| secrets_access_policy_arn | ARN of the IAM policy |

## Security Features

### KMS Encryption
- Customer managed KMS key
- Automatic key rotation
- 7-day deletion window
- Proper key policies

### Secrets Manager
- Environment-specific secrets
- Automatic secret rotation
- Access logging
- Version tracking

### IAM Integration
- Least privilege access
- Role-based access control
- Policy attachment to ECS tasks
- Secure secret retrieval

## Monitoring

- Secret rotation monitoring
- CloudWatch alarms
- SNS notifications
- Access logging

## Maintenance

- Regular key rotation
- Secret rotation monitoring
- Access policy reviews
- Audit logging review

## Requirements

| Name | Version |
|------|---------|
| terraform | >= 1.0.0 |
| aws | ~> 5.0 |

## License

This module is licensed under the MIT License. 