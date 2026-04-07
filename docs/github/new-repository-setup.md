# How to create a new repository from the Orangit template

## 1. Create the repository

1. Go to the [orangitfi/template](https://github.com/orangitfi/template) repository
2. Click the green **"Use this template"** button
3. Select **"Create a new repository"**
4. Fill in:
   - **Owner** — select the `orangit` organisation
   - **Repository name** — use lowercase with hyphens (e.g. `my-project`)
   - **Visibility** — **Private**
5. Click **"Create repository"**

---

## 2. Add the GitHub Actions secret

Go to **Settings → Secrets and variables → Actions → New repository secret** and add:

| Secret name                | Where to find the value                                                                                |
| -------------------------- | ------------------------------------------------------------------------------------------------------ |
| `OP_SERVICE_ACCOUNT_TOKEN` | 1Password → vault **`orangit-documenter`** → item **`Service Account Auth Token: orangit-documenter`** |

---

## 3. Import the branch protection ruleset

This is optional. Ruleset is trunk-based with short-lived.

1. Go to **Settings → Rules → Rulesets**
2. Click **"Import ruleset"**
3. Upload `.github/rulesets/main.json` from the repository

This enforces squash-only merges, 1 required review, and the CI status check on `main`.

---

## 4. Configure CODEOWNERS

This is optional. It makes easier to have people in PRs.

Open `.github/CODEOWNERS`, uncomment the rules and replace the placeholder team names with real GitHub teams or usernames:

```
* @orangit/your-team
*.md @orangit/your-team
.github/ @orangit/your-team
```

---

## 5. Set up the Confluence space

1. Create a Confluence space for the project if one does not already exist
2. Find the space key under **Space Settings → Space Details** in Confluence
3. Open `.github/workflows/publish-to-confluence.yml` and update:

```yaml
space-key: "YOUR_SPACE_KEY"
root-page-title: "Your Project Documentation"
confluence-prefix: "" # optional, e.g. "[my-repo] " if sharing a space
```

---

## 6. Update CI workflow paths

Open `.github/workflows/scheduled-test.yml` and update the values to match your project layout:

| Field                                    | Default | Change to                                                              |
| ---------------------------------------- | ------- | ---------------------------------------------------------------------- |
| `working-directory` (pytest, ruff, mypy) | `src`   | path to your source package                                            |
| `working-directory` (terraform)          | `infra` | path to your Terraform code                                            |
| `image-name` (docker-scan)               | `app`   | your Docker image name                                                 |
| Mypy target                              | `.`     | your main module or entry point. Remove this for non-python repository |

Do the same for `.github/workflows/ci.yml` — replace the placeholder step with real jobs.

---

## 7. Install pre-commit hooks (every developer, after cloning)

Each developer must run this once after cloning the repository:

```sh
uv tool install pre-commit
pre-commit install
```

This activates the [gitleaks](https://github.com/gitleaks/gitleaks) secrets scanner as a local git commit hook. Without this step, secrets scanning does **not** run.

---

## Checklist

- [ ] Repository created from template (Private)
- [ ] `OP_SERVICE_ACCOUNT_TOKEN` secret added
- [ ] Branch protection ruleset imported
- [ ] CODEOWNERS updated
- [ ] Confluence space created and workflow configured (`space-key`, `root-page-title`)
- [ ] CI workflow paths updated for this project
- [ ] All developers have run `pre-commit install`
