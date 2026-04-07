terraform {
  required_version = ">= 1.0.0"

  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = ">= 4.0.0"
    }
  }

  backend "s3" {
    # These values should be provided during terraform init
    # bucket         = "your-terraform-state-bucket"
    # key            = "dev/terraform.tfstate"
    # region         = "us-west-2"
    # dynamodb_table = "terraform-state-lock"
    # encrypt        = true
  }
} 