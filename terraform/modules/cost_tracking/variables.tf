variable "environment" {
  description = "Environment name (e.g., dev, staging, prod)"
  type        = string
}

variable "monthly_budget_limit" {
  description = "Monthly budget limit in USD"
  type        = number
}

variable "alert_emails" {
  description = "List of email addresses to receive budget alerts"
  type        = list(string)
}

variable "tags" {
  description = "A map of tags to add to all resources"
  type        = map(string)
  default     = {}
} 