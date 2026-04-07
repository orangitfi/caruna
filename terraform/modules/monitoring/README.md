# Monitoring Module

This module sets up comprehensive monitoring and alerting for the ECS infrastructure using CloudWatch.

## Features

- CloudWatch Container Insights for ECS
- Custom metrics and dashboards
- Alarm configurations for critical metrics
- Log aggregation and analysis
- Performance monitoring
- Cost optimization insights

## Usage

```hcl
module "monitoring" {
  source = "../../modules/monitoring"

  environment    = "staging"
  aws_region     = "eu-north-1"
  cluster_name   = module.compute.cluster_name
  alb_arn_suffix = module.network.alb_arn_suffix

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
| cluster_name | Name of the ECS cluster | string | - | yes |
| alb_arn_suffix | ARN suffix of the ALB | string | - | yes |
| tags | A map of tags to add to all resources | map(string) | {} | no |

## Outputs

| Name | Description |
|------|-------------|
| dashboard_url | URL of the CloudWatch dashboard |
| alarm_arns | ARNs of the CloudWatch alarms |

## Monitoring Features

### Container Insights
- CPU and memory utilization
- Network performance metrics
- Task and service metrics
- Container-level insights

### Alarms
- High CPU utilization
- High memory utilization
- Error rate thresholds
- Latency thresholds
- Service health checks

### Dashboards
- ECS cluster overview
- Service performance
- Container metrics
- ALB metrics
- Cost metrics

## Maintenance

- Regular review of alarm thresholds
- Dashboard updates
- Metric optimization
- Cost analysis
- Performance tuning

## Requirements

| Name | Version |
|------|---------|
| terraform | >= 1.0.0 |
| aws | ~> 5.0 |

## License

This module is licensed under the MIT License. 