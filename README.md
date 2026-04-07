# Template Repository

This is a template repository containing reusable GitHub Actions workflows and common project configurations.

## Repository Structure

```
.
├── src/           # Source code directory
├── docs/          # Documentation
├── tests/         # Test files
├── .github/       # GitHub specific files
│   └── workflows/ # GitHub Actions workflows
└── README.md      # This file
```

## Features

- Reusable GitHub Actions workflows
- Standardized project structure
- Documentation templates
- Test configuration templates
- **OrangIT AI Agents Templates** for Copilot, Claude, Cursor, OpenCode, and Codex

---

## OrangIT AI Agents Templates

This repository includes **OrangIT AI Agents Templates** for rapid enablement of advanced AI-powered workflows in your projects. These templates provide ready-to-use agent definitions and scripts for Copilot, Claude, Cursor, OpenCode, and Codex.

### How to Add OrangIT AI Agents to Your Project

1. **Install [UV](https://docs.astral.sh/uv/getting-started/installation/)** on your operating system (required for agent script execution).
2. **Copy the `.ai` directory** from this `orangit-template` repository to the root of your project repository.
3. **Run the agent generation script:**
   ```sh
   sh .ai/scripts/generate-agents.sh
   ```
   This will generate the agent definitions for all supported tools (Copilot, Claude, Cursor, OpenCode, Codex).
4. **Start using the agents** in your preferred tool.

### Main OrangIT AI Agents

There are two primary orchestrator agents:

1. **orangit_workflow** — For daily development work: ticket refinement, test generation, coding, documentation, code review, and security analysis. This agent coordinates subagents for a full TDD workflow.
2. **orangit_ai_audit** — For full codebase audits: structure, documentation, code quality, and security. Produces comprehensive audit reports and recommendations.

Additional agents:

- **orangit_updater** — For regular dependency and security updates.
- **orangit_upgrader** — For major upgrades that require code refactoring.

### Customizing Agents

Teams can modify the agent templates to suit their needs. The recommended workflow is:

1. Edit the agent definitions in `.ai/agents/` as needed.
2. Re-run the generation script:
   ```sh
   sh .ai/scripts/generate-agents.sh
   ```
   This ensures your changes are propagated to all supported tools.

For more details, see `.ai/README.md` and the [AGENTS.md](AGENTS.md) file in this repository.

## Getting Started

1. Click "Use this template" to create a new repository from this template
2. Clone your new repository
3. Customize the files according to your project needs

## Documentation

Detailed documentation can be found in the [docs](./docs/index.md) directory.

## Contributing

Instructions for contributing [Contributing](CONTRIBUTING.md)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
