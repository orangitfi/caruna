# GitHub Actions Best Practices

## 1. Purpose

This document defines how GitHub Actions should be used to build, test, secure, and deliver software in a consistent, maintainable, and secure way.

The goal is to:

- standardize CI/CD across repositories
- maximize reuse of automation logic
- minimize duplication and hidden behavior
- ensure security controls are applied consistently
- keep workflows easy to understand and maintain

## 2. Core Principle

Everything reusable should be an Action. Workflows should orchestrate.

- Actions contain implementation logic
- Workflows define execution flow

## 3. Design Model

### Actions = Implementation

Actions contain reusable execution logic.

Examples:

- security scanning
- linting
- testing
- build steps
- packaging
- publishing
- deployment
- validation
- artifact handling

### Workflows = Orchestration

Workflows remain thin and declarative.

Responsibilities:

- define triggers
- define job structure
- define execution order
- enable parallel execution
- manage permissions
- pass inputs and secrets

## 4. Internal vs External Actions

Internal Actions are preferred for reusable logic.
Use internal Actions for:

- reusable engineering logic
- organization-standard processes
- security controls
- validation and quality gates

External Actions should be minimal and used only for example:

- checkout
- runtime setup
- artifact handling

### 4.1 Policy statement

Reusable logic must be implemented as Actions.
Internal Actions are preferred.
External Actions should be minimal and controlled.

## 5. Security Baseline (Node.js)

Run audit first:
npm audit --audit-level=high

Fails CI on high/critical vulnerabilities.
Run audit **before** `npm install` or `npm ci` — `npm audit` reads from `package-lock.json` and does not require packages to be installed.
This ensures vulnerable packages are never downloaded to the runner.

Disable install scripts:
export NPM_CONFIG_IGNORE_SCRIPTS=true

Prevents execution of:

- preinstall
- install
- postinstall
- prepare

Purpose: mitigate supply chain attacks.

### 5.1 Important distinction

- ignore-scripts → protects against malicious install-time behavior
- npm audit → protects against known vulnerabilities

Both are required.

### 5.2 Handling exceptions

If disabling scripts breaks the build:

- keep scripts disabled
- add explicit trusted steps

Example:
`npm ci
npx prisma generate
npm test`

## 5.3 Supply Chain Scanning (GuardDog)

