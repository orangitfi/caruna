provider "aws" {
  region = var.aws_region
}

module "network" {
  source = "../../modules/network"

  environment = "dev"
  vpc_cidr    = var.vpc_cidr

  public_subnets  = var.public_subnets
  private_subnets = var.private_subnets

  availability_zones = var.availability_zones

  tags = {
    Environment = "dev"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
} 