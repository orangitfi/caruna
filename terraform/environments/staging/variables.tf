variable "aws_region" {
  description = "AWS region"
  type        = string
  default     = "eu-north-1"
}

variable "project_name" {
  description = "Name of the project"
  type        = string
  default     = "terraform-template"
}

variable "vpc_cidr" {
  description = "CIDR block for the VPC"
  type        = string
  default     = "10.1.0.0/16"  # Different CIDR range for staging
}

variable "public_subnets" {
  description = "List of public subnet CIDR blocks"
  type        = list(string)
  default     = ["10.1.1.0/24", "10.1.2.0/24"]
}

variable "private_subnets" {
  description = "List of private subnet CIDR blocks"
  type        = list(string)
  default     = ["10.1.3.0/24", "10.1.4.0/24"]
}

variable "availability_zones" {
  description = "List of availability zones"
  type        = list(string)
  default     = ["eu-north-1a", "eu-north-1b"]
}

variable "container_port" {
  description = "Port exposed by the container"
  type        = number
  default     = 80
}

variable "container_image" {
  description = "Container image to use"
  type        = string
  default     = "your-registry/your-app:staging"
}

variable "task_cpu" {
  description = "CPU units for the ECS task"
  type        = number
  default     = 512
}

variable "task_memory" {
  description = "Memory for the ECS task in MB"
  type        = number
  default     = 1024
}

variable "service_desired_count" {
  description = "Desired number of tasks for the ECS service"
  type        = number
  default     = 2
}

variable "container_environment" {
  description = "Environment variables for the container"
  type        = list(map(string))
  default     = [
    {
      name  = "ENVIRONMENT"
      value = "staging"
    },
    {
      name  = "LOG_LEVEL"
      value = "info"
    }
  ]
}

variable "container_secrets" {
  description = "Secrets for the container"
  type        = list(map(string))
  default     = []
}

variable "environment" {
  description = "Environment name (e.g., dev, staging, prod)"
  type        = string
  default     = "staging"
} 