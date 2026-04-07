# Slack Channel Naming Conventions

Consistent channel naming helps users find the right place for discussions and keeps communication clear. Here are the recommendations for naming Slack channels:

#### **1\. General Structure**

- **Prefixes**: Use consistent prefixes to clarify the channel's purpose. Examples:
  - Assignment channels (e.g., `customer-assignment`)
  - Team channels (e.g., `sales-function`)
  - Topic or interest channels (e.g., `random`)
  - External channels (e.g., `orangit-other-company`)
  - Orangit company-wide functional channels
  - Source of external channel. For example wunderdog-orangit-sales.
- **Postfixes**: Use consistent postfixes to clarify the channel's purpose. Examples:
  - Internal channel \*-internal
  - External participant \*-ext
  - Alams \*-alerts
  - Notifications \*-notifications
  - Inbox \*-inbox

#### **2\. Channel Type Descriptions**

- **Assigmennt Channels** (`customer-<assignment>`) are intended for individual projects and help teams coordinate the work of that assigment.
  - Channels are mostly public but can be encrypted based on customer data security requirements.
- **Team Channels** (`team-<team name>`) focus on specific departments or workgroups and are used for coordinating team activities.
  - Teams may have functional channels, such as a notifications channel.
  - Team channels should be public. Functional team channels can be private if required by customer data security policies.
- **Topic Channels** (`topic-<topic name>`) are open for discussions on specific topics that may interest a broader audience.
  - Topic channels are always public.
- **External Channels** (other-company-orangit-function-) are used for communication with other companies.
  - Channels are primarily encrypted.
  - For example wunderdog-orangit-sales
- **Orangit Functional Channels** (`orangit-function`) are used for specific functionalities, such as announcements from internal systems or internal projects.
  - Channels are always public.

#### **3\. Naming Conventions**

Channel names are written in lowercase letters, and different parts are separated by hyphens.

Assigment channels are named `customer-assignment-int`. For example, `pharmaservice-anja-int`. A project may have a channel that includes external participants, such as customer representatives. External channels are named `customer-assignment-ext`. Assignments may have their own notification channel, named `customer-assignment-notifications`. An assignment may also have a channel that displays incoming messages from Google Groups, named `customer-assignment-inbox`. Multiple assignments for the same customers can be combined to a single channel by removing the assignment part from the naming.

The general team channel name is the team's name, e.g., `viima` or `sales`. The team may have its own notifications channel, named `team-notifications`. The team may also have a channel displaying incoming messages from Google Groups, named `team-name-inbox, for example viima-inbox.`

The topic channel name is a short version of the topic. You can optionally use the prefix `topic`.

External channels are written in the format `other-company-orangit-function`, for example, `wunderdog-orangit-elisa-collaboration`.

Internal company channels can start with the prefix `orangit`. For example, `orangit-website` or `orangit-billing-app`.

#### **4\. Best Practices**

- **Avoid long names**: Keep names as short as possible but descriptive.
- **Consistency**: Use the same convention across the organization to keep channels organized.
- **Purpose of communication**: The channel name should indicate the main purpose of the channel so that new members can easily understand why and when to use it.

#### **5\. Examples**

- `sales` – team channel for sales.
- `topic-sport` – open discussion channel for those interested in sports.
- `pharmaservice-anja-internal` – internal channel for managing the Pharmaservice Anja assignment.
- `pharmaservice-anja-ext` – external channel involving stakeholders from other organizations.
- `pharmaservice-anja-alerts` – special channel for alerts.

By following these conventions, we ensure that Slack channels remain organized and easy to use for everyone. This also helps onboard new members and facilitates automation.
