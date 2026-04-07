# Cost Tracking Module

This module implements AWS cost tracking and budget management for the infrastructure.

## Features

- Monthly budget tracking
- Cost anomaly detection
- Resource tagging for cost allocation
- Cost optimization recommendations
- Budget alerts and notifications
- Cost allocation reports

## Usage

```hcl
module "cost_tracking" {
  source = "../../modules/cost_tracking"

  environment          = "staging"
  monthly_budget_limit = 1000  # $1000 monthly budget
  alert_emails         = ["team@example.com"]

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
| monthly_budget_limit | Monthly budget limit in USD | number | - | yes |
| alert_emails | List of email addresses for budget alerts | list(string) | - | yes |
| tags | A map of tags to add to all resources | map(string) | {} | no |

## Outputs

| Name | Description |
|------|-------------|
| budget_id | ID of the AWS Budget |
| cost_anomaly_monitor_arn | ARN of the Cost Anomaly Monitor |

## Cost Management Features

### Budget Tracking
- Monthly budget limits
- Forecasted cost alerts
- Actual vs. budgeted cost tracking
- Cost trend analysis

### Cost Anomaly Detection
- Real-time cost anomaly detection
- Anomaly threshold configuration
- Alert notifications
- Root cause analysis

### Cost Allocation
- Resource tagging strategy
- Cost allocation reports
- Resource optimization insights
- Usage-based cost tracking

## Maintenance

- Regular budget reviews
- Cost optimization analysis
- Resource utilization monitoring
- Tag compliance checks
- Cost allocation reporting

## Requirements

| Name | Version |
|------|---------|
| terraform | >= 1.0.0 |
| aws | ~> 5.0 |

## License

This module is licensed under the MIT License. 