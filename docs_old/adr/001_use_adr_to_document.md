# Use Architectural decision record

## Status

Accepted

## Context

We do not have enough documentation. Currently sharing information for design is difficult. New developers find hard to start developing for the platform. We lose the context in which the design choices were made.

## Decision

We start using Architectural Decision Record with platform repositories.

## Consequences

By writing ADR, we will get documented way for making design choices for the development.

### What are the benefits ?

#### Onboarding

Future team members are able to read a history of decisions and quickly get up to speed on how and why a decision is made, and the impact of that decision.

#### Ownership Handover

When  organization changes, we expect have to move ownership of repos from one team to another. A lot of context or knowledge is lost when ownership is changed, triggering a decrease in productivity. New owners of a system can quickly get up to speed with how and why the system’s architecture evolved in the way it did simply by reading through the ADRs.

#### Alignment

ADRs have made it easier for teams to align on best practices across. Alignment has the benefit of removing duplicative efforts, making code reusable across projects, and reducing the variance of solutions that teams need to support.
