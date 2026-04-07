# Infrastructure Tests

This directory contains integration tests for our Terraform infrastructure using Terratest. The tests verify that our infrastructure components are created correctly and function as expected.

## Prerequisites

- Go 1.16 or later
- AWS CLI configured with appropriate credentials
- Terraform 1.0 or later

## Test Structure

- `network_test.go`: Tests VPC, subnets, and security groups
- `compute_test.go`: Tests ECS cluster, service, and load balancer
- `monitoring_test.go`: Tests CloudWatch alarms and dashboards
- `cost_tracking_test.go`: Tests budget alerts and cost allocation tags

## Running Tests

1. Install dependencies:
```bash
go mod init terraform_template
go get github.com/gruntwork-io/terratest
go get github.com/stretchr/testify/assert
```

2. Run all tests:
```bash
go test -v ./...
```

3. Run specific test:
```bash
go test -v -run TestNetworkModule
```

## Test Environment

Tests are run against the staging environment with the following modifications:
- Environment name is set to "test"
- Resources are automatically destroyed after tests complete
- Tests run in parallel for faster execution

## Adding New Tests

1. Create a new test file with the naming convention `*_test.go`
2. Import required packages:
```go
import (
    "testing"
    "github.com/gruntwork-io/terratest/modules/terraform"
    "github.com/stretchr/testify/assert"
)
```

3. Create a test function with the naming convention `Test*Module`
4. Use `terraform.WithDefaultRetryableErrors` for Terraform operations
5. Add assertions to verify resource creation and configuration

## Best Practices

- Always use `t.Parallel()` for concurrent test execution
- Clean up resources using `defer terraform.Destroy()`
- Test both resource creation and configuration
- Use meaningful assertion messages
- Keep tests focused and independent 