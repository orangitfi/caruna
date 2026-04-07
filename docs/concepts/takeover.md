# Software Maintenance Takeover Model

## Overview

This model describes a three-phase approach to software maintenance takeover:

- **Phase 1: Takeover (Minimum Viable Maintenance Capability)**
- **Phase 2: Ramp-up (capability building)**
- **Phase 3: Normal Operations (BAU)**

---

# Phase 1 – Takeover

Goal: achieve a **minimum viable maintenance capability**, where:

- All required access is in place
- The system and development practices are understood
- A controlled change can be deployed to production
- Monthly billing can begin

## 1. Service Setup

Service onboarding into OrangIT operations:

**Tools & environments**

- Create Jira project
- Create Confluence space
- Enable the project and initial configurations
- Create tasks in time tracking system

**Communication**

- Create Google Groups inbox for the project
- Create Slack channels (internal, maybe external, notifications)

**Processes & documentation**

- Create a service description document (how the service is operated)
- Define ticket types, workflows, and SLAs in Jira/JSM
- Define incident, change, and request handling practices

## 2. Kickoff

- Introduction between teams
- Define service start objectives
- Clarify scope and expectations

## 2. Technical Audit

### AI audit of the codebase

- Code analysis (structure, complexity, risks)

### Audit & Review

- Architecture review
- Code quality
- Technical debt

### Security review

- Identification of security risks
- Access management
- Infrastructure and dependency risks

## 3. Documentation

Create key documentation:

- **Design document**
- **Operation manual** (runbooks and maintenance instructions)

## 4. Workshop series (4 sessions)

Workshops led by developers:

### Workshop 1 – Local Development Environment

- Setup of the development environment from scratch (step-by-step)
- Repository cloning and dependency installation
- Environment variables and configuration (secrets, .env, vaults)
- Running databases and dependencies (e.g. Docker)
- Running the application locally
- Debugging and log inspection
- Running tests (unit / integration)
- Build and startup scripts (make, npm, gradle, etc.)
- Common issues and how to resolve them ("gotchas")
- Development tools (IDE, linters, formatters)
- Branching model and development workflow in practice

**Goal:**
➡️ Every OrangIT developer can run the system locally and understands key dependencies of the development environment

**Recording & onboarding:**

- Workshop is recorded
- Recording is used for onboarding new developers

**Assumptions & responsibilities:**

- Assumption: we receive a working system
- Assumption: original developers are responsible for fixing existing defects
- Both original developers and OrangIT developers participate

### Workshop 2 – Non-production & CI/CD

- Structure and roles of non-production environments (dev, test, staging)
- Differences between environments (configuration, data, capacity)
- CI/CD pipelines walkthrough (build, test, deploy)
- Deployment process step-by-step
- Rollback practices
- Release models (e.g. trunk-based, GitFlow)
- Branching strategy in practice
- Artifact management (registries, versioning)
- Secrets management
- Infrastructure as Code (if applicable)
- Testing strategy (unit, integration, e2e)
- Quality assurance in CI (linting, security scans, quality gates)
- Common pipeline failures and how to resolve them

**Goal:**
➡️ OrangIT can independently deploy changes to non-production environments via CI/CD pipelines

**Recording & onboarding:**

- Workshop is recorded
- Recording is used for onboarding new developers

**Assumptions & responsibilities:**

- Assumption: CI/CD pipeline is functional and accessible
- Assumption: non-production environments are operational
- Original developers support pipeline-related issues during transition
- Both original developers and OrangIT developers participate

### Workshop 3 – Production

- Production architecture (infrastructure, services, dependencies)
- Operational scope (what is maintained daily)
- Monitoring tools and dashboards
- Alerts (what is measured and when alerts trigger)
- Incident management practices
- Recent incidents and root cause analysis (RCA)
- Capacity and scalability
- Backup & restore
- Disaster Recovery Plan (DRP):

  - Recovery objectives (RTO, RPO)
  - Prioritization of critical services
  - DR process step-by-step
  - Failover / fallback mechanisms
  - DR testing practices and latest test results

- Production deployments (how to deploy safely)
- Production rollback
- Maintenance windows and downtime
- Production security practices
- Access management and permissions

**Goal:**
➡️ OrangIT understands the production environment and can safely participate in production operations

**Recording & onboarding:**

- Workshop is recorded
- Recording is used for onboarding new developers

**Assumptions & responsibilities:**

- Assumption: production environment is stable and sufficiently documented
- Assumption: monitoring and alerting exist (even if not optimized)
- Original developers handle critical issues during takeover phase
- OrangIT starts in a supporting role, responsibility increases in Phase 2
- Both original developers and OrangIT developers participate

### Workshop 4 – Controlled Change

- Plan and implement a small, visible change in production
- No functional logic changes (e.g. UI/configuration change)
- Execute full process: planning → approval → implementation → deployment → verification

**Processes (core):**

- Change management in practice (ticketing, approvals, CAB if needed)
- Release process (scheduling, versioning, release notes)
- Incident & rollback readiness during change
- Definition of Done / acceptance criteria
- Audit trail: what is documented and where (Jira/Confluence)

**Communication (core):**

- Stakeholder identification (business, support, infra)
- Pre-communication (what, when, impact)
- Communication during change (status updates, war room if needed)
- Post-communication (outcome, impact, follow-ups)
- Shared channels (Slack, incident inbox) and responsibilities

**Goal:**
➡️ OrangIT can deliver a production change in a controlled manner following agreed processes and communication practices

**Recording & onboarding:**

- Workshop is recorded
- Recording is used for onboarding new developers

**Assumptions & responsibilities:**

- Assumption: required access and tools are in place
- Assumption: core processes (change/release/incident) are defined at least at a basic level
- Original developers support the first change
- Both original developers and OrangIT developers participate

## 6. Retrospectives

**Internal retrospective (OrangIT):**

- Developers and service team review the takeover phase
- Identify what went well and what should be improved
- Capture risks, gaps, and improvement actions
- Feed learnings into internal practices and future takeovers

**External retrospective (Customer):**

- Customer provides feedback on takeover experience
- Review collaboration, communication, and expectations
- Align on improvement areas and next steps
- Strengthen partnership and transparency

---

# Phase 2 – Ramp-up

**Goal: capability building**

Goal: move from minimum capability to normal operating level

Key activities:

- Address audit findings
- Review backlog
- Manage technical debt
- Improve documentation
- Enhance monitoring and alerting
- Route alerts to OrangIT
- Stabilize processes

---

# Phase 3 – Normal Operations (BAU)

**Goal: stable maintenance and continuous improvement**

Characteristics:

- Established processes
- Proactive maintenance
- Continuous improvement
- Regular reporting
- SLA-level operations

---

# Summary

- **Phase 1:** Takeover → minimum capability and billing start
- **Phase 2:** Ramp-up → capability building
- **Phase 3:** BAU → stable maintenance and continuous improvement

This model ensures a controlled transition without disruptions and creates a foundation for long-term maintenance.
