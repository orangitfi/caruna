variable "environment" {
  description = "Environment name (e.g., dev, staging, prod)"
  type        = string
}

variable "ecs_task_role_name" {
  description = "Name of the ECS task role to attach secrets access policy"
  type        = string
}

variable "sns_topic_arn" {
  description = "ARN of the SNS topic for secret rotation alerts"
  type        = string
}

variable "tags" {
  description = "A map of tags to add to all resources"
  type        = map(string)
  default     = {}
} 