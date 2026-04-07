package test

import (
	"testing"
	"github.com/gruntwork-io/terratest/modules/terraform"
	"github.com/stretchr/testify/assert"
)

func TestMonitoringModule(t *testing.T) {
	t.Parallel()

	terraformOptions := terraform.WithDefaultRetryableErrors(t, &terraform.Options{
		TerraformDir: "../environments/staging",
		Vars: map[string]interface{}{
			"environment": "test",
		},
	})

	defer terraform.Destroy(t, terraformOptions)

	terraform.InitAndApply(t, terraformOptions)

	// Test CloudWatch Dashboard
	dashboardName := terraform.Output(t, terraformOptions, "cloudwatch_dashboard_name")
	assert.NotEmpty(t, dashboardName)

	// Test CPU Utilization Alarm
	cpuAlarmName := terraform.Output(t, terraformOptions, "cpu_utilization_alarm_name")
	assert.NotEmpty(t, cpuAlarmName)

	// Test Memory Utilization Alarm
	memoryAlarmName := terraform.Output(t, terraformOptions, "memory_utilization_alarm_name")
	assert.NotEmpty(t, memoryAlarmName)

	// Test Request Count Alarm
	requestCountAlarmName := terraform.Output(t, terraformOptions, "request_count_alarm_name")
	assert.NotEmpty(t, requestCountAlarmName)

	// Test Error Rate Alarm
	errorRateAlarmName := terraform.Output(t, terraformOptions, "error_rate_alarm_name")
	assert.NotEmpty(t, errorRateAlarmName)

	// Test Target Response Time Alarm
	responseTimeAlarmName := terraform.Output(t, terraformOptions, "target_response_time_alarm_name")
	assert.NotEmpty(t, responseTimeAlarmName)
} 