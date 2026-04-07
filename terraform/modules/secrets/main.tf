# KMS key for Secrets Manager encryption
resource "aws_kms_key" "secrets" {
  description             = "KMS key for Secrets Manager encryption"
  deletion_window_in_days = 7
  enable_key_rotation     = true

  tags = merge(
    var.tags,
    {
      Name = "${var.environment}-secrets-key"
    }
  )
}

# KMS alias for the key
resource "aws_kms_alias" "secrets" {
  name          = "alias/${var.environment}-secrets"
  target_key_id = aws_kms_key.secrets.key_id
}

# IAM policy for ECS tasks to access secrets
resource "aws_iam_policy" "secrets_access" {
  name        = "${var.environment}-secrets-access"
  description = "Policy for ECS tasks to access secrets"

  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Action = [
          "secretsmanager:GetSecretValue",
          "secretsmanager:DescribeSecret"
        ]
        Resource = [
          aws_secretsmanager_secret.app.arn,
          aws_secretsmanager_secret.db.arn
        ]
      },
      {
        Effect = "Allow"
        Action = [
          "kms:Decrypt"
        ]
        Resource = [
          aws_kms_key.secrets.arn
        ]
      }
    ]
  })

  tags = var.tags
}

# Attach the secrets access policy to the ECS task role
resource "aws_iam_role_policy_attachment" "secrets_access" {
  role       = var.ecs_task_role_name
  policy_arn = aws_iam_policy.secrets_access.arn
}

# Application secrets
resource "aws_secretsmanager_secret" "app" {
  name        = "${var.environment}/app-secrets"
  description = "Application secrets for ${var.environment} environment"
  kms_key_id  = aws_kms_key.secrets.key_id

  tags = merge(
    var.tags,
    {
      Name = "${var.environment}-app-secrets"
    }
  )
}

# Database secrets
resource "aws_secretsmanager_secret" "db" {
  name        = "${var.environment}/db-secrets"
  description = "Database secrets for ${var.environment} environment"
  kms_key_id  = aws_kms_key.secrets.key_id

  tags = merge(
    var.tags,
    {
      Name = "${var.environment}-db-secrets"
    }
  )
}

# CloudWatch alarm for secret rotation
resource "aws_cloudwatch_metric_alarm" "secret_rotation" {
  alarm_name          = "${var.environment}-secret-rotation-alarm"
  comparison_operator = "LessThanThreshold"
  evaluation_periods  = "1"
  metric_name         = "SecretRotationDays"
  namespace           = "AWS/SecretsManager"
  period             = "86400"  # 24 hours
  statistic          = "Minimum"
  threshold          = "30"     # Alert if rotation is more than 30 days old
  alarm_description  = "This metric monitors secret rotation"
  alarm_actions      = [var.sns_topic_arn]

  dimensions = {
    SecretId = aws_secretsmanager_secret.app.id
  }

  tags = var.tags
} 