output "alb_security_group_id" {
  description = "The ID of the ALB security group"
  value       = aws_security_group.alb.id
}

output "rds_security_group_id" {
  description = "The ID of the RDS security group"
  value       = aws_security_group.rds.id
}

output "ecs_tasks_security_group_id" {
  description = "The ID of the ECS tasks security group"
  value       = aws_security_group.ecs_tasks.id
}

output "kms_key_id" {
  description = "The ID of the KMS key for secrets"
  value       = aws_kms_key.secrets.key_id
}

output "kms_key_arn" {
  description = "The ARN of the KMS key for secrets"
  value       = aws_kms_key.secrets.arn
} 