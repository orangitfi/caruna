# Production Environment

This directory contains the Terraform configuration for the production environment. The production environment is designed for high availability, security, and performance.

## Environment-Specific Configurations

### Network Configuration
- VPC CIDR: 10.2.0.0/16
- Public Subnets: 3 subnets across 3 availability zones
- Private Subnets: 3 subnets across 3 availability zones
- Availability Zones: us-west-2a, us-west-2b, us-west-2c

### Compute Resources
- ECS Task CPU: 1024 units
- ECS Task Memory: 2048 MB
- Service Desired Count: 3 instances
- Container Image: Latest stable version

### Security
- Strict logging level (warn)
- Production-specific security groups
- KMS encryption for sensitive data
- Enhanced monitoring and alerting

## Usage

1. Initialize Terraform:
```bash
terraform init
```

2. Review the planned changes:
```bash
terraform plan
```

3. Apply the configuration:
```bash
terraform apply
```

## Important Considerations

### High Availability
- The production environment uses multiple availability zones for redundancy
- Load balancer is configured for high availability
- Auto-scaling policies are in place for handling traffic spikes

### Security
- All resources are tagged with environment=prod
- Strict security group rules
- Regular security audits and compliance checks
- Enhanced monitoring and alerting

### Maintenance
- Regular backups of state files
- Automated testing before deployments
- Change management process required for modifications
- Regular security updates and patches

### Monitoring
- CloudWatch alarms for critical metrics
- Enhanced logging for troubleshooting
- Performance monitoring and optimization

## Outputs

The following outputs are available:

- `vpc_id`: ID of the VPC
- `public_subnet_ids`: IDs of the public subnets
- `private_subnet_ids`: IDs of the private subnets
- `security_group_id`: ID of the security group
- `kms_key_id`: ID of the KMS key
- `ecs_cluster_name`: Name of the ECS cluster
- `ecs_service_name`: Name of the ECS service
- `task_definition_arn`: ARN of the task definition
- `load_balancer_dns`: DNS name of the load balancer

## Maintenance

1. Regular Updates:
   - Weekly security patches
   - Monthly infrastructure updates
   - Quarterly major version updates

2. Backup Strategy:
   - Daily state file backups
   - Weekly full infrastructure backups
   - Monthly disaster recovery testing

3. Monitoring:
   - 24/7 monitoring of critical services
   - Automated alerting for issues
   - Regular performance reviews

## Support

For production environment issues:
1. Check the monitoring dashboard
2. Review CloudWatch logs
3. Contact the infrastructure team
4. Follow the incident response procedure 