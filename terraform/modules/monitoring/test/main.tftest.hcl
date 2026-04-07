run "test_dashboard_creation" {
  command = plan

  assert {
    condition     = aws_cloudwatch_dashboard.main.dashboard_name == "test-dashboard"
    error_message = "Dashboard name should be test-dashboard"
  }
}

run "test_alarm_creation" {
  command = plan

  assert {
    condition     = length(aws_cloudwatch_metric_alarm.cpu_utilization) == 1
    error_message = "Should create CPU utilization alarm"
  }

  assert {
    condition     = length(aws_cloudwatch_metric_alarm.memory_utilization) == 1
    error_message = "Should create memory utilization alarm"
  }
}

run "test_sns_topic_creation" {
  command = plan

  assert {
    condition     = length(aws_sns_topic.alerts) == 1
    error_message = "Should create SNS topic for alerts"
  }
}

run "test_alarm_thresholds" {
  command = plan

  assert {
    condition     = aws_cloudwatch_metric_alarm.cpu_utilization.threshold == "80"
    error_message = "CPU utilization threshold should be 80%"
  }

  assert {
    condition     = aws_cloudwatch_metric_alarm.memory_utilization.threshold == "80"
    error_message = "Memory utilization threshold should be 80%"
  }
} 