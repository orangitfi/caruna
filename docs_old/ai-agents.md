# AI Agents Guide

This document describes how to use AI agents with GitHub Copilot in VS Code for code analysis, review, security auditing, and documentation tasks.

## Overview

AI agents are specialized prompts that give GitHub Copilot a specific persona, focus area, and set of guidelines. They are stored in `.github/agents/` and automatically recognized by GitHub Copilot Chat. They help ensure consistent, high-quality output for specific tasks by defining:

- **Role** — What the agent specializes in
- **Scope** — What files/areas the agent can work with
- **Guidelines** — How the agent should approach tasks
- **Boundaries** — What the agent should and shouldn't do

## Available Agents

| Agent | File | Purpose |
|-------|------|---------|
| **Analyst** | `.github/agents/analyst.md` | Codebase analysis, baseline documentation, ADRs |
| **Reviewer** | `.github/agents/review-agent.md` | Code review, best practices, quality checks |
| **Security** | `.github/agents/security-agent.md` | Security audit, vulnerability scanning |
| **Docs** | `.github/agents/docs-agent.md` | Documentation writing and maintenance |

## How to Use Agents in VS Code

### Prerequisites

1. Install [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) extension
2. Install [GitHub Copilot Chat](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat) extension
3. Sign in with a GitHub account that has Copilot access

### Invoking an Agent

In GitHub Copilot Chat, reference an agent using the `@` symbol:

```
@analyst_agent analyze the codebase and create baseline documentation
```

Or reference the file directly:

```
@.github/agents/analyst.md analyze the codebase
```

Make sure that the prompt is in Agent more. Also select Opus 4.5 to be model.

### Combining with File References

You can attach files for context:

```
@review_agent review @src/services/auth.ts for security issues
```

### Example Prompts

**Analyst Agent:**

```
@analyst_agent analyze the codebase and create baseline documentation
@analyst_agent generate ADRs for the key architectural decisions
@analyst_agent create a technical design document
```

**Review Agent:**

```
@review_agent do a baseline review for the repository
@review_agent review this PR for code quality issues
@review_agent analyze the whole codebase and write findings to docs/review.md
```

**Security Agent:**

```
@security_agent do security analysis on the codebase
@security_agent scan for hardcoded credentials and secrets
@security_agent write findings to docs/security.md
```

**Docs Agent:**

```
@docs_agent update the README with new setup instructions
@docs_agent create CONTRIBUTING.md with contribution guidelines
@docs_agent add missing GitHub repository files
```

---

## Project Takeover Workflow

When taking over an existing project, run the agents in this order to build a comprehensive understanding:

### Step 1: Analyst Agent (Baseline Documentation)

**Goal:** Understand what the project does and how it's built.

```
@analyst_agent do baseline analysis for the project. We are taking over this 
project and need documentation about architecture, setup, and key decisions.
```

**Outputs:**

- `README_NEW.md` — Proposed README improvements
- `docs/design.md` — Technical architecture document
- `docs/adr/*.md` — Architectural Decision Records

### Step 2: Review Agent (Code Quality Assessment)

**Goal:** Identify code quality issues, technical debt, and areas needing attention.

```
@review_agent do baseline review for the repository. Write findings and 
prioritized plan to docs/review.md
```

**Outputs:**

- `docs/review.md` — Code review findings with severity levels

**What it looks for:**

- Type safety violations
- Missing error handling
- Code smells and anti-patterns
- Test coverage gaps
- Performance concerns
- TODOs and incomplete code

### Step 3: Security Agent (Security Audit)

**Goal:** Identify security vulnerabilities and risks.

```
@security_agent do security analysis on the codebase. Write findings and 
prioritized plan to docs/security.md
```

**Outputs:**

- `docs/security.md` — Security audit report with remediation plan

**What it looks for:**

- Hardcoded credentials
- Injection vulnerabilities (SQL, XSS, CSRF)
- Authentication/authorization issues
- Insecure configurations
- Vulnerable dependencies
- Missing security headers

### Step 4: Docs Agent (Repository Standards)

**Goal:** Add missing standard repository files.

```
@docs_agent write the missing typical GitHub repository files: 
SECURITY.md, CONTRIBUTING.md, .editorconfig, issue templates, PR template
```

**Outputs:**

- `SECURITY.md` — Security policy
- `CONTRIBUTING.md` — Contribution guidelines
- `.editorconfig` — Editor configuration
- `.github/CODEOWNERS` — Code ownership
- `.github/PULL_REQUEST_TEMPLATE.md` — PR template
- `.github/ISSUE_TEMPLATE/*.md` — Issue templates

### Summary Checklist

