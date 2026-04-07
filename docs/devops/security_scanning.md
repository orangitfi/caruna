# Security Scanning

The code is in orangit-template repository: [GitHub Link](https://github.com/orangitfi/orangit-template)

## Overview

This repository implements scheduled security scanning to continuously monitor containerized applications for vulnerabilities. Security is a moving target - new vulnerabilities are discovered daily, and what was secure yesterday may be vulnerable today. Scheduled builds ensure we detect security issues as soon as they are disclosed, enabling rapid response.

## Why Scheduled Security Scanning?

### The Problem

- **New CVEs are published daily**: A container that passed security checks last week may have critical vulnerabilities today
- **Dependencies change**: Upstream images and libraries receive security patches constantly
- **Dormant projects are at risk**: Repositories that aren't actively developed can accumulate critical vulnerabilities without anyone noticing
- **Production exposure**: Applications running in production may be vulnerable without your knowledge

### The Solution

Scheduled security scanning provides:

- **Early detection**: Alert on newly discovered vulnerabilities before exploitation
- **Continuous monitoring**: Regular checks ensure security posture doesn't degrade
- **Compliance**: Meet regulatory requirements for continuous security assessment
- **Peace of mind**: Know immediately when security issues affect your applications

### Customer Communication

When implementing scheduled security scanning for a client project, clear communication about scope, necessity, and effort is critical. Below is an example email template:

---

**Subject: Proposal: Implementing Automated Security Scanning for [Project Name]**

Dear [Customer Name],

We would like to propose implementing automated scheduled security scanning for the [Project Name] application. This will provide continuous security monitoring and early detection of vulnerabilities.

**What We're Proposing:**

We will implement a comprehensive security scanning pipeline that runs automatically every day at 2 AM UTC. The system will:

1. **Scan application source code** for vulnerable dependencies using Syft and Grype
2. **Lint Dockerfiles** for security best practices and configuration issues using Hadolint
3. **Scan container images** for vulnerabilities across all layers and generate Software Bill of Materials (SBOM)
4. **Alert the team immediately** when security issues are detected
5. **Store SBOM artifacts** for compliance and audit purposes

**Why This Is Necessary:**

Security is a constantly moving target. New vulnerabilities (CVEs) are published every day - an average of 50+ new CVEs are disclosed daily. A container or application that passed security checks last week may have critical vulnerabilities today due to:

- Newly discovered vulnerabilities in base images (e.g., Alpine Linux, Ubuntu, nginx)
- Security issues found in application dependencies (npm packages, Python libraries, etc.)
- Upstream security patches that need to be applied

Without continuous monitoring, we won't know about these issues until:

- A security audit discovers them (embarrassing and potentially expensive)
- An actual security breach occurs (catastrophic)
- Compliance requirements flag them during review (blocking)

**Real-World Example:**

In December 2021, the Log4Shell vulnerability was discovered. Organizations with scheduled security scanning detected it within hours and could respond immediately. Those without continuous monitoring often didn't discover they were vulnerable for weeks or months, leaving them exposed during the period when exploitation was most active.

**Work Estimate:**

**Initial Implementation: 8-12 hours**

- Setup GitHub Actions workflows and security scanning actions: 4 hours
- Configure scanning thresholds and exception handling: 2 hours
- Documentation and team training: 2 hours
- Contingency for initial security fixes: 2-4 hours

**Benefits:**

- **Compliance Ready:** Meet SOC 2, ISO 27001, and other security audit requirements
- **Reduced Risk:** Early detection prevents security incidents
- **Cost Effective:** Far less expensive than dealing with a security breach
- **Customer Confidence:** Demonstrate proactive security practices
- **Insurance:** May reduce cybersecurity insurance premiums

**Next Steps:**

If you approve, we can begin implementation next week and have the system operational within 2-3 business days. We'll provide a handover document and brief training session for your team on how to respond to security alerts.

Please let us know if you have any questions or would like to discuss this further.

Best regards,  
[Your Name]  
[Your Title]

---

**Email Variations for Different Scenarios:**

**For Budget-Conscious Clients:**

> "While the initial investment is 16-20 hours, this is a one-time setup cost that provides continuous value. Compare this to the cost of a security breach (average: $4.45M according to IBM) or failed compliance audit (easily $50K+ in remediation). The ROI is clear."

**For Compliance-Driven Clients:**

> "Many security frameworks (SOC 2, ISO 27001, PCI-DSS) require continuous vulnerability monitoring. This implementation directly addresses those requirements and provides audit-ready documentation through generated SBOMs."

**For Technical Stakeholders:**

> "We're using industry-standard open-source tools (Syft, Grype, Hadolint) from Anchore, the same tools used by Fortune 500 companies. The implementation is non-invasive - it runs in CI/CD pipelines without requiring changes to production infrastructure."

## Workflow Architecture

The security scanning workflow runs **daily at 2 AM UTC** and can be triggered manually. It performs three types of security checks:

> **Note:** If your repository does not use Docker containers, you can remove all Docker-related jobs from the workflow. Simply delete the `docker-lint` and `docker-scan` jobs, remove them from the `needs` array in the summary job, and keep only the `security-scan-code` job for source code vulnerability scanning. This is common for libraries, APIs without containerization, or frontend-only applications.

### 1. Code-Level Security Scanning

- **Tool**: Syft + Grype
- **Target**: Source code in `./src` directory
- **Purpose**: Scan application dependencies for known vulnerabilities
- **Fails on**: High severity or above

### 2. Dockerfile Linting

- **Tool**: Hadolint
- **Target**: `./Dockerfile` at repository root
- **Purpose**: Check for best practices and security issues in Dockerfile
- **Checks**: Common mistakes, security violations, style issues

> **Note:** Dockerfile linting is optional and can be removed from the workflow if desired. However, it is **highly recommended** to keep it enabled as it enforces best practices, catches common security misconfigurations, and improves container reliability. To remove, simply delete the `docker-lint` job from the workflow file and remove it from the `needs` array in the summary job.

### 3. Container Image Security Scanning

- **Tool**: Syft + Grype
- **Target**: Built Docker image
- **Purpose**: Comprehensive vulnerability scanning of final container
- **Artifacts**: SBOM (Software Bill of Materials) in multiple formats
- **Fails on**: High or critical severity vulnerabilities

## Response Workflow

### Daily Operations

1. **Morning Check** (recommended: 9 AM local time)
   - One repository owner checks the scheduled build status
   - Review GitHub Actions tab for the scheduled-test workflow
   - If green ✅: No action needed
   - If red ❌: Proceed to failure workflow

### Failure Response Workflow

When scheduled security scan fails:

#### 1. **Immediate Assessment** (Within 1 hour)

```
Priority: HIGH
Type: All-hands event
```

**Actions:**

- Stop current work and assess the failure
- Check workflow logs to identify:
  - Which job failed (code scan, lint, container scan)
  - What vulnerabilities were detected
  - Severity levels (Critical, High, Medium)
  - Whether fixes are available

#### 2. **Impact Analysis** (Within 2 hours)

```
Question: Does this affect production?
```

**Determine:**

- Is the vulnerable component running in production?
- What is the exploitability (check EPSS score)
- What is the blast radius if exploited?
- Are there known exploits in the wild?

**Decision Matrix:**

| Severity | Production Affected | Action           | Timeline      |
| -------- | ------------------- | ---------------- | ------------- |
| Critical | Yes                 | Emergency hotfix | Immediate     |
| Critical | No                  | Priority fix     | Same day      |
| High     | Yes                 | Urgent fix       | Within 24h    |
| High     | No                  | Scheduled fix    | Within 72h    |
| Medium   | Yes                 | Planned fix      | Within 1 week |
| Medium   | No                  | Backlog          | Next sprint   |

#### 3. **Remediation** (Timeline per matrix)

**For production-affecting issues:**

1. **Hotfix Branch**

   ```bash
   git checkout -b hotfix/security-cve-yyyy-xxxxx
   ```

2. **Fix the Issue**
   - Update vulnerable dependencies
   - Upgrade base images
   - Apply patches
3. **Verify Fix**

   ```bash
   # Run security scan locally
   docker build -t app:test .
   syft app:test -o json > sbom.json
   grype sbom:sbom.json --only-fixed --fail-on high
   ```

4. **Deploy to Production**
   - Follow emergency deployment procedure
   - Document changes in incident log
   - Update stakeholders

#### 4. **Post-Incident** (Within 1 week)

- Document the incident and response
- Update runbooks if needed
- Review detection time and response time
- Identify process improvements

## Future Extensions

### OWASP ZAP Web Application Scanning

Add dynamic security testing for web applications:

```yaml
owasp-zap-scan:
  runs-on: ubuntu-latest
  steps:
    - name: ZAP Scan
      uses: zaproxy/action-full-scan@v0.7.0
      with:
        target: "https://your-app-url.com"
        fail_action: true
```

### Unit Tests

Catch regressions in dormant repositories:

```yaml
unit-tests:
  runs-on: ubuntu-latest
  steps:
    - uses: actions/checkout@v4
    - name: Run Unit Tests
      run: npm test
```

### End-to-End Tests

Ensure critical user flows still work:

```yaml
e2e-tests:
  runs-on: ubuntu-latest
  steps:
    - uses: actions/checkout@v4
    - name: Run E2E Tests
      run: npm run test:e2e
```

### Jira Ticket Creation on Failure

Automatically create tickets for failed scans:

```yaml
- name: Create Jira Issue
  if: failure()
  uses: atlassian/gajira-create@v3
  with:
    project: SEC
    issuetype: Bug
    summary: "Security Scan Failed - ${{ github.repository }}"
    description: |
      Scheduled security scan failed.

      Repository: ${{ github.repository }}
      Workflow: ${{ github.workflow }}
      Run: ${{ github.server_url }}/${{ github.repository }}/actions/runs/${{ github.run_id }}

      Please investigate and remediate.
```

## Adding Security Scanning to Your Project

### Prerequisites

**Project structure:**

- Source code in `./src` directory
- Dockerfile at repository root
- Docker build context is repository root

### Installation Steps

#### 1. Copy Actions

```bash
# From the template repository root
cd /path/to/your-project

# Create actions directory
mkdir -p .github/actions

# Copy all required actions
cp -r /path/to/orangit-template/github/actions/docker-lint .github/actions/
cp -r /path/to/orangit-template/github/actions/docker-scan .github/actions/
cp -r /path/to/orangit-template/github/actions/security-scan-code .github/actions/
cp -r /path/to/orangit-template/github/actions/scheduled_test_setup .github/actions/
```

#### 2. Copy Workflow

```bash
# Create workflows directory
mkdir -p .github/workflows

# Copy the workflow
cp /path/to/orangit-template/github/workflows/scheduled-test.yml .github/workflows/
```

#### 3. Verify Structure

```bash
.github/
├── actions/
│   ├── docker-lint/
│   │   ├── action.yml
│   │   └── README.md
│   ├── docker-scan/
│   │   ├── action.yml
│   │   └── README.md
│   ├── security-scan-code/
│   │   ├── action.yml
│   │   └── README.md
│   └── scheduled_test_setup/
│       ├── action.yml
│       └── README.md
└── workflows/
    └── scheduled-test.yml
```

#### 4. Commit and Push

```bash
git add .github/
git commit -m "Add security scanning workflow"
git push
```

#### 5. Verify Workflow

1. Go to repository on GitHub
2. Navigate to **Actions** tab
3. Select **Scheduled Test** workflow
4. Click **Run workflow** to test manually
5. Verify all jobs pass

## Generic Implementation (Platform-Agnostic)

The security scanning can be implemented on any CI/CD platform using these generic bash scripts.

### Generic Security Scan Script

```bash
#!/bin/bash
# generic-security-scan.sh
#
# Usage: ./generic-security-scan.sh <source-directory> <dockerfile-path> <image-name>
#
# Requirements: docker, curl

set -e

SOURCE_DIR="${1:-.}"
DOCKERFILE="${2:-./Dockerfile}"
IMAGE_NAME="${3:-app}"
IMAGE_TAG="${4:-latest}"
FAIL_ON_SEVERITY="${5:-high}"

echo "=== Security Scanning Pipeline ==="
echo "Source Directory: $SOURCE_DIR"
echo "Dockerfile: $DOCKERFILE"
echo "Image Name: $IMAGE_NAME:$IMAGE_TAG"
echo "Fail on Severity: $FAIL_ON_SEVERITY"
echo ""

# Install Syft
echo "Installing Syft..."
curl -sSfL https://raw.githubusercontent.com/anchore/syft/main/install.sh | sh -s -- -b /usr/local/bin

# Install Grype
echo "Installing Grype..."
curl -sSfL https://raw.githubusercontent.com/anchore/grype/main/install.sh | sh -s -- -b /usr/local/bin

# Install Hadolint
echo "Installing Hadolint..."
wget -O /usr/local/bin/hadolint https://github.com/hadolint/hadolint/releases/latest/download/hadolint-Linux-x86_64
chmod +x /usr/local/bin/hadolint

echo ""
echo "=== Step 1: Code-Level Security Scan ==="
cd "$SOURCE_DIR"
syft . -o json > sbom-code.json
echo "Scanning for vulnerabilities in source code..."
if ! grype sbom:sbom-code.json --only-fixed --fail-on "$FAIL_ON_SEVERITY" -o table; then
    echo "❌ Code security scan failed!"
    exit 1
fi
echo "✅ Code security scan passed"
cd - > /dev/null

echo ""
echo "=== Step 2: Dockerfile Linting ==="
if ! hadolint "$DOCKERFILE"; then
    echo "❌ Dockerfile linting failed!"
    exit 1
fi
echo "✅ Dockerfile linting passed"

echo ""
echo "=== Step 3: Build Docker Image ==="
docker build -f "$DOCKERFILE" -t "$IMAGE_NAME:$IMAGE_TAG" .
echo "✅ Docker image built successfully"

echo ""
echo "=== Step 4: Container Security Scan ==="
syft "$IMAGE_NAME:$IMAGE_TAG" -o json > sbom-container.json
syft "$IMAGE_NAME:$IMAGE_TAG" -o spdx-json > sbom-container-spdx.json
syft "$IMAGE_NAME:$IMAGE_TAG" -o cyclonedx-json > sbom-container-cyclonedx.json
echo "Scanning container for vulnerabilities..."
if ! grype sbom:sbom-container.json --only-fixed --fail-on "$FAIL_ON_SEVERITY" -o table; then
    echo "❌ Container security scan failed!"
    exit 1
fi
echo "✅ Container security scan passed"

echo ""
echo "=== Security Scan Complete ==="
echo "All security checks passed successfully!"
echo ""
echo "Generated artifacts:"
echo "  - sbom-code.json (source code SBOM)"
echo "  - sbom-container.json (container SBOM)"
echo "  - sbom-container-spdx.json (SPDX format)"
echo "  - sbom-container-cyclonedx.json (CycloneDX format)"

# Cleanup
docker rmi "$IMAGE_NAME:$IMAGE_TAG" || true
```

### Make Script Executable

```bash
chmod +x generic-security-scan.sh
```

## GitLab CI Implementation

Create `.gitlab-ci.yml`:

```yaml
# .gitlab-ci.yml

stages:
  - security

variables:
  DOCKER_DRIVER: overlay2
  SOURCE_DIR: "./src"
  FAIL_ON_SEVERITY: "high"

security-scan:
  stage: security
  image: docker:latest
  services:
    - docker:dind
  before_script:
    - apk add --no-cache curl bash wget
  script:
    - chmod +x ./scripts/generic-security-scan.sh
    - ./scripts/generic-security-scan.sh "$SOURCE_DIR" "./Dockerfile" "app" "$CI_COMMIT_SHA" "$FAIL_ON_SEVERITY"
  artifacts:
    paths:
      - sbom-*.json
    expire_in: 90 days
  only:
    - schedules
    - web

# Schedule: Go to CI/CD > Schedules > New schedule
# Set to run daily at 2 AM UTC
```

### GitLab-Specific Features

```yaml
# Add to .gitlab-ci.yml for Jira integration
security-scan:
  # ... existing config ...
  after_script:
    - |
      if [ $CI_JOB_STATUS == 'failed' ]; then
        # Create Jira issue via API
        curl -X POST \
          -H "Content-Type: application/json" \
          -u "$JIRA_USER:$JIRA_TOKEN" \
          -d '{
            "fields": {
              "project": {"key": "SEC"},
              "summary": "Security Scan Failed - '"$CI_PROJECT_NAME"'",
              "description": "Build: '"$CI_PIPELINE_URL"'",
              "issuetype": {"name": "Bug"},
              "priority": {"name": "High"}
            }
          }' \
          "$JIRA_URL/rest/api/2/issue"
      fi
```

## Bitbucket Pipelines Implementation

Create `bitbucket-pipelines.yml`:

```yaml
# bitbucket-pipelines.yml

image: docker:latest

definitions:
  services:
    docker:
      memory: 2048

  scripts:
    - &security-scan |
      apk add --no-cache curl bash wget
      chmod +x ./scripts/generic-security-scan.sh
      ./scripts/generic-security-scan.sh "./src" "./Dockerfile" "app" "$BITBUCKET_COMMIT" "high"

pipelines:
  # Manual trigger
  custom:
    security-scan:
      - step:
          name: Security Scan
          services:
            - docker
          script:
            - *security-scan
          artifacts:
            - sbom-*.json

  # Scheduled (Configure in Bitbucket UI: Repository settings > Schedules)
  schedules:
    daily-security-scan:
      - step:
          name: Scheduled Security Scan
          services:
            - docker
          script:
            - *security-scan
          after-script:
            - |
              if [ $BITBUCKET_EXIT_CODE -ne 0 ]; then
                # Send notification (requires BB_WEBHOOK configured)
                curl -X POST "$BB_WEBHOOK" \
                  -H "Content-Type: application/json" \
                  -d '{
                    "text": "🚨 Security scan failed in '"$BITBUCKET_REPO_SLUG"'",
                    "url": "'"https://bitbucket.org/$BITBUCKET_WORKSPACE/$BITBUCKET_REPO_SLUG/pipelines/results/$BITBUCKET_BUILD_NUMBER"'"
                  }'
              fi
          artifacts:
            - sbom-*.json
```

### Bitbucket Schedule Setup

1. Go to **Repository settings** → **Pipelines** → **Schedules**
2. Click **Add schedule**
3. Name: "Daily Security Scan"
4. Branch: main
5. Pipeline: custom: security-scan
6. Cron expression: `0 2 * * *` (2 AM UTC daily)
7. Save

## Jenkins Implementation

Create `Jenkinsfile`:

```groovy
// Jenkinsfile

pipeline {
    agent {
        docker {
            image 'docker:latest'
            args '-v /var/run/docker.sock:/var/run/docker.sock'
        }
    }

    triggers {
        cron('0 2 * * *') // Daily at 2 AM UTC
    }

    environment {
        SOURCE_DIR = './src'
        DOCKERFILE = './Dockerfile'
        IMAGE_NAME = 'app'
        FAIL_ON_SEVERITY = 'high'
    }

    stages {
        stage('Setup') {
            steps {
                sh 'apk add --no-cache curl bash wget'
                sh 'chmod +x ./scripts/generic-security-scan.sh'
            }
        }

        stage('Security Scan') {
            steps {
                sh '''
                    ./scripts/generic-security-scan.sh \
                        "$SOURCE_DIR" \
                        "$DOCKERFILE" \
                        "$IMAGE_NAME" \
                        "$GIT_COMMIT" \
                        "$FAIL_ON_SEVERITY"
                '''
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: 'sbom-*.json', fingerprint: true
        }
        failure {
            script {
                // Create Jira ticket
                jiraNewIssue(
                    issue: [
                        fields: [
                            project: [key: 'SEC'],
                            summary: "Security Scan Failed - ${env.JOB_NAME}",
                            description: "Build: ${env.BUILD_URL}",
                            issuetype: [name: 'Bug'],
                            priority: [name: 'High']
                        ]
                    ]
                )
            }
            emailext(
                subject: "Security Scan Failed: ${env.JOB_NAME}",
                body: "Build URL: ${env.BUILD_URL}",
                to: env.SECURITY_TEAM_EMAIL
            )
        }
    }
}
```

## CircleCI Implementation

Create `.circleci/config.yml`:

```yaml
# .circleci/config.yml

version: 2.1

executors:
  docker-executor:
    docker:
      - image: docker:latest
    environment:
      SOURCE_DIR: "./src"
      FAIL_ON_SEVERITY: "high"

jobs:
  security-scan:
    executor: docker-executor
    steps:
      - checkout
      - setup_remote_docker:
          docker_layer_caching: true

      - run:
          name: Install Dependencies
          command: apk add --no-cache curl bash wget

      - run:
          name: Run Security Scan
          command: |
            chmod +x ./scripts/generic-security-scan.sh
            ./scripts/generic-security-scan.sh \
              "$SOURCE_DIR" \
              "./Dockerfile" \
              "app" \
              "$CIRCLE_SHA1" \
              "$FAIL_ON_SEVERITY"

      - store_artifacts:
          path: sbom-code.json
          destination: sbom/code

      - store_artifacts:
          path: sbom-container.json
          destination: sbom/container

      - run:
          name: Create Jira Issue on Failure
          when: on_fail
          command: |
            curl -X POST \
              -H "Content-Type: application/json" \
              -u "$JIRA_USER:$JIRA_TOKEN" \
              -d '{
                "fields": {
                  "project": {"key": "SEC"},
                  "summary": "Security Scan Failed - '"$CIRCLE_PROJECT_REPONAME"'",
                  "description": "Build: '"$CIRCLE_BUILD_URL"'",
                  "issuetype": {"name": "Bug"}
                }
              }' \
              "$JIRA_URL/rest/api/2/issue"

workflows:
  version: 2
  scheduled-security-scan:
    triggers:
      - schedule:
          cron: "0 2 * * *"
          filters:
            branches:
              only: main
    jobs:
      - security-scan

  manual-security-scan:
    jobs:
      - security-scan:
          filters:
            branches:
              only: /.*/
```

## Best Practices

### 1. Notification Strategy

Set up multiple notification channels:

```bash
# Slack notification example
curl -X POST "$SLACK_WEBHOOK" \
  -H "Content-Type: application/json" \
  -d '{
    "text": "🔒 Security Scan Alert",
    "blocks": [{
      "type": "section",
      "text": {
        "type": "mrkdwn",
        "text": "*Security scan failed* for `'"$REPO_NAME"'`\n<'"$BUILD_URL"'|View Build>"
      }
    }]
  }'
```

### 2. Severity Threshold Configuration

Start with `high` and adjust based on your risk tolerance:

- **Critical only**: `fail-on-severity: critical` - Minimum disruption
- **High and above**: `fail-on-severity: high` - Recommended balance
- **Medium and above**: `fail-on-severity: medium` - Strict security posture

### 3. Exception Handling

Create a `.grype.yaml` for known false positives:

```yaml
# .grype.yaml
ignore:
  - vulnerability: CVE-2024-12345
    reason: "False positive - not applicable to our use case"
    expires: "2024-12-31"
```

### 4. SBOM Management

Store SBOMs for compliance and auditing:

```bash
# Upload to artifact storage
aws s3 cp sbom-container.json \
  s3://security-artifacts/sboms/$REPO_NAME/$BUILD_ID/
```

### 5. Monitoring and Metrics

Track security scan metrics:

- Time to detect (vulnerability disclosure → scan detection)
- Time to fix (detection → remediation deployed)
- False positive rate
- Scan success rate

## Troubleshooting

### Common Issues

#### Scan Takes Too Long

**Problem**: Security scan exceeds CI timeout

**Solution**:

- Use smaller base images (alpine variants)
- Implement multi-stage builds
- Cache SBOM generation results

#### Too Many False Positives

**Problem**: Scans fail on non-exploitable vulnerabilities

**Solution**:

- Use `.grype.yaml` to suppress known false positives
- Focus on `--only-fixed` vulnerabilities
- Adjust severity threshold

#### Network Timeouts

**Problem**: Tool installation fails

**Solution**:

- Use CI-provided docker images with tools pre-installed
- Cache tool binaries
- Use local mirrors for tool downloads

## References

- [Syft Documentation](https://github.com/anchore/syft)
- [Grype Documentation](https://github.com/anchore/grype)
- [Hadolint Documentation](https://github.com/hadolint/hadolint)
- [OWASP Container Security](https://owasp.org/www-community/vulnerabilities/Container_Security)
- [NIST Container Security Guide](https://nvlpubs.nist.gov/nistpubs/SpecialPublications/NIST.SP.800-190.pdf)
