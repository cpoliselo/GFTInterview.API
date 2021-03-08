 # Configure the AWS Provider
 
terraform {
  required_providers {
    kafka = {
      source = "Mongey/kafka"
    }
  }
}

provider "aws" {
  region  = "us-east-1"
  shared_credentials_file = ".aws/credentials"
  profile = "awsterraform"
}

resource "aws_elastic_beanstalk_application" "application" {
  name        = "AppTesteItau2"
}

resource "aws_elastic_beanstalk_environment" "environment" {
  name                = "AmbienteTesteItau2"
  application         = aws_elastic_beanstalk_application.application.name
  solution_stack_name = "64bit Windows Server 2019 v2.6.3 running IIS 10.0"
  setting {
        namespace = "aws:autoscaling:launchconfiguration"
        name      = "IamInstanceProfile"
        value     = "aws-elasticbeanstalk-ec2-role"
      }
}

resource "aws_s3_bucket" "bucketitau" {
  bucket = "testeitau"
  acl = "public-read"
  }
  
provider "kafka" {
  bootstrap_servers = ["localhost:9092"]
  ca_cert           = file("../secrets/ca.crt")
  client_cert       = file("../secrets/terraform-cert.pem")
  client_key        = file("../secrets/terraform.pem")
  tls_enabled       = true
}