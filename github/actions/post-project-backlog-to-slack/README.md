# Post GitHub Project Backlog Snapshot to Slack (Incoming Webhook)

This composite GitHub Action posts a snapshot of **open issues** from a **GitHub Project v2** (Kanban) into a Slack channel using a **Slack Incoming Webhook**.

It groups issues by the Project **Status** field (e.g. Backlog, Ready, In Progress, In Review) and posts a Slack message with a link to the Project board.

> Note: Using an Incoming Webhook supports **link buttons** (e.g. “Open Project”) but does **not** support interactive buttons that change GitHub state. For that, you would need a Slack App with Interactivity + a backend handler.

---

## What this action does

- Fetches Project v2 items via GitHub GraphQL API
- Filters to **open issues**
- Reads the Project **Status** (single-select field named `Status`)
- Groups issues by status buckets you choose
- Posts formatted Slack Block Kit message via Incoming Webhook

---

## Requirements

### GitHub
- A **GitHub Project v2** with a single-select field named **Status**
- Issues added to that Project (from one or many repositories)

### Slack
- A Slack **Incoming Webhook URL** bound to the target channel

---

## Secrets (required)

Add these as **GitHub Actions Secrets** (repo or org):

| Secret name | Description |
|---|---|
| `SLACK_WEBHOOK_URL` | Slack Incoming Webhook URL for the channel |
| `GH_PROJECT_TOKEN` | GitHub token with read access to Projects v2 + issues (GraphQL) |

### How to create `SLACK_WEBHOOK_URL` (Slack Incoming Webhook)

1. Go to Slack Apps: https://api.slack.com/apps
2. **Create New App** → “From scratch”
3. Go to **Incoming Webhooks**
4. Turn **Activate Incoming Webhooks** ON
5. Click **Add New Webhook to Workspace**
6. Pick the channel (e.g. `#maintenance`) and Allow
7. Copy the generated webhook URL  
8. Store it in GitHub as secret `SLACK_WEBHOOK_URL`

> Treat webhook URLs as credentials. Do not commit them.

### How to create `GH_PROJECT_TOKEN` (Fine-grained PAT, read-only)

Recommended: Fine-grained PAT with **read-only** permissions.

1. Open: https://github.com/settings/personal-access-tokens
2. Fine-grained tokens → **Generate new token**
3. **Resource owner**: select the org that owns the Project (e.g. `orangit`)
4. **Repository access**:  
   - Prefer **All repositories** (simplest), or choose “Only selected” if you must
5. Permissions:
   - **Organization permissions**:
     - `Projects` → **Read**
   - **Repository permissions**:
     - `Issues` → **Read**
     - `Metadata` → **Read**
6. Generate token and store in GitHub as secret `GH_PROJECT_TOKEN`

> If you don’t see “Organization permissions → Projects”, org policies may restrict tokens or you may not be an org member. Ask an org admin or use a GitHub App approach.

---

## Variables (recommended defaults)

These are **non-secret defaults** used by the workflow.

Add as **GitHub Actions Variables** (repo or org):

| Variable name | Example | How to find it |
|---|---|---|
| `PROJECT_OWNER` | `orangit` | From the Project URL: `/orgs/<OWNER>/projects/...` |
| `PROJECT_NUMBER` | `12` | From the Project URL: `/projects/<NUMBER>` |
| `PROJECT_URL` | `https://github.com/orgs/orangit/projects/12` | Copy from browser |

### Where to set variables
Repository:
- Repo → Settings → Secrets and variables → Actions → **Variables**

Organization:
- Org → Settings → Secrets and variables → Actions → **Variables**

> Recommended: repository variables unless you reuse the same defaults across many repos.

---

## Inputs

This action is called by a workflow and accepts the following inputs:

| Input | Required | Description |
|---|---:|---|
| `github_token` | ✅ | Token with Project v2 read access |
| `slack_webhook_url` | ✅ | Slack Incoming Webhook URL |
| `owner` | ✅ | Project owner org/user login |
| `project_number` | ✅ | Project v2 number |
| `project_url` | ✅ | Project URL (used in Slack link button) |
| `title` | ❌ | Slack message title (default: `Backlog snapshot`) |
| `max_items` | ❌ | Max issues per status bucket (default: `10`) |
| `statuses` | ❌ | Comma-separated status buckets (default: `Backlog,Ready,In Progress,In Review`) |

---

## Example workflow (manual + scheduled + reusable, uses vars defaults)

Create this file:

`.github/workflows/post-backlog-to-slack.yml`

```yaml
name: Post backlog snapshot to Slack

on:
  workflow_dispatch:
    inputs:
      owner:
        description: "Override Project owner (optional)"
        required: false
        type: string
      project_number:
        description: "Override Project number (optional)"
        required: false
        type: number
      project_url:
        description: "Override Project URL (optional)"
        required: false
        type: string
      title:
        description: "Slack message title"
        required: false
        type: string
        default: "Backlog snapshot"
      max_items:
        description: "Max items per status bucket"
        required: false
        type: number
        default: 10
      statuses:
        description: "Comma-separated Status values"
        required: false
        type: string
        default: "Backlog,Ready,In Progress,In Review"

  schedule:
    - cron: "0 7 * * 1-5" # weekdays 07:00 UTC

  workflow_call:
    inputs:
      owner:
        required: false
        type: string
      project_number:
        required: false
        type: number
      project_url:
        required: false
        type: string
      title:
        required: false
        type: string
        default: "Backlog snapshot"
      max_items:
        required: false
        type: number
        default: 10
      statuses:
        required: false
        type: string
        default: "Backlog,Ready,In Progress,In Review"
    secrets:
      SLACK_WEBHOOK_URL:
        required: true
      GH_PROJECT_TOKEN:
        required: true

jobs:
  post:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4

      - name: Validate defaults
        run: |
          if [ -z "${{ vars.PROJECT_OWNER }}" ] || \
             [ -z "${{ vars.PROJECT_NUMBER }}" ] || \
             [ -z "${{ vars.PROJECT_URL }}" ]; then
            echo "❌ Missing PROJECT_* defaults. Set them in repo or org variables."
            exit 1
          fi

      - name: Post backlog snapshot to Slack
        uses: ./.github/actions/post-project-backlog-to-slack
        with:
          github_token: ${{ secrets.GH_PROJECT_TOKEN }}
          slack_webhook_url: ${{ secrets.SLACK_WEBHOOK_URL }}

          owner: ${{ github.event.inputs.owner || inputs.owner || vars.PROJECT_OWNER }}
          project_number: ${{ github.event.inputs.project_number || inputs.project_number || vars.PROJECT_NUMBER }}
          project_url: ${{ github.event.inputs.project_url || inputs.project_url || vars.PROJECT_URL }}

          title: ${{ github.event.inputs.title || inputs.title || 'Backlog snapshot' }}
          max_items: ${{ github.event.inputs.max_items || inputs.max_items || 10 }}
          statuses: ${{ github.event.inputs.statuses || inputs.statuses || 'Backlog,Ready,In Progress,In Review' }}
