locals {
  # Base CIDR block for the VPC
  vpc_cidr = "10.0.0.0/16"
  
  # Calculate subnet CIDRs
  public_subnet_cidrs = [
    cidrsubnet(local.vpc_cidr, 8, 1),  # 10.0.1.0/24
    cidrsubnet(local.vpc_cidr, 8, 2)   # 10.0.2.0/24
  ]
  
  private_subnet_cidrs = [
    cidrsubnet(local.vpc_cidr, 8, 3),  # 10.0.3.0/24
    cidrsubnet(local.vpc_cidr, 8, 4)   # 10.0.4.0/24
  ]
}

resource "aws_vpc" "main" {
  cidr_block           = local.vpc_cidr
  enable_dns_hostnames = true
  enable_dns_support   = true

  tags = merge(
    var.tags,
    {
      Name = "${var.environment}-vpc"
    }
  )
}

resource "aws_subnet" "public" {
  count             = length(var.availability_zones)
  vpc_id            = aws_vpc.main.id
  cidr_block        = local.public_subnet_cidrs[count.index]
  availability_zone = var.availability_zones[count.index]

  tags = merge(
    var.tags,
    {
      Name = "${var.environment}-public-subnet-${count.index + 1}"
    }
  )
}

resource "aws_subnet" "private" {
  count             = length(var.availability_zones)
  vpc_id            = aws_vpc.main.id
  cidr_block        = local.private_subnet_cidrs[count.index]
  availability_zone = var.availability_zones[count.index]

  tags = merge(
    var.tags,
    {
      Name = "${var.environment}-private-subnet-${count.index + 1}"
    }
  )
} 