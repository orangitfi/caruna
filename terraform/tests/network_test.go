package test

import (
	"testing"
	"github.com/gruntwork-io/terratest/modules/terraform"
	"github.com/stretchr/testify/assert"
)

func TestNetworkModule(t *testing.T) {
	terraformOptions := terraform.WithDefaultRetryableErrors(t, &terraform.Options{
		TerraformDir: "../environments/staging",
		Vars: map[string]interface{}{
			"environment": "test",
			"vpc_cidr":    "10.0.0.0/16",
		},
	})

	defer terraform.Destroy(t, terraformOptions)
	terraform.InitAndApply(t, terraformOptions)

	// Test VPC creation
	vpcId := terraform.Output(t, terraformOptions, "vpc_id")
	assert.NotEmpty(t, vpcId)

	// Test subnet creation
	publicSubnetIds := terraform.OutputList(t, terraformOptions, "public_subnet_ids")
	assert.NotEmpty(t, publicSubnetIds)
	assert.Len(t, publicSubnetIds, 2)

	privateSubnetIds := terraform.OutputList(t, terraformOptions, "private_subnet_ids")
	assert.NotEmpty(t, privateSubnetIds)
	assert.Len(t, privateSubnetIds, 2)
} 