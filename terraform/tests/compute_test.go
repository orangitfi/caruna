package test

import (
	"testing"
	"github.com/gruntwork-io/terratest/modules/terraform"
	"github.com/stretchr/testify/assert"
)

func TestComputeModule(t *testing.T) {
	t.Parallel()

	terraformOptions := terraform.WithDefaultRetryableErrors(t, &terraform.Options{
		TerraformDir: "../environments/staging",
		Vars: map[string]interface{}{
			"environment": "test",
		},
	})

	defer terraform.Destroy(t, terraformOptions)

	terraform.InitAndApply(t, terraformOptions)

	// Test ECS Cluster
	clusterName := terraform.Output(t, terraformOptions, "ecs_cluster_name")
	assert.NotEmpty(t, clusterName)

	// Test ECS Service
	serviceName := terraform.Output(t, terraformOptions, "ecs_service_name")
	assert.NotEmpty(t, serviceName)

	// Test Task Definition
	taskDefinitionArn := terraform.Output(t, terraformOptions, "task_definition_arn")
	assert.NotEmpty(t, taskDefinitionArn)

	// Test Load Balancer
	albDns := terraform.Output(t, terraformOptions, "alb_dns_name")
	assert.NotEmpty(t, albDns)

	targetGroupArn := terraform.Output(t, terraformOptions, "target_group_arn")
	assert.NotEmpty(t, targetGroupArn)

	// Test Security Group
	ecsTaskSecurityGroupId := terraform.Output(t, terraformOptions, "ecs_task_security_group_id")
	assert.NotEmpty(t, ecsTaskSecurityGroupId)

	// Test CloudWatch Log Group
	logGroupName := terraform.Output(t, terraformOptions, "cloudwatch_log_group_name")
	assert.NotEmpty(t, logGroupName)
} 