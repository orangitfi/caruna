# OrangIT AI Agents — Slack Announcement

*Copy-paste the text below into Slack:*

---

**Introducing OrangIT AI Agents**

We now have a shared set of AI coding agents that work across all the AI tools we use — Claude Code, GitHub Copilot, OpenCode, Cursor, and Codex.

**What is it?**
A `.ai/` folder you copy into your repository. Run one script and it generates agent definitions for your team's chosen AI tools. The agents define consistent workflows for development, code review, security review, testing, and documentation — so everyone gets the same quality bar regardless of which tool they prefer.

**Two main workflows:**

1. `orangit_workflow` — for daily work: ticket refinement, estimates, implementing features with TDD, code review, security review, and doc updates.
   Example: `@orangit_workflow review changes in this branch since main`

2. `orangit_ai_audit` — for codebase takeover, onboarding, or audit. Performs a full codebase audit and generates documentation, code quality reports, and security reviews.
   Example: `@orangit_ai_audit we are taking over this codebase. Do a full audit.`

**How to get started:**
1. Copy the `.ai/` folder from `orangit-template` into your repo
2. Run `cd .ai && uv sync` (requires `uv`)
3. Run `.ai/scripts/generate-agents.sh --platforms claude copilot` (pick your tools)
4. Commit the generated files

**What teams should do:**
- Decide which AI tools your team uses and generate only those
- Refine the agent definitions for your project's specific needs
- If you find improvements useful for everyone, propose them to the `orangit-template` repo
- Discuss significant changes with your team lead before merging — avoid solo major rewrites

Full documentation: see `.ai/README.md` in the `orangit-template` repository.
