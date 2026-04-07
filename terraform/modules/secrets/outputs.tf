output "kms_key_id" {
  description = "ID of the KMS key used for secrets encryption"
  value       = aws_kms_key.secrets.key_id
}

output "kms_key_arn" {
  description = "ARN of the KMS key used for secrets encryption"
  value       = aws_kms_key.secrets.arn
}

output "app_secret_arn" {
  description = "ARN of the application secrets"
  value       = aws_secretsmanager_secret.app.arn
}

output "db_secret_arn" {
  description = "ARN of the database secrets"
  value       = aws_secretsmanager_secret.db.arn
}

output "secrets_access_policy_arn" {
  description = "ARN of the IAM policy for secrets access"
  value       = aws_iam_policy.secrets_access.arn
} 