package test

import (
	"testing"
	"github.com/gruntwork-io/terratest/modules/terraform"
	"github.com/stretchr/testify/assert"
)

func TestCostTrackingModule(t *testing.T) {
	t.Parallel()

	terraformOptions := terraform.WithDefaultRetryableErrors(t, &terraform.Options{
		TerraformDir: "../environments/staging",
		Vars: map[string]interface{}{
			"environment": "test",
		},
	})

	defer terraform.Destroy(t, terraformOptions)

	terraform.InitAndApply(t, terraformOptions)

	// Test Budget
	budgetName := terraform.Output(t, terraformOptions, "budget_name")
	assert.NotEmpty(t, budgetName)

	// Test Budget Notifications
	budgetNotificationTopicArn := terraform.Output(t, terraformOptions, "budget_notification_topic_arn")
	assert.NotEmpty(t, budgetNotificationTopicArn)

	// Test Cost Allocation Tags
	costAllocationTags := terraform.OutputList(t, terraformOptions, "cost_allocation_tags")
	assert.NotEmpty(t, costAllocationTags)
	assert.Contains(t, costAllocationTags, "Environment")
	assert.Contains(t, costAllocationTags, "Project")
	assert.Contains(t, costAllocationTags, "Service")

	// Test Cost and Usage Report
	reportBucketName := terraform.Output(t, terraformOptions, "report_bucket_name")
	assert.NotEmpty(t, reportBucketName)

	reportName := terraform.Output(t, terraformOptions, "report_name")
	assert.NotEmpty(t, reportName)
} 