```markdown
## Takeover Checklist

- [ ] Run analyst agent → `docs/design.md`, `docs/adr/*`, `README_NEW.md`
- [ ] Run review agent → `docs/review.md`
- [ ] Run security agent → `docs/security.md`
- [ ] Run docs agent → GitHub standard files
- [ ] Review generated documentation
- [ ] Merge README_NEW.md into README.md
- [ ] Address critical findings from review and security reports
- [ ] Update CODEOWNERS with actual team members
```

---

## Adding Agents to a Repository

Copy agents from .github/agents. Paste them into eqaual location in your project.

### Directory Structure

```
.github/
└── agents/
    ├── analyst.md
    ├── docs-agent.md
    ├── review-agent.md
    └── security-agent.md
```

### Agent File Format

Each agent is a Markdown file with YAML frontmatter:

```markdown
---
name: agent_name
description: Short description of the agent
tools: ["githubRepo", "search"]
---

You are [role description].

## Your role and scope

- **Role:** What this agent does
- **Scope:** What files/areas it works with

## Guidelines

- Specific instructions for behavior
- Quality standards to follow
- Output formats expected

## Boundaries

- ✅ **Always do:** Things the agent should always do
- ⚠️ **Ask first:** Things requiring confirmation
- 🚫 **Never do:** Things the agent must not do
```

### Frontmatter Fields

| Field | Description |
|-------|-------------|
| `name` | Identifier used with `@` mentions |
| `description` | Brief description shown in UI |
| `tools` | Available tools: `githubRepo`, `search`, `usages` |

---

## Customizing Agents

### Modifying Existing Agents

1. Open the agent file in `.github/agents/`
2. Edit the guidelines, scope, or boundaries
3. Save — changes take effect immediately

### Common Customizations

**Add project-specific context:**

```markdown
## Project knowledge

- **Tech Stack:** Next.js 14, TypeORM, PostgreSQL, Azure
- **Code Structure:**
  - `esg-app/src/` - Main application code
  - `terraform/` - Infrastructure as Code
```

**Add coding standards:**

```markdown
## Project Standards

- Use Zod for all input validation
- Wrap API handlers with `withResponseHandler`
- Follow existing entity/service/dto pattern
```

**Restrict scope:**

```markdown
## Boundaries

- 🚫 **Never:** Modify migration files
- 🚫 **Never:** Change authentication configuration
```

### Creating a New Agent

1. Create a new file: `.github/agents/my-agent.md`
2. Add frontmatter with `name`, `description`, `tools`
3. Define role, scope, guidelines, and boundaries
4. Use with `@my_agent` in GitHub Copilot Chat

**Example: Test Agent**

```markdown
---
name: test_agent
description: Testing specialist for this project
tools: ["githubRepo", "search"]
---

You are a testing expert specializing in Jest and Playwright.

## Your role and scope

- **Role:** Write and improve tests for this repository
- **Scope:** Test files (`*.test.ts`, `*.spec.ts`, `tests/`)

## Guidelines

- Write comprehensive unit tests with Jest
- Write E2E tests with Playwright
- Aim for high coverage of critical paths
- Use existing test patterns as reference

## Boundaries

- ✅ **Always:** Follow existing test conventions
- 🚫 **Never:** Modify production code (only test files)
```

---

## Best Practices

### When to Use Each Agent

| Situation | Agent |
|-----------|-------|
| New project onboarding | Analyst → Review → Security → Docs |
| PR review | Review, Security (for sensitive changes) |
| Adding features | Docs (update documentation) |
| Security audit | Security |
| Improving docs | Docs |
| Technical debt assessment | Review |

### Tips for Effective Prompts

1. **Be specific** — Tell the agent exactly what you want
2. **Provide context** — Attach relevant files with `@`
3. **Specify output** — Say where to write results (e.g., `docs/review.md`)
4. **One task at a time** — Agents work best with focused requests

### Reviewing Agent Output

Always review generated documentation:

- Check for accuracy against actual code
- Verify no sensitive information is exposed
- Ensure consistency with existing documentation
- Update placeholder values (e.g., team names in CODEOWNERS)

---

## Troubleshooting

### Agent Not Recognized

- Ensure the file is in `.github/agents/`
- Check the `name` field in frontmatter matches your `@` mention
- Try referencing the full file path: `@.github/agents/agent-name.md`

### Incomplete Output

- Agent may have hit context limits
- Break the task into smaller parts
- Be more specific about what you need

### Inaccurate Analysis

- Agents analyze statically — they may miss runtime behavior
- Cross-reference findings with actual code
- Mark uncertain findings as "needs review"

---

