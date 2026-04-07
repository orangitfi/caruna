# AI-Assisted Takeover — Talking Points

Talking points for presenting the `orangit_ai_audit` workflow and OrangIT's AI agent system for codebase takeover situations.

---

## 1. Why Agents (vs. Ad-Hoc AI Prompting)?

- **Consistency.** Without agents, every developer writes their own prompts and gets wildly different quality and coverage. Agents encode OrangIT's best practices into repeatable, versioned instructions — the same 10-area audit checklist runs every time, regardless of who triggers it.
- **Specialization beats generalism.** A single LLM prompt trying to do audit + security + docs at once produces shallow results. Dedicated agents (auditor, reviewer, security reviewer, documenter) each go deep in their domain, producing structured outputs that feed into the next step.
- **Orchestration and context passing.** The `orangit_ai_audit` orchestrator chains 4 specialist agents in sequence. Each agent builds on the findings of the previous one — the security reviewer sees the audit report, the documenter knows what's missing. This is impossible with one-shot prompting.
- **Guardrails.** Each agent has explicit boundaries: "never modify source code", "prioritise accuracy over completeness", "label assumptions vs. facts". This prevents the AI from going rogue during a sensitive takeover situation.

---

## 2. Why OrangIT's Agents Specifically?

- **Define once, run everywhere.** Agent behavior is defined in YAML (`.ai/agent/*.yaml`). A build system generates platform-specific configs for 5 tools: Claude Code, GitHub Copilot, OpenCode, Cursor, and Codex. Teams pick their preferred tool — the workflow is identical.
- **Takeover-oriented by design.** The auditor agent is explicitly scoped for "takeover and maintenance onboarding situations." The 10 audit areas (project structure, dependencies, test coverage, operational quality, technical debt, etc.) map directly to the questions OrangIT needs answered when inheriting a codebase.
- **Structured, actionable outputs.** Each agent produces specific artifacts: `docs/audit.md`, `docs/review.md`, `docs/security.md`, `docs/design.md`, ADRs. These aren't chatbot conversations — they're committed documentation that becomes part of the repository.
- **Team-customizable.** The YAML definitions are a starting point. Teams adapt agents to project-specific conventions, tech stacks, and standards. Improvements that benefit everyone go back to `orangit-template`.
- **Not just audit — a full toolkit.** Beyond takeover, the same agent system covers daily development (`orangit_workflow` with TDD cycle), dependency updates (`orangit_updater`), framework upgrades (`orangit_upgrader`), E2E test writing, and UI drift detection.

---

## 3. The AI Audit Workflow — What Actually Happens

Four sequential steps, each building on the last:

| Step | Agent | Produces | Key Value |
|------|-------|----------|-----------|
| 1 | **orangit_auditor** | `docs/audit.md` | 10-area rated assessment (good / needs attention / missing), risk register, phased recommendations |
| 2 | **orangit_documenter** | README, `docs/design.md`, ADRs, operational manual | Fills documentation gaps — architecture, setup, operations, design decisions |
| 3 | **orangit_reviewer** | `docs/review.md` | Code quality findings with severity ratings, specific file/line references, fix suggestions |
| 4 | **orangit_security_reviewer** | `docs/security.md` | OWASP-aligned vulnerability findings, risk ratings, remediation advice, blocking issues flagged |

---

## 4. Outcomes by Stakeholder

### For the Customer

- Faster, more thorough onboarding to their codebase — days instead of weeks of manual analysis.
- Transparent deliverables: they receive concrete audit reports, not vague assessments.
- Security vulnerabilities surfaced early, before OrangIT starts maintaining the system.
- Documented architecture and operational procedures reduce bus factor risk immediately.

### For OrangIT

- Standardized takeover process across all projects and teams — predictable quality, predictable timeline.
- Reduced risk: the audit catches technical debt, missing tests, security holes, and operational gaps *before* we own the maintenance contract.
- The audit artifacts become the basis for maintenance planning — the risk register and phased recommendations directly inform backlog priorities.
- Competitive differentiation: we can show customers a structured, AI-augmented takeover methodology, not just "we'll look at the code."

### For Developers

- No more starting from scratch trying to understand an unfamiliar codebase. The audit + design doc + ADRs give immediate context.
- Actionable starting points: severity-rated findings tell you what to fix first.
- The same agents continue to help during maintenance (daily `orangit_workflow` for TDD, code review, security review).
- Tool freedom: developers use their preferred IDE/tool (Copilot, Claude, Cursor, OpenCode) — the agents work across all of them.

---

## 5. How This Affects Maintenance Itself

- **Baseline established from day one.** The audit report becomes the baseline against which all future maintenance is measured. You know the starting state of test coverage, technical debt, security posture, and documentation.
- **Documentation debt eliminated upfront.** The documenter agent creates README, design docs, ADRs, and operational manuals during takeover. Maintenance developers don't inherit an undocumented system.
- **Prioritized backlog, not guesswork.** The audit's risk register and phased recommendations give the maintenance team a ready-made improvement backlog ranked by severity and impact.
- **Continuous quality enforcement.** The same reviewer and security reviewer agents used during takeover are used during daily development via `orangit_workflow`. Every PR gets the same quality bar.
- **Dependency and security hygiene.** The `orangit_updater` and `orangit_upgrader` agents handle ongoing dependency updates with Syft/Grype SBOM scanning, iterating until High/Critical vulnerabilities are resolved — not a one-time audit, but continuous.
- **Onboarding new team members.** When developers rotate onto a project, the audit artifacts and generated documentation serve as onboarding material. The AI agents are already configured for the project's specific context.

---

## 6. Key Differentiators to Emphasize

- **Not just "we use AI"** — it's a structured, multi-agent system with defined roles, boundaries, and outputs.
- **Accuracy over completeness** — the agents are instructed to label assumptions vs. facts, skip uncertain findings rather than assert, and prioritize being right over being comprehensive.
- **Read-only during audit** — the audit agents never modify code. They observe, analyze, and report. This is critical for trust during takeover.
- **Portable across tools** — single YAML source of truth, generated for 5 platforms. No vendor lock-in to one AI tool.
- **Versioned and testable** — the agent definitions are code in a repository with a test suite. They evolve with the team, not disappear in chat history.
