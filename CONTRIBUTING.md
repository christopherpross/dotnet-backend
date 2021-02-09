# Contributing to the project

## Issues

Please make sure to check for duplicate issues and use the issue templates. Issues not conforming to the guidelines may be closed immediately.

#### Found a bug?

If you find a bug in the source code, you can help us by
[submitting an issue](https://github.com/matthiashermsen/dotnet-backend/issues/new?assignees=&labels=bug&template=bug_report.md&title=). Even better, you can submit a pull request with a fix.

#### Missing a feature?

You can request a new feature by [submitting an issue](https://github.com/matthiashermsen/dotnet-backend/issues/new?assignees=&labels=feature+request&template=feature_request.md&title=). Please always open an issue and outline your proposal so that it can be discussed before working on it. This saves efforts and prevents duplication of work.

## Coding rules

To ensure consistency throughout the source code, keep these rules in mind as you are working:

- Follow the [coding conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
- Follow the [naming guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines)
- Source code must be documented
- All features or bug fixes must be tested by one or more tests

## Git Workflow

This project follows the [Gitflow Workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow).

## Commit message guidelines

Each commit message consists of a type, the referenced issue and a message. The syntax is

```
<type> <issue>: <message>
```

an example would be

```
fix #28: Don't crash on load
```

#### Types

- ci: Changes that affect the CI configuration
- deps: Changes that affect the external dependencies
- docs: Documentation only changes
- feat: A new feature
- fix: A bug fix
- perf: A code change that improves performance
- refactor: A code change that neither fixes a bug nor adds a feature
- style: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
- test: Adding missing tests or correcting existing tests

## Pull request guidelines

- Search the issue list for open or closed PRs that relate to your submission. You don't want to duplicate effort
- The `main` branch is just a snapshot of the latest stable release. All development should be done in dedicated branches. Do always submit PRs against the `dev` branch
- Make sure all tests are passing

## Development setup

TODO