[GuardDog](https://github.com/DataDog/guarddog) by Datadog detects **malicious packages** before they are installed.
It analyses dependency manifests (`requirements.txt`, `package-lock.json`, `go.mod`, `Gemfile.lock`) and checks each listed package for behavioural heuristics and metadata red flags.

This is different from Syft/Grype. Grype finds **known CVEs in legitimate packages**. GuardDog finds **packages that were never legitimate** — typosquats, hijacked maintainer accounts, packages with obfuscated code or exfiltration payloads.

Both are needed:

| Tool | Threat it addresses |
|---|---|
| GuardDog | Malicious / compromised packages, typosquatting, supply chain injection |
| Grype | Known CVEs in otherwise legitimate packages |

### What GuardDog checks

Source code heuristics (via Semgrep) include:

- obfuscated code or base64-executed payloads
- silent process execution at install time
- environment variable exfiltration
- install scripts that download and run remote binaries

Metadata heuristics include:

- typosquatting against popular packages
- unclaimed or compromised maintainer email domains
- mismatches between the repository and the published package

### Usage

```
# npm
guarddog npm verify package-lock.json --output-format sarif > guarddog.sarif

# PyPI
guarddog pypi verify requirements.txt --output-format sarif \
  --exclude-rules repository_integrity_mismatch > guarddog.sarif
```

The `--exclude-rules repository_integrity_mismatch` flag is commonly needed for PyPI because the rule produces false positives for packages that legitimately differ between PyPI and GitHub.

The SARIF output integrates directly with GitHub code scanning, producing inline PR annotations.

### When to run

Run GuardDog in parallel with other pre-test checks on every push and pull request — before `npm ci` or `pip install` are ever called. It reads only the lock file, so no packages are downloaded.

## 5.4 Container and Codebase Security Scanning (Syft / Grype)

For container images and polyglot codebases, `npm audit` alone is not sufficient.
Use [Syft](https://github.com/anchore/syft) and [Grype](https://github.com/anchore/grype) to cover all languages and OS packages.

**Syft** generates a Software Bill of Materials (SBOM) — a full inventory of every package inside a directory or container image.

**Grype** takes that SBOM and checks every package against known vulnerability databases.

### Why SBOM-first scanning

Generating the SBOM as a separate step has two advantages:

- The SBOM can be archived as a workflow artifact for supply chain audits.
- Grype scans the SBOM rather than the live filesystem, making results reproducible.

### Scanning source code

```
syft . -o json > sbom.json
grype sbom:sbom.json --only-fixed --fail-on high
```

- `--only-fixed` — only reports vulnerabilities that have an available fix, reducing noise.
- `--fail-on high` — fails CI on high or critical severity findings.

### Scanning a container image

```
syft myapp:latest -o json > sbom.json
syft myapp:latest -o spdx-json > sbom-spdx.json
syft myapp:latest -o cyclonedx-json > sbom-cyclonedx.json
grype sbom:sbom.json --only-fixed --fail-on high -o table
```

Three SBOM formats are generated so the artifact is useful to different downstream tooling (SPDX and CycloneDX are industry standards).

### When to run each scan

| Scan type | When |
|---|---|
| Source code scan | Every push — fast, catches dependency vulnerabilities early |
| Container image scan | After build — catches OS-level and base-image vulnerabilities |
| Scheduled scan | Daily — catches newly disclosed CVEs against existing images |

### Severity thresholds

| Level | Meaning |
|---|---|
| `critical` | Only critical findings fail the build |
| `high` | High and critical fail — recommended default |
| `medium` | Medium and above fail |
| `low` | All but negligible fail |
| `negligible` | Everything fails |

Use `high` as the default. Lower thresholds create too much noise and lead to alert fatigue.

## 5.5 Secret Scanning (Gitleaks)

[Gitleaks](https://github.com/gitleaks/gitleaks) detects **hardcoded secrets** committed to the repository — API keys, tokens, passwords, private keys, and other credentials that should never appear in source code or git history.

This is different from GuardDog and Grype. GuardDog finds malicious packages. Grype finds vulnerable packages. Gitleaks finds **secrets that have been leaked into the codebase or its git history**.

| Tool | Threat it addresses |
|---|---|
| GuardDog | Malicious / compromised packages, typosquatting, supply chain injection |
| Grype | Known CVEs in otherwise legitimate packages |
| Gitleaks | Hardcoded secrets, credentials, and tokens in source code and git history |

### What Gitleaks checks

Gitleaks scans using a large set of built-in rules covering common secret patterns:

- Cloud provider credentials (AWS, GCP, Azure)
- API keys and tokens (GitHub, Stripe, Slack, Twilio, SendGrid, and many others)
- Private keys (RSA, EC, PGP)
- Database connection strings with embedded credentials
- Generic high-entropy strings that match secret patterns
- JWT tokens and OAuth secrets

### Scan modes

**Detect mode** — scans the working directory or staged files:

```
gitleaks detect --source . --redact
```

**Git log mode** — scans the full commit history, not just the current state:

```
gitleaks detect --source . --log-opts="--all" --redact
```

The `--redact` flag masks the actual secret value in output, so the scan results themselves do not expose credentials.

### SARIF output

```
gitleaks detect --source . --report-format sarif --report-path gitleaks.sarif --redact
```

SARIF output integrates directly with GitHub code scanning, producing inline PR annotations for any secrets found.

### When to run

Run Gitleaks in parallel with GuardDog and other pre-test checks on every push and pull request. It reads only the repository files and git history — no packages need to be installed.

For repositories with a long history, the full `--log-opts="--all"` scan can be slow. A common pattern is to run the full history scan on a schedule and the working-directory scan on every push.

### Handling findings

A Gitleaks finding means a secret **may already be compromised**. The correct response is:

1. Rotate the credential immediately — do not wait.
2. Determine the blast radius (what systems the credential accesses).
3. Remove the secret from the repository and rewrite history if necessary using `git filter-repo`.
4. Add the secret pattern to `.gitleaks.toml` allowlist only if it is a confirmed false positive.

Never suppress a finding without investigation.

## 6. Workflow Design Principles

### 6.1 Keep workflows thin

Workflows should:

- call Actions
- define flow
- avoid inline logic

### 6.2 Use parallelization

Run independent checks in parallel:

- security
- lint

### 6.3 Gate later stages

Use needs:

- tests after checks
- publish after tests

### 6.4 Fail fast

Run fast checks early to reduce wasted time.

### 6.5 Use least privilege

```
permissions:
  contents: read
```

## 7. Anti-patterns

Avoid:

- large workflows with embedded logic
- copy-paste YAML
- excessive third-party Actions
- hidden business logic in external Actions
- enabling install scripts globally
- non-reproducible CI

## 8. Example Workflow

### 8.1 Workflow

```
name: CI Pipeline

on:
  push:
    branches: [main]
  pull_request:

permissions:
  contents: read

jobs:
  # Runs in parallel — no dependencies between security, lint, and code-scan
  security:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: ./.github/actions/npm-security-scan

  lint:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: ./.github/actions/lint

  security-scan-code:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: ./.github/actions/security-setup
      - uses: ./.github/actions/security-scan-code
        with:
          directory: ./src

  guarddog-scan:
    runs-on: ubuntu-latest
    permissions:
      contents: read
      security-events: write  # required to upload SARIF to GitHub code scanning
    steps:
      - uses: actions/checkout@v4
      - uses: ./.github/actions/guarddog-scan
        with:
          ecosystem: npm
          manifest: package-lock.json

  gitleaks-scan:
    runs-on: ubuntu-latest
    permissions:
      contents: read
      security-events: write  # required to upload SARIF to GitHub code scanning
    steps:
      - uses: actions/checkout@v4
        with:
          fetch-depth: 0  # full history required for git log scan
      - uses: ./.github/actions/gitleaks-scan

  test:
    needs: [security, lint, security-scan-code, guarddog-scan, gitleaks-scan]
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: ./.github/actions/test

  build:
    needs: [test]
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: ./.github/actions/build

  docker-scan:
    needs: [build]
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: ./.github/actions/docker-scan
        with:
          working-directory: .
          dockerfile-path: ./Dockerfile
          image-name: myapp
          image-tag: ${{ github.sha }}
          fail-on-severity: high

  publish:
    needs: [docker-scan]
    if: github.ref == 'refs/heads/main'
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: ./.github/actions/publish-artifact
        with:
          repository-url: ${{ vars.ARTIFACTORY_URL }}
          username: ${{ secrets.ARTIFACTORY_USERNAME }}
          password: ${{ secrets.ARTIFACTORY_PASSWORD }}
```

### 8.2 Action: npm security scan

```
name: npm security scan

runs:
  using: composite
  steps:
    - uses: actions/setup-node@v4
      with:
        node-version: 20
        cache: npm

    - shell: bash
      run: npm audit --audit-level=high

    - shell: bash
      run: |
        export NPM_CONFIG_IGNORE_SCRIPTS=true
        npm ci
```

### 8.3 Action: lint

```
name: lint

runs:
  using: composite
  steps:
    - uses: actions/setup-node@v4
      with:
        node-version: 20
        cache: npm

    - run: npm ci
      shell: bash

    - run: npm run lint
      shell: bash
```

### 8.4 Action: test

```
name: test

runs:
  using: composite
  steps:
    - uses: actions/setup-node@v4
      with:
        node-version: 20
        cache: npm

    - run: npm ci
      shell: bash

    - run: npm test
      shell: bash
```

### 8.5 Action: publish artifact

```
name: publish artifact

inputs:
  repository-url:
    required: true
  username:
    required: true
  password:
    required: true

runs:
  using: composite
  steps:
    - uses: actions/setup-node@v4
      with:
        node-version: 20
        cache: npm

    - run: npm ci
      shell: bash

    - run: npm run build
      shell: bash

    - shell: bash
      env:
        ARTIFACTORY_URL: ${{ inputs.repository-url }}
        ARTIFACTORY_USERNAME: ${{ inputs.username }}
        ARTIFACTORY_PASSWORD: ${{ inputs.password }}
      run: npm run publish:artifact
```

### 8.6 Action: security-setup

Installs Syft and Grype on the runner. Run this before any action that calls
`syft` or `grype` directly.

```
name: Security Setup
description: Installs Syft and Grype

runs:
  using: composite
  steps:
    - name: Install Syft
      shell: bash
      run: |
        curl -sSfL https://raw.githubusercontent.com/anchore/syft/main/install.sh | sh -s -- -b /usr/local/bin

    - name: Install Grype
      shell: bash
      run: |
        curl -sSfL https://raw.githubusercontent.com/anchore/grype/main/install.sh | sh -s -- -b /usr/local/bin
```

### 8.7 Action: security-scan-code

Scans a source directory. Requires `security-setup` to have run first.

Generates `sbom.json` in the target directory and fails the job if any
high-severity vulnerabilities with available fixes are found.

```
name: Security Scan for Codebase
description: Generate SBOM with Syft and run security scan with Grype

inputs:
  directory:
    description: The directory to scan
    required: true

runs:
  using: composite
  steps:
    - name: Generate SBOM with Syft
      shell: bash
      working-directory: ${{ inputs.directory }}
      run: |
        syft . -o json > sbom.json

    - name: Run Security Scan with Grype
      shell: bash
      working-directory: ${{ inputs.directory }}
      run: |
        grype sbom:sbom.json --only-fixed --fail-on high
```

### 8.8 Action: docker-scan

Builds a Docker image, generates SBOMs in three formats (JSON, SPDX,
CycloneDX), scans with Grype, uploads SBOMs as workflow artifacts, and
cleans up. Does not push the image to any registry.

```
name: Docker Security Scan
description: Build and scan a Docker image using Grype and Syft

inputs:
  working-directory:
    description: Path to the directory containing Dockerfile and source code
    required: true
  dockerfile-path:
    description: Relative path to the Dockerfile (from working directory)
    required: true
  image-name:
    description: Name of the Docker image
    required: true
  image-tag:
    description: Docker image tag
    required: true
    default: latest
  fail-on-severity:
    description: "Fail on vulnerabilities of this severity or higher (critical, high, medium, low, negligible)"
    required: false
    default: high

outputs:
  scan-result:
    description: Result of the security scan (passed/failed)
    value: ${{ steps.scan.outputs.result }}

runs:
  using: composite
  steps:
    - name: Set up Docker Buildx
      uses: docker/setup-buildx-action@v3

    - name: Build Docker Image
      shell: bash
      working-directory: ${{ inputs.working-directory }}
      run: |
        docker build -f ${{ inputs.dockerfile-path }} \
          -t ${{ inputs.image-name }}:${{ inputs.image-tag }} .

    - name: Install Syft
      shell: bash
      run: |
        curl -sSfL https://raw.githubusercontent.com/anchore/syft/main/install.sh | sh -s -- -b /usr/local/bin

    - name: Generate SBOM with Syft
      shell: bash
      working-directory: ${{ inputs.working-directory }}
      run: |
        syft ${{ inputs.image-name }}:${{ inputs.image-tag }} -o json > sbom.json
        syft ${{ inputs.image-name }}:${{ inputs.image-tag }} -o spdx-json > sbom-spdx.json
        syft ${{ inputs.image-name }}:${{ inputs.image-tag }} -o cyclonedx-json > sbom-cyclonedx.json

    - name: Install Grype
      shell: bash
      run: |
        curl -sSfL https://raw.githubusercontent.com/anchore/grype/main/install.sh | sh -s -- -b /usr/local/bin

    - name: Run Security Scan with Grype
      id: scan
      shell: bash
      working-directory: ${{ inputs.working-directory }}
      run: |
        if grype sbom:sbom.json --only-fixed --fail-on ${{ inputs.fail-on-severity }} -o table; then
          echo "result=passed" >> $GITHUB_OUTPUT
        else
          echo "result=failed" >> $GITHUB_OUTPUT
          exit 1
        fi

    - name: Upload SBOM as Artifact
      if: always()
      uses: actions/upload-artifact@v4
      with:
        name: sbom-${{ inputs.image-name }}-${{ inputs.image-tag }}
        path: ${{ inputs.working-directory }}/sbom*.json
        retention-days: 90

    - name: Clean up
      if: always()
      shell: bash
      working-directory: ${{ inputs.working-directory }}
      run: |
        rm -f sbom.json sbom-spdx.json sbom-cyclonedx.json
        docker rmi ${{ inputs.image-name }}:${{ inputs.image-tag }} || true
```

### 8.9 Action: guarddog-scan



Scans a dependency manifest for malicious packages using GuardDog.
Outputs a SARIF file and uploads it to GitHub code scanning so findings
appear as inline PR annotations.

The `security-events: write` permission must be set on the calling job.

Supported ecosystems: `npm`, `pypi`, `go`, `rubygems`.

GuardDog is a Python tool installed via pip. For Node.js projects where
keeping the runner Python-free is preferred, a Docker image is available
as an alternative:

```
docker run --rm -v $(pwd):/workspace ghcr.io/datadog/guarddog \
  npm verify /workspace/package-lock.json --output-format sarif > guarddog.sarif
```

The action below uses pip install, which works on any standard
`ubuntu-latest` runner regardless of the project's primary language.

```
name: GuardDog Supply Chain Scan
description: Scan dependency manifest for malicious packages using GuardDog

inputs:
  ecosystem:
    description: "Package ecosystem to scan (npm, pypi, go, rubygems)"
    required: true
  manifest:
    description: "Path to the dependency manifest or lock file"
    required: true
  exclude-rules:
    description: "Comma-separated list of GuardDog rules to exclude"
    required: false
    default: ""

runs:
  using: composite
  steps:
    - name: Set up Python
      uses: actions/setup-python@v5
      with:
        python-version: "3.12"

    - name: Install GuardDog
      shell: bash
      run: pip install guarddog

    - name: Run GuardDog scan
      shell: bash
      run: |
        EXCLUDE_FLAGS=""
        if [ -n "${{ inputs.exclude-rules }}" ]; then
          for rule in $(echo "${{ inputs.exclude-rules }}" | tr ',' ' '); do
            EXCLUDE_FLAGS="$EXCLUDE_FLAGS --exclude-rules $rule"
          done
        fi
        guarddog ${{ inputs.ecosystem }} verify ${{ inputs.manifest }} \
          --output-format sarif \
          $EXCLUDE_FLAGS > guarddog.sarif || true

    - name: Upload SARIF to GitHub code scanning
      uses: github/codeql-action/upload-sarif@v3
      with:
        category: guarddog
        sarif_file: guarddog.sarif
```

### 8.10 Action: gitleaks-scan

Scans the repository for hardcoded secrets using Gitleaks.
Outputs a SARIF file and uploads it to GitHub code scanning so findings
appear as inline PR annotations.

The calling job must check out with `fetch-depth: 0` so the full git
history is available for scanning. The `security-events: write` permission
must be set on the calling job.

```
name: Gitleaks Secret Scan
description: Scan repository for hardcoded secrets using Gitleaks

runs:
  using: composite
  steps:
    - name: Install Gitleaks
      shell: bash
      run: |
        curl -sSfL https://github.com/gitleaks/gitleaks/releases/latest/download/gitleaks_$(uname -s | tr '[:upper:]' '[:lower:]')_x64.tar.gz \
          | tar -xz -C /usr/local/bin gitleaks

    - name: Run Gitleaks scan
      shell: bash
      run: |
        gitleaks detect \
          --source . \
          --report-format sarif \
          --report-path gitleaks.sarif \
          --redact \
          --exit-code 1 || GITLEAKS_EXIT=$?
        # Always upload the SARIF even when findings are present
        echo "GITLEAKS_EXIT=${GITLEAKS_EXIT:-0}" >> $GITHUB_ENV
        exit 0

    - name: Upload SARIF to GitHub code scanning
      uses: github/codeql-action/upload-sarif@v3
      with:
        category: gitleaks
        sarif_file: gitleaks.sarif

    - name: Fail if secrets were found
      shell: bash
      run: exit ${GITLEAKS_EXIT:-0}
```

The two-step exit pattern (capture exit code, upload SARIF, then re-fail)
ensures findings are always visible in the GitHub Security tab even when
the job fails.
