# Using the template repository

## General files

**.gitignore:** .gitignore is a configuration file that tells Git which files 
and directories to ignore when tracking changes in your repository.template 
repository has the generic .gitignore. Remember
to include operating systems and editors (macos,windows,linux,visualstudio,
visualstudiocode,jetbrains,vim). Good place to generate the .gitignore is
[gitignore.io](https://www.toptal.com/developers/gitignore/)
 **Common patterns in `.gitignore`**:
   - Build artifacts (like `dist/`, `build/`)
   - Dependencies (like `node_modules/`, `venv/`)
   - Environment files (`.env`)
   - IDE files (`.vscode/`, `.idea/`)
   - OS-specific files (`.DS_Store`, `Thumbs.db`)
   - Log files
   - Temporary files


**.dockerignore:** .dockerignore is a configuration file that specifies which files and directories should be excluded when copying files into a Docker image during the build process. It follows similar syntax to .gitignore and helps keep Docker images smaller and more secure by excluding unnecessary files like development dependencies, version control files, and sensitive data. The .dockerignore file should be placed in the same directory as your Dockerfile.

`.dockerignore` file that includes:

1. Version control files (`.git`, `.github`)
2. Documentation (except README.md)
3. Development files and IDE configurations
4. Dependencies and virtual environments
5. Build outputs and logs
6. Test files and coverage reports
7. Docker-related files
8. Temporary files
9. Local configuration files
10. IDE-specific files

This `.dockerignore` file will help:
- Reduce the Docker image size by excluding unnecessary files
- Improve build performance
- Prevent sensitive information from being included in the image
- Keep the build context clean and focused on only the necessary files

**CHANGELOG.md:** CHANGELOG.md is a file that documents all notable changes made to a project over time. It helps users and contributors track the project's evolution by recording version updates, new features, bug fixes, and breaking changes. The file typically follows the [Keep a Changelog](https://keepachangelog.com/) format, organizing changes under categories like:

- Added: New features
- Changed: Changes in existing functionality 
- Deprecated: Features that will be removed
- Removed: Features that were removed
- Fixed: Bug fixes
- Security: Security vulnerability fixes

Each version should be clearly marked with:
- Version number (following semantic versioning)
- Release date
- List of changes under appropriate categories

This makes it easier for users to:
- Understand what's new in each release
- Plan upgrades between versions
- Track breaking changes
- See the project's development history

**CODEOWNERS:** CODEOWNERS is a configuration file used in Git repositories that defines which teams or individuals are responsible for specific parts of the codebase. When someone opens a pull request that modifies code in a directory or file that has a designated owner, those owners are automatically requested to review the changes.

The CODEOWNERS file uses a simple pattern matching syntax:
- Each line contains a file pattern followed by one or more owners
- Patterns follow the same rules used in .gitignore files
- Order matters - the last matching pattern takes precedence
- Owners can be @usernames or @org/team-name

**CODE_OF_CONDUCT.md:** CODE_OF_CONDUCT.md is a document that establishes guidelines for behavior and interaction within a project's community. It outlines the standards of conduct expected from all participants, including contributors, maintainers, and users. The file typically includes:

- A pledge to create a welcoming and inclusive environment
- Examples of acceptable and unacceptable behavior
- Responsibilities of project maintainers
- Scope of application (project spaces and public spaces)
- Enforcement procedures and reporting mechanisms
- Consequences for violations

Having a Code of Conduct helps:
- Create a positive and respectful community atmosphere
- Set clear expectations for participant behavior
- Provide a framework for addressing conflicts
- Demonstrate commitment to inclusivity
- Protect community members from harassment or discrimination

**CONTRIBUTING.md:** CONTRIBUTING.md is a document that provides guidelines for contributing to a project. It helps new contributors understand how they can effectively participate in the project's development. The file typically includes:

- How to submit contributions (pull requests, issues, etc.)
- Development setup instructions
- Coding standards and conventions
- Testing requirements
- Pull request process and review criteria
- Issue reporting guidelines
- Communication channels
- License and legal considerations

Having clear contribution guidelines helps:
- Streamline the contribution process
- Maintain code quality and consistency 
- Reduce friction for new contributors
- Save maintainers' time by answering common questions
- Build a sustainable development community

**LICENSE:** The LICENSE file is a crucial document that specifies how others can legally use, modify, and distribute your project's code. It outlines the terms and conditions under which the software is made available. The file typically includes:

- Copyright notice and year
- Permissions granted to users
- Conditions for using the code
- Warranty disclaimers and liability limitations
- Any restrictions on usage

Having a clear license helps:
- Define legal boundaries for code usage
- Protect intellectual property rights
- Enable collaboration and code sharing
- Clarify terms for commercial use
- Provide legal protection for both creators and users

**README.md:** README.md is the primary documentation file that serves as an introduction and guide to a project. It's often the first document users and contributors encounter. The file typically includes:

- Project name and description
- Purpose and key features
- Installation and setup instructions
- Usage examples and documentation
- Development setup requirements
- Testing procedures
- Contribution guidelines
- License information
- Contact information or support channels

Having a comprehensive README helps:
- Orient new users and contributors quickly
- Provide essential project information
- Document setup and usage procedures
- Reduce support burden through self-service
- Demonstrate project professionalism and maintenance
- Improve project discoverability and adoption

Replace the README.md with template id [docs/template/README.md](./templates/README.MD)

**SECURITY.md:** SECURITY.md is a critical file that documents the project's security policies and procedures. It provides guidance on reporting vulnerabilities and outlines the security support status for different versions. The file typically includes:

- Supported versions and security update status
- Vulnerability reporting process and channels
- Expected response times and procedures
- Security update policy and timeline
- Disclosure and communication guidelines

Having a SECURITY.md helps:
- Establish clear security practices
- Guide responsible vulnerability reporting
- Set expectations for security responses
- Document version support status
- Demonstrate security commitment

**.editorconfig:** .editorconfig is a configuration file that helps maintain consistent coding styles across different editors and IDEs. It defines coding style preferences like indentation, line endings, and character encoding. The file typically includes:

- Root configuration indicator
- File type patterns and rules
- Indentation style (spaces/tabs) and size
- Line ending format (LF/CRLF)
- Character encoding settings
- Trim trailing whitespace rules
- Final newline requirements

Having an .editorconfig helps:
- Enforce consistent code formatting
- Reduce style-related merge conflicts
- Simplify onboarding for new developers
- Support multi-editor development teams
- Automate code style enforcement

## Architectural decision records

Architectural Decision Records (ADRs) are documents that capture important architectural decisions made during a project, along with their context and consequences. They serve as a historical record of significant technical choices and their rationale.

See more [ADR](./adr/index.md)

## Github

## Github Actions 

**.github/actions/docker-build-publish:** This reusable GitHub Action automates Docker image building and publishing with security features. It handles:

- Building Docker images using Buildx
- Generating Software Bill of Materials (SBOM) with Syft
- Security scanning with Grype for vulnerabilities
- Publishing images to container registries
- Managing registry authentication
- Cleanup of temporary files

The action requires inputs like working directory, Dockerfile path, registry details, and authentication credentials. It helps standardize and secure the Docker build and publish process across projects.

This is done with bare commands. 
- It can be executed in developem machines
- The image is scanned between build and publish
- There is less security risk secrets to be leaked

## Cursor

### Rules

**docs/cursor/rules/python:** This directory contains Python code style and formatting templates for Cursor, including:

- PEP 8 style guide rules
- Import organization preferences 
- Line length and wrapping guidelines
- Docstring formatting standards
- Type hint usage requirements
- Naming conventions for variables, functions, and classes
- Code organization best practices
- Error handling patterns
- Testing requirements and patterns