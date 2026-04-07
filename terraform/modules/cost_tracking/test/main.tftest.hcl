run "test_budget_creation" {
  command = plan

  assert {
    condition     = length(aws_budgets_budget.monthly) == 1
    error_message = "Should create monthly budget"
  }

  assert {
    condition     = length(aws_budgets_budget.forecast) == 1
    error_message = "Should create forecast budget"
  }
}

run "test_cost_allocation_tags" {
  command = plan

  assert {
    condition     = length(aws_ce_cost_allocation_tag.environment) == 1
    error_message = "Should create environment cost allocation tag"
  }

  assert {
    condition     = length(aws_ce_cost_allocation_tag.project) == 1
    error_message = "Should create project cost allocation tag"
  }
}

run "test_anomaly_monitor" {
  command = plan

  assert {
    condition     = length(aws_ce_anomaly_monitor.cost) == 1
    error_message = "Should create cost anomaly monitor"
  }
}

run "test_budget_notifications" {
  command = plan

  assert {
    condition     = length(aws_budgets_budget.monthly.notification) == 1
    error_message = "Should create budget notification"
  }

  assert {
    condition     = aws_budgets_budget.monthly.notification[0].threshold == 80
    error_message = "Budget notification threshold should be 80%"
  }
} 