# Notify Slack Composite Action

This GitHub Actions composite action sends a Slack message when triggered. It posts the provided message to a Slack Incoming Webhook URL supplied as an input.

## Features

- Sends a Slack notification via Incoming Webhook
- Uses the provided message content
- Accepts a webhook token as input
- Simple drop-in step for workflows

## Usage

```yaml
- uses: ./.github/actions/notify-slack
  with:
    message: "Build completed successfully."
    webhook: ${{ secrets.SLACK_WEBHOOK }}
```

## Inputs

- `message` (required): Message to send.
- `webhook` (required): Slack Incoming Webhook token (the portion after `https://hooks.slack.com/services/`).

## Behavior

The action runs a single `curl` request that posts the following payload:

```
{"text": "<message>"}
```

`<message>` is populated from the `message` input.

## Requirements

- A valid Slack Incoming Webhook token stored in a secret (recommended)

## Notes

- Store the webhook token in a repository or organization secret.
