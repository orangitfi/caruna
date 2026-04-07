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
  default     = "10.2.0.0/16"  # Different CIDR range for production
}

variable "public_subnets" {
  description = "List of public subnet CIDR blocks"
  type        = list(string)
  default     = ["10.2.1.0/24", "10.2.2.0/24", "10.2.3.0/24"]  # More subnets for production
}

variable "private_subnets" {
  description = "List of private subnet CIDR blocks"
  type        = list(string)
  default     = ["10.2.4.0/24", "10.2.5.0/24", "10.2.6.0/24"]  # More subnets for production
}

variable "availability_zones" {
  description = "List of availability zones"
  type        = list(string)
  default     = ["eu-north-1a", "eu-north-1b", "eu-north-1c"]
}

variable "container_port" {
  description = "Port exposed by the container"
  type        = number
  default     = 80
}

variable "container_image" {
  description = "Container image to use"
  type        = string
  default     = "your-registry/your-app:latest"
}

variable "task_cpu" {
  description = "CPU units for the ECS task"
  type        = number
  default     = 1024
}

variable "task_memory" {
  description = "Memory for the ECS task in MB"
  type        = number
  default     = 2048
}

variable "service_desired_count" {
  description = "Desired number of tasks for the ECS service"
  type        = number
  default     = 3
}

variable "container_environment" {
  description = "Environment variables for the container"
  type        = list(map(string))
  default     = [
    {
      name  = "ENVIRONMENT"
      value = "prod"
    },
    {
      name  = "LOG_LEVEL"
      value = "warn"
    }
  ]
}

variable "container_secrets" {
  description = "Secrets for the container"
  type        = list(map(string))
  default     = []
} 