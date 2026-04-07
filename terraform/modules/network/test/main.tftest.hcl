run "test_vpc_creation" {
  command = plan

  assert {
    condition     = aws_vpc.main.cidr_block == "10.0.0.0/16"
    error_message = "VPC CIDR block should be 10.0.0.0/16"
  }
}

run "test_subnet_creation" {
  command = plan

  assert {
    condition     = length(aws_subnet.public) == 2
    error_message = "Should create 2 public subnets"
  }

  assert {
    condition     = length(aws_subnet.private) == 2
    error_message = "Should create 2 private subnets"
  }
}

run "test_nat_gateway_creation" {
  command = plan

  assert {
    condition     = length(aws_nat_gateway.main) == 2
    error_message = "Should create 2 NAT gateways"
  }
}

run "test_security_group_creation" {
  command = plan

  assert {
    condition     = length(aws_security_group.alb) == 1
    error_message = "Should create ALB security group"
  }
} 