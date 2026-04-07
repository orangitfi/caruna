provider "aws" {
  region = var.aws_region
}

module "network" {
  source = "../../modules/network"

  environment = "staging"
  vpc_cidr    = var.vpc_cidr

  public_subnets  = var.public_subnets
  private_subnets = var.private_subnets

  availability_zones = var.availability_zones

  tags = {
    Environment = "staging"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

module "security" {
  source = "../../modules/security"

  environment = "staging"
  vpc_id      = module.network.vpc_id
  container_port = var.container_port

  tags = {
    Environment = "staging"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

module "compute" {
  source = "../../modules/compute"

  environment = "staging"
  aws_region  = var.aws_region
  vpc_id      = module.network.vpc_id

  public_subnet_ids    = module.network.public_subnet_ids
  private_subnet_ids   = module.network.private_subnet_ids
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
    Environment = "staging"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

module "monitoring" {
  source = "../../modules/monitoring"

  environment    = "staging"
  aws_region     = var.aws_region
  cluster_name   = module.compute.cluster_name
  alb_arn_suffix = module.network.alb_arn_suffix

  tags = {
    Environment = "staging"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

module "cost_tracking" {
  source = "../../modules/cost_tracking"

  environment          = "staging"
  monthly_budget_limit = 1000  # $1000 monthly budget for staging
  alert_emails         = ["team@example.com"]

  tags = {
    Environment = "staging"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

module "secrets" {
  source = "../../modules/secrets"

  environment         = "staging"
  ecs_task_role_name = module.compute.ecs_task_role_name
  sns_topic_arn      = module.monitoring.sns_topic_arn

  tags = {
    Environment = "staging"
    Project     = var.project_name
    ManagedBy   = "terraform"
  }
}

terraform {
  backend "s3" {
    bucket         = "terraform-state-${var.environment}"
    key            = "terraform.tfstate"
    region         = var.aws_region
    dynamodb_table = "terraform-state-lock"
    encrypt        = true
  }
} 