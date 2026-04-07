provider "aws" {
  region = var.aws_region
}

module "network" {
  source = "../../modules/network"

  environment = "prod"
  vpc_cidr    = var.vpc_cidr

  public_subnets  = var.public_subnets
  private_subnets = var.private_subnets

  availability_zones = var.availability_zones

  tags = {
    Environment = "prod"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

module "security" {
  source = "../../modules/security"

  environment = "prod"
  vpc_id      = module.network.vpc_id
  container_port = var.container_port

  tags = {
    Environment = "prod"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

module "compute" {
  source = "../../modules/compute"

  environment = "prod"
  aws_region  = var.aws_region
  vpc_id      = module.network.vpc_id

  private_subnet_ids = module.network.private_subnet_ids
  alb_security_group_id = module.security.alb_security_group_id
  target_group_arn     = module.network.target_group_arn

  container_image = var.container_image
  container_port  = var.container_port

  task_cpu    = var.task_cpu
  task_memory = var.task_memory

  service_desired_count = var.service_desired_count

  container_environment = var.container_environment
  container_secrets     = var.container_secrets

  tags = {
    Environment = "prod"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

module "monitoring" {
  source = "../../modules/monitoring"

  environment    = "prod"
  aws_region     = var.aws_region
  cluster_name   = module.compute.cluster_name
  alb_arn_suffix = module.network.alb_arn_suffix

  tags = {
    Environment = "prod"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

module "cost_tracking" {
  source = "../../modules/cost_tracking"

  environment          = "prod"
  monthly_budget_limit = 5000  # $5000 monthly budget for production
  alert_emails         = ["team@example.com", "ops@example.com"]

  tags = {
    Environment = "prod"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
} 